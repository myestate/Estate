import { User } from './user';
import { Photo } from './photo';

export interface Estate {
    id: number;
    title: string;
    description: string;
    price: number;
    owner: User;
    square: number;
    rooms: number;
    floors: number;
    country: string;
    city: string;
    street: string;
    photos: Photo[];
    created: Date;
    isActive: Boolean;
}
