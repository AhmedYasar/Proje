import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EventService {

  constructor() { }
  private sepetGuncellendi = new Subject<void>();

  sepetGuncellendi$ = this.sepetGuncellendi.asObservable();

  triggerSepetGuncellendi() {
    this.sepetGuncellendi.next();
  }
}
