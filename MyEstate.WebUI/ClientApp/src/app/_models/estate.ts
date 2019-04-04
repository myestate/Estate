import { Photo } from './photo';
import { User } from './user';

export interface Estate {
  Id: number;
  Title: string;
  Description: string;
  Price: number;
  Owner: User;
  double: number;
  Rooms: number;
  Floors: number;
  Country: string;
  City: string;
  Street: string;
  Photos: Photo[];
  Created: Date;
  IsActive: Boolean;
}
