import { Directive, ElementRef, Renderer2, Input, AfterViewInit, OnDestroy } from '@angular/core';

@Directive({
  selector: '[pageNavigationTarget]',
  standalone: true
})
export class PageNavigationRendererDirective implements AfterViewInit, OnDestroy {
  private mutationObserver!: MutationObserver;
  
  constructor(private elementRef: ElementRef, private renderer: Renderer2) { }

  ngAfterViewInit(): void {
    this.mutationObserver = new MutationObserver((mutations)=>{
      mutations.forEach((mutation)=>{
        if((mutation.addedNodes.length > 0 && Array.from(mutation.addedNodes).every((n:any) => n.classList.contains('popover')))
          || (mutation.removedNodes.length > 0 && Array.from(mutation.removedNodes).every((n:any) => n.classList.contains('popover'))))
          return;

        if(mutation.type == 'childList' || mutation.type == 'characterData')
          this._updateTree(this.elementRef.nativeElement.innerHTML);
      });
    });

    this.mutationObserver.observe(this.elementRef.nativeElement, {
      childList: true
    })
  }
  ngOnDestroy(): void {
    if(this.mutationObserver)
      this.mutationObserver.disconnect();
  }

  private _updateTree(targetContent: string){
    let nodes = this.elementRef.nativeElement.querySelectorAll('[is-tree-node]');
    let container:any = document.getElementById('pageNavigationNodes');
    container.classList.add('list-group', 'list-group-horizontal', 'list-group-flush');
    container.innerHTML = '';

    nodes.forEach((node:any)=>{
      let button = this.renderer.createElement('button');
      button.innerHTML = node.innerHTML;
      button.classList.add('list-group-item', 'list-group-item-action');
      button.addEventListener('click', ()=>{
        node.scrollIntoView({ behavior: 'smooth', block: 'start' });
      });
      container.append(button);
    });
  }
}
