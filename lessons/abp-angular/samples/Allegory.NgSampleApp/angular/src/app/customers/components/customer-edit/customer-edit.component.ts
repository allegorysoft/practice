import { EXTENSIONS_IDENTIFIER, FormPropData, generateFormFromProps } from '@abp/ng.theme.shared/extensions';
import { Component, Injector, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { eCustomersComponents } from '../../enums';
import { CustomerDto } from '../../models/customer';

@Component({
  selector: 'app-customer-edit',
  templateUrl: './customer-edit.component.html',
  providers: [
    {
      provide: EXTENSIONS_IDENTIFIER,
      useValue: eCustomersComponents.CustomerEdit,
    },
  ]
})
export class CustomerEditComponent implements OnInit {
  form!: FormGroup;
  selected!: CustomerDto;

  private buildForm(): void {
    const data = new FormPropData(this.injector, this.selected);
    this.form = generateFormFromProps(data);
  }

  constructor(
    private injector: Injector,
    private route: ActivatedRoute
  ) { }

  ngOnInit(): void {
    const id = <string>this.route.snapshot.params.id;
    if (id)
      this.edit(id);
    else
      this.add();
  }

  add(): void {
    this.selected = {} as CustomerDto;
    this.buildForm();
  }

  edit(id: string): void {
    this.selected = {
      id: id,
      name: 'Masum',
      surname: 'ULU',
      gender: 1,
    };
    this.buildForm();
  }

  save(): void {
    if (!this.form.valid) return;
    const { id } = this.selected;
    console.log(`id: ${id}`, this.form.value);
  }
}
