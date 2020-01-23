import { Guid } from 'guid-typescript';

export abstract class JobBase<TEntities> {
  
  id: Guid = Guid.create();
  type: TEntities;
  active: boolean = true;

  constructor(type: TEntities) {
    this.type = type;
  }
}
