import { APP_CONSTANTS } from "../../../../constants/APP_CONSTANTS";
import { KeyValueDictionary } from "../../../../utilities/keyValuePairDictionary";
import { IScholarlyElement } from "../IScholarlyElements";
import { ScholarlyElementBase } from "../scholarly-element-base";

export class ScholarlySection extends ScholarlyElementBase implements IScholarlyElement{
    scholarlyTag: string = 'section';
    wrapper: string = '';
    attributes: KeyValueDictionary<string, string> = new KeyValueDictionary<string, string>(
      {key: APP_CONSTANTS.PAGE_NAVIGATION_NODE_ATTR, value: ''});
    cssClass: string = 'content-section';
    htmlTag: string = 'h4';
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