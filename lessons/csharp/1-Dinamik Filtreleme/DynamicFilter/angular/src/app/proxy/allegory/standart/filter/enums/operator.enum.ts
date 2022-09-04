import { mapEnumToOptions } from '@abp/ng.core';

export enum Operator {
  Equals = 0,
  DoesntEquals = 1,
  IsGreaterThan = 2,
  IsGreaterThanOrEqualto = 3,
  IsLessThan = 4,
  IsLessThanOrEqualto = 5,
  IsBetween = 6,
  Contains = 7,
  StartsWith = 8,
  EndsWith = 9,
  IsNull = 10,
  IsNullOrEmpty = 11,
  In = 12,
}

export const operatorOptions = mapEnumToOptions(Operator);
