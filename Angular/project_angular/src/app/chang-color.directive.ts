import { Directive, ElementRef, HostListener } from '@angular/core';

@Directive({
  selector: '[appChangColor]',
  standalone: true
})
export class ChangColorDirective {
  private defaultColor: string = "#C9AB81"; // צבע ברירת מחדל
  private hoverColor: string = "#a78863"; // צבע בעת ריחוף

  constructor(private er: ElementRef) {
    this.er.nativeElement.style.backgroundColor = this.defaultColor;
  }

  @HostListener('mouseenter')
  onMouseEnter() {
    this.er.nativeElement.style.backgroundColor = this.hoverColor;
  }

  @HostListener('mouseleave')
  onMouseLeave() {
    this.er.nativeElement.style.backgroundColor = this.defaultColor; // החזרת צבע ברירת מחדל
  }
}
