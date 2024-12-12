import { APP_CONSTANTS } from "../../../../constants/APP_CONSTANTS";
import { APP_SUB_ROUTES } from "../../../../constants/APP_ROUTES";
import { KeyValueDictionary } from "../../../../utilities/keyValuePairDictionary";
import { IScholarlyElement } from "../IScholarlyElements";
import { ScholarlyElementBase } from "../scholarly-element-base";

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
        = new KeyValueDictionary<string, string>({key: 'href', value: APP_SUB_ROUTES.VIEW_ARTICLE.FULL+'/'+ wrapper.getAttribute(APP_CONSTANTS.ARTICLE_SELECTOR_ATTR)},
        {key: 'target', value: '_blank'});
  
      this.setAttribute(element,elementAttributes);
      element.innerHTML = this.getScholarlyElementContent(scholarlyElementString, this);
      
      wrapper.innerHTML = element.outerHTML;
      return wrapper.outerHTML;
    };
  }