import { APP_CONSTANTS } from "../../../../constants/APP_CONSTANTS";
import { KeyValueDictionary } from "../../../../utilities/keyValuePairDictionary";
import { IScholarlyElement } from "../IScholarlyElements";
import { ScholarlyElementBase } from "../scholarly-element-base";

export class ScholarlyImage extends ScholarlyElementBase implements IScholarlyElement{
    scholarlyTag: string = 'img';
    wrapper: string = 'div';
    attributes: KeyValueDictionary<string, string> = new KeyValueDictionary<string, string>();
    cssClass: string = 'content-image';
    htmlTag: string = 'img';
    regex: RegExp = (()=> {return new RegExp('\\'+this.start+this.scholarlyTag+'\\s([a-zA-Z]([a-zA-Z0-9_=-]?)*?\\s)*?(s=[a-zA-Z]([a-zA-Z0-9_-]?)*?)(\\s[a-zA-Z]([a-zA-Z0-9_=-]?)*?)*?:\\'+this.end+this.scholarlyTag, 'g')})();
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
        = new KeyValueDictionary<string, string>({key: 'src', value: wrapper.getAttribute(APP_CONSTANTS.ARTICLE_IMAGE_SELECTOR_ATTR) || ''});
  
      this.setAttribute(element,elementAttributes);
      
      wrapper.innerHTML = element.outerHTML;
      return wrapper.outerHTML;
    };
  }