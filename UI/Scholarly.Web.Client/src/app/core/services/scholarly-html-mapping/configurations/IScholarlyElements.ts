import { KeyValueDictionary } from "../../../utilities/keyValuePairDictionary";

export interface IScholarlyElement{
    readonly htmlTag: string;
    readonly scholarlyTag: string;
    readonly wrapper: string;
    readonly attributes: KeyValueDictionary<string, string>;
    readonly cssClass: string;
    readonly getAll: ()=> string[];
    readonly render: (ScholarlyElementString: string)=> string;
  }