import { User } from './user';
import { Photo } from './photo';
import { Location } from './geocode_data';

export class Estate {
    id: number;
    title: string;
    description: string;
    price: number;
    ownerId: number;
    square: number;
    rooms: number;
    floors: number;
    country: string;
    city: string;
    street: string;
    photos: Photo[];
    created: Date;
    isActive: Boolean;
    location: Location;
}
