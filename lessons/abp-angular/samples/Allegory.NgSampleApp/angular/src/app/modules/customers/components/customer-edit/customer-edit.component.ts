import { Component, Injector, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { UntypedFormGroup } from '@angular/forms';
import {
  EXTENSIONS_IDENTIFIER, FormPropData, generateFormFromProps
} from '@abp/ng.theme.shared/extensions';
import { eCustomersComponents } from '../../enums';
import { CustomerDto } from '../../models/customer';

@Component({
  selector: 'app-customer-edit',
  templateUrl: './customer-edit.component.html',
  styles: [`
    .mr-1{
      margin-right:.5rem;
    }
  `],
  providers: [
    {
      provide: EXTENSIONS_IDENTIFIER,
      useValue: eCustomersComponents.CustomerEdit,
    },
  ]
})
export class CustomerEditComponent implements OnInit {
  form!: UntypedFormGroup;
  selected: CustomerDto;

  private buildForm(): void {
    const data = new FormPropData(this.injector, this.selected);
    this.form = generateFormFromProps(data);
  }

  constructor(
    private injector: Injector,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    const id = <string>this.route.snapshot.params.id;
    id ? this.edit(id) : this.add();
  }

  add(): void {
    this.selected = {} as CustomerDto;
    this.buildForm();
  }

  edit(id: string): void {
    this.selected = {
      id: id,
      identityNumber: '12345678901',
      name: 'Masum',
      surname: 'ULU',
      gender: 1,
    };
    this.buildForm();
  }

  save(): void {
    const { id } = this.selected;
    console.log(`id: ${id}`, this.form.value);
  }
}
