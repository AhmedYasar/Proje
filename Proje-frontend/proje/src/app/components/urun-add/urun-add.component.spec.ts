import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UrunAddComponent } from './urun-add.component';

describe('UrunAddComponent', () => {
  let component: UrunAddComponent;
  let fixture: ComponentFixture<UrunAddComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [UrunAddComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(UrunAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
