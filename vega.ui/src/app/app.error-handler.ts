import * as Raven from 'raven-js';
import { ErrorHandler, Inject, isDevMode, NgZone } from '@angular/core';
import { ToastyService } from 'ng2-toasty';

export class AppErrorHandler implements ErrorHandler {
    constructor( @Inject(NgZone) private ngZone: NgZone, @Inject(ToastyService) private toastyService: ToastyService) { }

    handleError(error: any): void {
        this.ngZone.run(() => {
            this.toastyService.error({
                title: 'Error',
                msg: 'An unexprected error happened. ',
                theme: 'material',
                showClose: true,
                timeout: 5000
            });
        });

        if (!isDevMode()) {
            Raven.captureException(error.originalError || error);
        }
        else {
            throw error;
        }
    }
}
