import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WriteContentComponent } from './write-content.component';

describe('WriteContentComponent', () => {
  let component: WriteContentComponent;
  let fixture: ComponentFixture<WriteContentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [WriteContentComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(WriteContentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
