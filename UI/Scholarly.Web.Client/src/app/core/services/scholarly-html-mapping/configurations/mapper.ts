import { IScholarlyElement } from "./IScholarlyElements";
import { ScholarlyElements } from "./scholarly-elements";

export class Mapper{
    private _scholarlyEncodedString: string
    private _scholarlyElements: ScholarlyElements;
  
    constructor(scholarlyEncodedString: string, scholarlyElements: ScholarlyElements){
      this._scholarlyEncodedString = scholarlyEncodedString;
      this._scholarlyElements = scholarlyElements;
    }
  
    getHtml(){
      let scholarlyElementTypes: IScholarlyElement[]= this._scholarlyElements.getScholarlyElements();
      
      scholarlyElementTypes.forEach((elementType: IScholarlyElement)=>{
        elementType.getAll().forEach((scholarlyElement: string)=> {
          let stringEncodedhtml:string = elementType.render(scholarlyElement);
          this._scholarlyEncodedString = this._scholarlyEncodedString.replace(scholarlyElement, stringEncodedhtml);
        });
      });
  
      return this._scholarlyEncodedString;
    }
  }