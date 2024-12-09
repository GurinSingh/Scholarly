import { KeyValue, KeyValuePipe } from '@angular/common';
import { Attribute, ElementRef, Inject, Injectable, Renderer2, ViewContainerRef } from '@angular/core';
import { KeyValueDictionary } from '../../utilities/keyValuePairDictionary';
import { PopoverConfig, PopoverDirective } from 'ngx-bootstrap/popover';
import { ComponentLoaderFactory } from 'ngx-bootstrap/component-loader';
import { PositioningService } from 'ngx-bootstrap/positioning';

@Injectable({
  providedIn: 'root'
})
export class ScholarlyHTMLMappingService {
  constructor() { }

  public mapToHtml(scholarlyEncodedString: string): string{
    let mapper = new Mapper(scholarlyEncodedString, new ScholarlyElements());
    return mapper.getHtml();
  }
}

interface IScholarlyElement{
  htmlTag: string;
  scholarlyTag: string;
  wrapper: string;
  attributes: KeyValueDictionary<string, string>;
  cssClass: string;
  regex: RegExp
  render: (ScholarlyElementString: string)=> string;
}

class ScholarlyElementBase{
  start: string = '|';
  end: string = "|";

  setAttribute = (targetElement: any, attributes: KeyValueDictionary<string, string>)=>{
    attributes.getAll().forEach(pair => {
      if(pair.key in targetElement.style && pair.key != 'src')
        targetElement.style[pair.key] = pair.value;
      else
        targetElement.setAttribute(pair.key, pair.value);
    });
  };

  getScholarlyElementAttributes = (scholarlyElementString: string, scholarlyElement: IScholarlyElement): KeyValueDictionary<string, string>=>{
    const expression = new RegExp("[a-zA-Z-]+\\d?=[a-zA-Z0-9-]+", 'g');
    
    let matches = scholarlyElementString
        .substring(0, scholarlyElementString.search(':'))
        .replaceAll(this.start + scholarlyElement.scholarlyTag, '')
        .trim()      
        .matchAll(expression);

    let keyValueDict: KeyValueDictionary<string, string> = new KeyValueDictionary<string, string>();

    Array.from(matches).map(match=> {
      let keyValue: string[] = match[0].split('=');
      keyValueDict.add(keyValue[0],keyValue[1]);
    });

    return keyValueDict;
  };

  getScholarlyElementContent = (scholarlyElementString: string, scholarlyElement: IScholarlyElement): string=>{
    return scholarlyElementString.replace(scholarlyElementString.substring(0, scholarlyElementString.search(':')+1),'')
      .replace(this.start+scholarlyElement.scholarlyTag,'');
  }
}
export class ScholarlyInfo extends ScholarlyElementBase implements IScholarlyElement{
  scholarlyTag: string = 'info';
  wrapper: string = 'span';
  attributes: KeyValueDictionary<string, string> = new KeyValueDictionary<string, string>();
  cssClass: string = 'content-info';
  htmlTag: string = 'a';
  regex: RegExp = (()=> new RegExp('\\'+this.start+this.scholarlyTag+'\\s(.*?)(s=[a-zA-Z-_]+?)(.*?):(.+?)\\'+this.end+this.scholarlyTag,'g'))();
  render: (scholarlyElementString: string)=>string = (scholarlyElementString: string)=> {
    //creating element
    let element = document.createElement(this.htmlTag);
    let wrapper = document.createElement(this.wrapper);

    //applying element classes
    wrapper.classList.add(this.cssClass);

    //applying attributes
    this.setAttribute(wrapper, this.attributes);

    //applying user defined attributes
    let attributes = this.getScholarlyElementAttributes(scholarlyElementString, this);
    if(attributes)
      this.setAttribute(wrapper, attributes);

    //applying element attributes
    let elementAttributes: KeyValueDictionary<string, string> 
      = new KeyValueDictionary<string, string>({key: 'href', value: '/view/article/'+ wrapper.getAttribute('s')},
      {key: 'target', value: '_blank'});

    this.setAttribute(element,elementAttributes);
    element.innerHTML = this.getScholarlyElementContent(scholarlyElementString, this);
    
    wrapper.innerHTML = element.outerHTML;
    return wrapper.outerHTML;
  };
}
export class ScholarlySection extends ScholarlyElementBase implements IScholarlyElement{
  scholarlyTag: string = 'section';
  wrapper: string = '';
  attributes: KeyValueDictionary<string, string> = new KeyValueDictionary<string, string>(
    {key: 'is-tree-node', value: ''});
  cssClass: string = 'content-section';
  htmlTag: string = 'h2';
  regex: RegExp = (()=>{return new RegExp('\\'+this.start+this.scholarlyTag+'(\\s.+?)?:(.+?)\\'+this.end+this.scholarlyTag, 'g')})();
  render: (scholarlyElementString: string) => string = (scholarlyElementString: string)=>{
    //creating element
    let element = document.createElement(this.htmlTag);

    //applying system attributes
    this.setAttribute(element, this.attributes);

    //applying content to element
    element.innerHTML = this.getScholarlyElementContent(scholarlyElementString, this);

    //applying element classes
    element.classList.add(this.cssClass);

    //applying user defined attributes
    let attributes = this.getScholarlyElementAttributes(scholarlyElementString, this);
    if(attributes)
      this.setAttribute(element, attributes);
    
    return element.outerHTML;
  };
}
export class ScholarlyImage extends ScholarlyElementBase implements IScholarlyElement{
  scholarlyTag: string = 'img';
  wrapper: string = 'div';
  attributes: KeyValueDictionary<string, string> = new KeyValueDictionary<string, string>();
  cssClass: string = 'content-image';
  htmlTag: string = 'img';
  regex: RegExp = (()=> {return new RegExp('\\'+this.start+this.scholarlyTag+'\\s([a-zA-Z]([a-zA-Z0-9_=-]?)*?\\s)?(s=[a-zA-Z]([a-zA-Z0-9_-]?)*?)(\\s[a-zA-Z]([a-zA-Z0-9_=-]?)*?)?:\\'+this.end+this.scholarlyTag, 'g')})();
  render: (scholarlyElementString: string) => string = (scholarlyElementString)=>{
    //creating element
    let element = document.createElement(this.htmlTag)
    let wrapper = document.createElement(this.wrapper);

    //applying element classes
    wrapper.classList.add(this.cssClass);

    //applying attributes
    this.setAttribute(wrapper, this.attributes);

    //applying user defined attributes
    let attributes = this.getScholarlyElementAttributes(scholarlyElementString, this);
    if(attributes)
      this.setAttribute(wrapper, attributes);

    //applying element attributes
    let elementAttributes: KeyValueDictionary<string, string> 
      = new KeyValueDictionary<string, string>({key: 'src', value: wrapper.getAttribute('s') || ''});

    this.setAttribute(element,elementAttributes);
    
    wrapper.innerHTML = element.outerHTML;
    return wrapper.outerHTML;
  };
}
export class Mapper{
  private _scholarlyEncodedString: string
  private _configurations: ScholarlyElements;

  constructor(scholarlyEncodedString: string, scholarlyElementConfiguration: ScholarlyElements){
    this._scholarlyEncodedString = scholarlyEncodedString;
    this._configurations = scholarlyElementConfiguration;
  }

  getHtml(){
    let scholarlyElements: IScholarlyElement[]= this._configurations.getScholarlyElements();

    scholarlyElements.forEach(scholarlyElement=>{
      let matches = this._scholarlyEncodedString.matchAll(scholarlyElement.regex);

      Array.from(matches).forEach(match=>{
        let stringEncodedhtml:string = scholarlyElement.render(match[0]);
        this._scholarlyEncodedString = this._scholarlyEncodedString.replace(match[0], stringEncodedhtml);

      });
    });

    return this._scholarlyEncodedString;
  }
}

class ScholarlyElements{
  getScholarlyElements(): IScholarlyElement[]{
    return [
      new ScholarlyInfo(),
      new ScholarlySection(),
      new ScholarlyImage()
    ];
  }
}

