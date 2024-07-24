import { DOCUMENT } from "@angular/common";
import { AfterViewInit, Directive, ElementRef, EventEmitter, Inject, OnDestroy, Output } from "@angular/core";
import { Subscription, filter, fromEvent } from "rxjs";

@Directive({
    selector: '[clickOutside]',
    standalone: true
})
export class clickOutsideDirective implements AfterViewInit, OnDestroy
{
  @Output() clickOutside = new EventEmitter<void>();
  constructor(private element: ElementRef, @Inject(DOCUMENT) private document: Document)
  {
  }

  documentClickSubscription: Subscription | undefined;
 ngAfterViewInit(): void {
    // Subscribe to document click events
    this.documentClickSubscription = fromEvent(this.document, 'click').pipe(
      filter((event: Event) => {
        return !this.isInside(event.target as HTMLElement);
      })
    ).subscribe(() => {
      this.clickOutside.emit();
    });
  }

  ngOnDestroy(): void {
    this.documentClickSubscription?.unsubscribe();
  }

  isInside(elementToCheck: HTMLElement): boolean
  {
    return elementToCheck === this.element.nativeElement ||
    this.element.nativeElement.contains(elementToCheck);
  }
}
