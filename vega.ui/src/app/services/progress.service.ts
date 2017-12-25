import { Injectable } from '@angular/core';
import { BrowserXhr } from '@angular/http';
import { Subject } from 'rxjs/Subject';

@Injectable()
export class ProgressService {
  private uploadProgress: Subject<any>;

  startTracking() {
    console.log('startTracking');
    this.uploadProgress = new Subject();
    return this.uploadProgress;
  }

  notify(progress) {
    console.log('notify');
    this.uploadProgress.next(progress);
  }

  endTracking() {
    console.log('endTracking');
    this.uploadProgress.complete();
  }
}

@Injectable()
export class BrowserXhrWithProgress extends BrowserXhr {

  constructor(private service: ProgressService) { super(); }

  build(): XMLHttpRequest {
    const xhr: XMLHttpRequest = super.build();

    xhr.upload.onprogress = (event) => {
      console.log('Upload progress..');
      this.service.notify(this.createProgress(event));
    };

    xhr.upload.onloadend = () => {
      this.service.endTracking();
    };

    return xhr;
  }

  private createProgress(event) {
    return {
      total: event.total,
      percentage: Math.round(event.loaded / event.total * 100)
    };
  }
}
