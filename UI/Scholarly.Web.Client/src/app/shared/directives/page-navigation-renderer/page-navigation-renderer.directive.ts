import { Directive, ElementRef, Renderer2, Input, AfterViewInit, OnDestroy } from '@angular/core';
import { APP_CONSTANTS } from '../../../core';

@Directive({
  selector: '[PageNavigationTarget]',
  standalone: true
})
export class PageNavigationRendererDirective implements AfterViewInit, OnDestroy {
  private mutationObserver!: MutationObserver;
  
  constructor(private elementRef: ElementRef, private renderer: Renderer2) { }

  ngAfterViewInit(): void {
    this.mutationObserver = new MutationObserver((mutations)=>{
      mutations.forEach((mutation)=>{
        if((mutation.addedNodes.length == 0 || !Array.from(mutation.addedNodes).every(this._isNavigationElement))
          && (mutation.removedNodes.length == 0 || !Array.from(mutation.removedNodes).every(this._isNavigationElement)))
          return;

        this._updateTree(this.elementRef.nativeElement.innerHTML);
      });
    });

    this.mutationObserver.observe(this.elementRef.nativeElement, {
      childList: true
    });
  }
  ngOnDestroy(): void {
    if(this.mutationObserver)
      this.mutationObserver.disconnect();
  }

  private _updateTree(targetContent: string){
    let nodes = this.elementRef.nativeElement.querySelectorAll('['+ APP_CONSTANTS.PAGE_NAVIGATION_NODE_ATTR +']');
    let container:any = document.querySelector('['+ APP_CONSTANTS.PAGE_NAVIGATION_TREE_CONTAINER_ATTR+']');
    container.classList.add('list-group', 'list-group-horizontal', 'list-group-flush');
    container.innerHTML = '';

    nodes.forEach((node:any)=>{
      let button = this.renderer.createElement('button');
      button.innerHTML = node.innerHTML;
      button.classList.add('list-group-item', 'list-group-item-action');
      button.addEventListener('click', ()=>{
        node.scrollIntoView({ behavior: 'smooth', block: 'start' });
      });
      container.append(button);
    });
  }
  private _isNavigationElement(value: any, index: number, array: Node[]): boolean{
    return value.hasAttribute != null && value.hasAttribute(APP_CONSTANTS.PAGE_NAVIGATION_NODE_ATTR);
  }
}
