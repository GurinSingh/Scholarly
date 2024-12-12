import { IScholarlyElement } from "./IScholarlyElements";
import { ScholarlyElements } from "./scholarly-elements";

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