import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProdutoEdicaoComponent } from './produto-edicao.component';

describe('ProdutoEdicaoComponent', () => {
  let component: ProdutoEdicaoComponent;
  let fixture: ComponentFixture<ProdutoEdicaoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProdutoEdicaoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProdutoEdicaoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
