import { Condition } from "@allegorysoft/filter";
import * as moment from 'moment';

export function toPascalCase(value) {
    return `${value}`
        .replace(new RegExp(/[-_]+/, 'g'), ' ')
        .replace(new RegExp(/[^\w\s]/, 'g'), '')
        .replace(
            new RegExp(/\s+(.)(\w*)/, 'g'),
            ($1, $2, $3) => `${$2.toUpperCase() + $3.toLowerCase()}`
        )
        .replace(new RegExp(/\w/), s => s.toUpperCase());
}

export function getOrder(sortOrder: number): string {
    return sortOrder === -1 ? 'desc' : 'asc'
}

export function getCondition(
    column: string,
    matchMode: string,
    value: any
): Condition {
    let not = false;

    if (value instanceof Date) {
        value = moment(value).format('YYYY-MM-DD');
    }

    switch (matchMode) {
        case 'notEquals': matchMode = 'DoesntEquals'; break;
        case 'lt': matchMode = 'IsLessThan'; break;
        case 'lte': matchMode = 'IsLessThanOrEqualto'; break;
        case 'gt': matchMode = 'IsGreaterThan'; break;
        case 'gte': matchMode = 'IsGreaterThanOrEqualto'; break;
        case 'notContains': matchMode = 'Contains'; not = true; break;
        case 'dateIs': matchMode = 'Equals'; break;
        case 'dateIsNot': matchMode = 'DoesntEquals'; break;
        case 'dateBefore': matchMode = 'IsLessThan'; break;
        case 'dateAfter': matchMode = 'IsGreaterThan'; break;
    }

    const condition = {
        column: toPascalCase(column),
        operator: <any>toPascalCase(matchMode),
        value: value,
        not: not
    } as Condition;

    return condition;
}
