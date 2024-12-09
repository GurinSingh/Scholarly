import { Directive, Input } from '@angular/core';

@Directive({
  selector: '[articleInfoPopover]',
  standalone: true
})
export class ArticleInfoPopoverDirective {
  @Input('mapToHtml') scholarlyEncodedString!: string;

  constructor() { }

}
