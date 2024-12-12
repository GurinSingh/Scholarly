import { KeyValueDictionary } from "../../../utilities/keyValuePairDictionary";

export interface IScholarlyElement{
    htmlTag: string;
    scholarlyTag: string;
    wrapper: string;
    attributes: KeyValueDictionary<string, string>;
    cssClass: string;
    regex: RegExp
    render: (ScholarlyElementString: string)=> string;
  }