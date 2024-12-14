import { ScholarlyImage } from "./elements/scholarly-image";
import { ScholarlyInfo } from "./elements/scholarly-info";
import { ScholarlySection } from "./elements/scholarly-section";
import { IScholarlyElement } from "./IScholarlyElements";

export class ScholarlyElements{
  private _scholarlyEncodedString: string;
  constructor(scholarlyEncodedString: string) {
    this._scholarlyEncodedString = scholarlyEncodedString;
  }

  getScholarlyElements(): IScholarlyElement[]{
    return [
      new ScholarlyInfo(this._scholarlyEncodedString),
      new ScholarlySection(this._scholarlyEncodedString),
      new ScholarlyImage(this._scholarlyEncodedString)
    ];
  }
}