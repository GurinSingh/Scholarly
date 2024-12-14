import { Injectable } from '@angular/core';
import { Mapper } from './configurations/mapper';
import { ScholarlyElements } from './configurations/scholarly-elements';


@Injectable({
  providedIn: 'root'
})
export class ScholarlyHTMLMappingService {
  constructor() { }

  public mapToHtml(scholarlyEncodedString: string): string{
    let mapper = new Mapper(scholarlyEncodedString, new ScholarlyElements(scholarlyEncodedString));
    return mapper.getHtml();
  }
}









