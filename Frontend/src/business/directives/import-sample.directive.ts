import { Directive, ElementRef, HostListener, Input, OnInit, Renderer2 } from '@angular/core';
import { FileSaverService } from 'ngx-filesaver';
import { ImportEntities } from 'src/server-models/enums/import-entities.enum';
import { ImportService } from '../services/feature-services/import.service';
import { FileContentResult } from '../shared/file-content-result';


@Directive({
  selector: '[import-sample]'
})
export class ImportSampleDirective implements OnInit {

  @Input()
  sampleType: string;

  @Input()
  importType: ImportEntities;


  public get htmlTemplate(): string {
    return '<mat-card-header>' + this.sampleType + '</mat-card-header>';
  }


  constructor(
    private element: ElementRef,
    private renderer: Renderer2,
    private importService: ImportService,
    private fileSaverService: FileSaverService
  ) {
  }

  ngOnInit() {
    this.renderer.setProperty(this.element.nativeElement, 'innerHTML', this.htmlTemplate);
  }

  @HostListener('click')
  onMouseClick() {
    this.downloadSample();
  }

  downloadSample() {
    this.importService.getSample(this.importType, this.sampleType).subscribe(
      (file: FileContentResult) => {
        console.log(new Blob([file.fileContents], { type: file.contentType }));
        return this.fileSaverService.save(
          new Blob([file.fileContents], { type: file.contentType }),
          file.fileDownloadName
        )
      },
      err => console.log(err)
    );
  }


}
