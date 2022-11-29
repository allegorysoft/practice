import { ContentProjectionService, PROJECTION_STRATEGY } from "@abp/ng.core";
import { ToasterService } from "@abp/ng.theme.shared";
import { HttpErrorResponse } from "@angular/common/http";
import { Injector } from "@angular/core";
import { throwError } from "rxjs";

export function handleHttpErrors(injector: Injector, httpError: HttpErrorResponse) {
    const toaster = injector.get(ToasterService);

    if (httpError.status === 400) {
        toaster.error(httpError.error?.error?.message || 'Bad request!', '400');
        return;
    }

    if (httpError.status === 401) {
        // const contentProjection = injector.get(ContentProjectionService);
        // contentProjection.projectContent(PROJECTION_STRATEGY.AppendComponentToBody(CustomErrorComponent));
        toaster.error(httpError.error?.message || 'Unauthorized!', '401');
        return;
    }

    if (httpError.status === 404) {
        toaster.error(httpError.error?.message || 'NotFound!', '404');
        return;
    }

    return throwError(httpError);
}
