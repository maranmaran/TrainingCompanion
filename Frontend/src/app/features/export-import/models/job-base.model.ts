import { Guid } from 'guid-typescript';

export class JobBase<TEntities> {
  id: Guid;
  type: TEntities;
  active: boolean;

  constructor(type: TEntities) {
    this.type = type;
    this.id = Guid.create();
    this.active = true;
  }
}
