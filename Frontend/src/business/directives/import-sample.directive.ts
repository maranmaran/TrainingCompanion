import { Directive, ElementRef, HostListener, Input, Renderer2, OnChanges, SimpleChanges } from '@angular/core';
import { ImportEntities } from 'src/server-models/enums/import-entities.enum';
import { ImportService } from '../services/feature-services/import.service';
import { FileSaverService } from 'ngx-filesaver';

@Directive({
  selector: '[import-sample]'
})
export class ImportSampleDirective {

  @Input()
  sampleType: string;
  
  @Input()
  importType: ImportEntities;

  constructor(
    private element: ElementRef,
    private renderer: Renderer2,
    private importService: ImportService,
    private fileSaverService: FileSaverService
  ) {
    //   this.element.nativeElement.va

    
  }


  @HostListener('click')
  onMouseClick() {
    this.downloadSample();
  }

  downloadSample() {
    //   this.importService.getSample(
    //       (file) => {
    //           console.log(file);
    //         //   this.fileSaverService.save();
    //       },
    //       err => console.log(err)
    //   );
  }


}