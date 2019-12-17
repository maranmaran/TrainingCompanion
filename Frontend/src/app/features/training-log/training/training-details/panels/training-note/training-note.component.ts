import { Component, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { MatExpansionPanel } from '@angular/material/expansion';
import { ChangeEvent } from '@ckeditor/ckeditor5-angular';
import * as ClassicEditor from '@ckeditor/ckeditor5-build-classic';

@Component({
  selector: 'app-training-note',
  templateUrl: './training-note.component.html',
  styleUrls: ['./training-note.component.scss']
})
export class TrainingNoteComponent implements OnInit {

  @Input() note: string = '';
  @Input() coachNote: string = '';
  @Input() noteRead: boolean;
  @Input() showEditor: boolean = false;
  @Output() saveNoteEvent = new EventEmitter<string>();

  protected panelExpanded = false;
  protected ckEditor = ClassicEditor;
  protected ckEditorConfig = {
      toolbar: ['bold', 'link', 'bulletedList', 'undo', 'redo', 'insertTable', 'ImageUpload', 'MediaEmbed']
  };

  @ViewChild("notePanel", { static: false }) panel: MatExpansionPanel;

  constructor() { }

  ngOnInit() {
    this.ckEditor.note = this.note;
  }

  onChange( { editor }: ChangeEvent ) {
    this.note = editor.getData();
  }

  openCoachNoteEditor() {
    this.ckEditor.note = this.note;
    this.showEditor = true;
  }

  openUserNoteEditor() {
    this.ckEditor.note = this.coachNote;
    this.showEditor = true;
  }

  saveNote() {
    this.saveNoteEvent.emit(this.note);
    this.showEditor = false;
  }

}
