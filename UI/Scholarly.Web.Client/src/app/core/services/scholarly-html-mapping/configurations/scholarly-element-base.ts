import { KeyValueDictionary } from "../../../utilities/keyValuePairDictionary";
import { IScholarlyElement } from "./IScholarlyElements";

export class ScholarlyElementBase{
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