import { Directive, ElementRef, EmbeddedViewRef, Injector, Input, OnChanges, Renderer2, SimpleChanges, TemplateRef, ViewContainerRef } from '@angular/core';
import { ScholarlyHTMLMappingService } from '../../../core/services/scholarly-html-mapping/scholarly-htmlmapping.service';
import { PopoverConfig, PopoverDirective } from 'ngx-bootstrap/popover';
import { ComponentLoaderFactory } from 'ngx-bootstrap/component-loader';
import { PositioningService } from 'ngx-bootstrap/positioning';
import { ArticleImageUploadService, ArticleService } from '../../../core';
import { article } from '../../../core/models/article/article';
import { KeyValueDictionary } from '../../../core/utilities/keyValuePairDictionary';
import { DomSanitizer } from '@angular/platform-browser';
import { APP_CONSTANTS } from '../../../core';
import { HttpErrorResponse, HttpStatusCode } from '@angular/common/http';

@Directive({
  selector: '[MapToHtml]',
  standalone: true
})
export class MapToHtmlDirective implements OnChanges {
  @Input('MapToHtml') scholarlyEncodedString!: string;
  private _container: any;

  constructor(private scholarlyMappingService: ScholarlyHTMLMappingService, private renderer: Renderer2, private elementRef: ElementRef
    , private vcr: ViewContainerRef, private clf: ComponentLoaderFactory, private ps: PositioningService
    , private articleService: ArticleService, private sanitizer: DomSanitizer, private articleImageService: ArticleImageUploadService
  ) {
    this._container = document.getElementsByTagName('body')[0];
    if (!this._container.loadedData)
      this._container.loadedData = new KeyValueDictionary<string, article>();
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (!changes['scholarlyEncodedString'].firstChange) {
      this._convertToHtml();
      this._initializeInformationPopover();
      this._initializeImages();
    }
  }

  private _convertToHtml() {
    if (this.scholarlyEncodedString)
      this.elementRef.nativeElement.innerHTML = this.scholarlyMappingService.mapToHtml(this.scholarlyEncodedString);
  }

  private _initializeInformationPopover() {
    let scholarlyInfoElements = this.elementRef.nativeElement.getElementsByClassName('content-info');

    if (scholarlyInfoElements.length == 0)
      return;

    let _config: PopoverConfig = {
      delay: 0,
      adaptivePosition: true,
      outsideClick: true,
      placement: 'auto',
      triggers: 'hover',
      container: 'body'
    };

    Array.from(scholarlyInfoElements).forEach((scholarlyElement: any) => {
      let eRef = new ElementRef(scholarlyElement);

      const popoverDirective = new PopoverDirective(_config, eRef, this.renderer, this.vcr, this.clf, this.ps);
      popoverDirective.popoverTitle = 'Please wait';
      popoverDirective.popover = 'Loading...';
      popoverDirective.triggers = 'hover';

      let popoverVisibilityHelper = (() => {
        let openTimeout: any;
        let closeTimeout: any;
        let handleTargetEvents = () => {
          //showing popover when mouse enters target element
          scholarlyElement.addEventListener('mouseenter', () => {
            if (popoverDirective.isOpen)
              clearTimeout(closeTimeout);
            else
              openTimeout = setTimeout(() => {
                popoverDirective.show();
              }, 1500);
          });
          //hiding popover when mouse leaves target element
          scholarlyElement.addEventListener('mouseleave', () => {
            if (!popoverDirective.isOpen)
              clearTimeout(openTimeout);
            else
              closeTimeout = setTimeout(() => {
                popoverDirective.hide();
              }, 1500);
          });
          //hiding popover on click outside popover body
          document.addEventListener('click', (event: MouseEvent) => {
            const target = event.target as HTMLElement;
            if (!target.classList.contains('popover'))
              popoverDirective.hide();
          });
        };
        let handlePopoverEvents = () => {
          let popoverContainer = document.getElementsByClassName('popover')[0];

          //stopping popover from hiding when mouse enters popup
          popoverContainer.addEventListener('mouseenter', () => {
            clearTimeout(closeTimeout);
          });
          //hiding popover when mouse leaves popup
          popoverContainer.addEventListener('mouseleave', () => {
            closeTimeout = setTimeout(() => {
              popoverDirective.hide();
            }, 1500);
          });
        };

        return {
          handleTargetEvents: handleTargetEvents,
          handlePopoverEvents: handlePopoverEvents
        }
      })();

      popoverVisibilityHelper.handleTargetEvents();

      //popover onShown event
      popoverDirective.onShown.subscribe(() => {
        let selector: string | null = eRef.nativeElement.getAttribute(APP_CONSTANTS.ARTICLE_SELECTOR_ATTR);
        if (!selector)
          throw ('selector not found');

        popoverVisibilityHelper.handlePopoverEvents();

        let renderContentInPopover = (article: article) => {
          let popover: any = document.getElementsByClassName('popover')![0];

          if (!popover)
            return;

          popover.querySelector('.popover-title').innerHTML = article.title;

          popover.querySelector('.popover-content').innerHTML = this.scholarlyMappingService.mapToHtml(<string>article?.introduction);
        }

        let loadedData = this._container.loadedData as KeyValueDictionary<string, article>;
        if (loadedData.contains(selector))
          renderContentInPopover(<article>loadedData.get(selector));
        else {
          this.articleService.getBySelector(selector).subscribe({
            next: (article: article) => {
              renderContentInPopover(article);

              this._container.loadedData.add(selector, article);
            },
            error: (err: HttpErrorResponse)=>{
              if(err.error.statusCode == HttpStatusCode.NotFound){
                renderContentInPopover(<any>{title: 'Not found', introduction: 'This resource does not exist'});
                
                return;
              }

              //throw err;
            }
          });
        }      
      });
  });
  }

  private _initializeImages(){
    let scholarlyImageElements = this.elementRef.nativeElement.getElementsByClassName('content-image');

    if(scholarlyImageElements.length == 0)
      return;
    
    Array.from(scholarlyImageElements).forEach((scholarlyElement:any)=>{
      let selector: string = scholarlyElement.getAttribute(APP_CONSTANTS.ARTICLE_IMAGE_SELECTOR_ATTR);

      let imageData = this.articleImageService.getImage(selector);

      let img = scholarlyElement.childNodes[0];
      img.src = imageData.url;
      img.alt = imageData.caption;
      
      //inserting caption
      let caption = document.createElement('div');
      caption.classList.add('content-image-caption');
      caption.innerHTML = imageData.caption;

      scholarlyElement.innerHTML+= caption.outerHTML;
    });
  }
}
