import { Pipe, PipeTransform } from '@angular/core';
import { Urun } from '../models/urun';

@Pipe({
  name: 'filterPipe'
})
export class FilterPipePipe implements PipeTransform {

  transform(value: Urun[], filterText:string): Urun[] {
    filterText=filterText?filterText.toLocaleLowerCase():""
    return filterText?value.filter((p:Urun)=>p.urunAdi.toLocaleLowerCase().indexOf(filterText)!==-1):value;
  }

}
