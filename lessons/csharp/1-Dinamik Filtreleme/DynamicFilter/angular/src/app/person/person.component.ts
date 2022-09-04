import {
  ChangeDetectionStrategy,
  ChangeDetectorRef,
  Component,
  OnDestroy,
  ViewChild
} from '@angular/core';

import { Subject } from 'rxjs';
import { finalize, takeUntil } from 'rxjs/operators';

import { ABP } from '@abp/ng.core';

import { Condition } from '@allegorysoft/filter';

import { LazyLoadEvent } from 'primeng/api';
import { Table } from 'primeng/table';

import { Gender, genderOptions } from '@proxy/entities';
import { PersonService } from '@proxy/services';
import {
  FilteredPagedAndSortedResultRequestDto,
  PersonDto
} from '@proxy/services/dtos';

import { getCondition, getOrder } from '../utils/util';

@Component({
  selector: 'app-person',
  templateUrl: './person.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class PersonComponent implements OnDestroy {
  //#region Fields
  private readonly _destroy = new Subject<void>();

  @ViewChild('personDt') table: Table;
  people!: PersonDto[];

  totalRecords!: number;
  pageSizeOptions: number[] = [10, 20, 50, 100, 200];
  pageSize: number = this.pageSizeOptions[0];

  loading: boolean = false;
  genders: ABP.Option<typeof Gender>[] = genderOptions;
  //#endregion

  //#region Utilities
  public get tableConfig(): any {
    return {
      dataKey: 'id',
      lazy: true,
      paginator: true,
      showCurrentPageReport: false,
      sortMode: 'multiple'
    };
  }
  //#endregion

  //#region Ctor
  constructor(
    private readonly personService: PersonService,
    private cdr: ChangeDetectorRef
  ) { }
  //#endregion

  //#region Methods
  getGender(gender: Gender): string {
    switch (gender) {
      case Gender.Male: return 'Erkek'; break;
      case Gender.Female: return 'Kadın'; break;
      default: return 'Belirsiz'; break;
    }
  }

  loadPeople(event: LazyLoadEvent): void {
    this.loading = true;

    this.pageSize = event.rows;

    const conditions = { group: [] } as Condition;

    //#region Filtering
    Object.entries(event.filters).map(prop => {
      if (prop[1].value || prop[1].value === 0) {
        const condition = getCondition(
          prop[0],
          prop[1].matchMode,
          prop[1].value
        );
        conditions.group.push(condition);
      }
    });
    //#endregion

    //#region Sorting
    let sorting = '';

    if (event.multiSortMeta?.length > 0) {
      event.multiSortMeta.map((item, i) => {
        sorting +=
          `${item.field} ` +
          getOrder(item.order) +
          `${(i < event.multiSortMeta.length - 1) ? ', ' : ''}`;
      });
    }
    //#endregion

    const input = {
      maxResultCount: event.rows,
      conditions: conditions.group?.length > 0 ? conditions : undefined,
      skipCount: (event.first ?? 0),
      sorting: sorting
    } as FilteredPagedAndSortedResultRequestDto;

    this.personService.listByInput(input)
      .pipe(
        finalize(() => {
          this.loading = false;
          this.cdr.detectChanges();
        }),
        takeUntil(this._destroy)
      )
      .subscribe(response => {
        this.people = response.items;
        this.totalRecords = response.totalCount;
      });

  }

  clearSort(): void {
    this.table.sortOrder = 0;
    this.table.sortField = '';
    this.table.reset();
  }

  ngOnDestroy(): void {
    this._destroy.next();
    this._destroy.complete();
  }
  //#endregion
}
