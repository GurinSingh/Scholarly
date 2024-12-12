import { ScholarlyImage } from "./elements/scholarly-image";
import { ScholarlyInfo } from "./elements/scholarly-info";
import { ScholarlySection } from "./elements/scholarly-section";
import { IScholarlyElement } from "./IScholarlyElements";

export class ScholarlyElements{
    getScholarlyElements(): IScholarlyElement[]{
      return [
        new ScholarlyInfo(),
        new ScholarlySection(),
        new ScholarlyImage()
      ];
    }
  }