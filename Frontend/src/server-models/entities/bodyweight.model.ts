import { ApplicationUser } from 'src/server-models/entities/application-user.model';
export class Bodyweight {
  id: string;
  value: number;
  date: Date;

  userId: string;
  user: ApplicationUser
}
