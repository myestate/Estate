import { Photo } from './photo';

export interface EstateAgent {

    id: number;
    name: string;
    gender: string;
    age: number;
    login: string;
    created: Date;
    lastActive: Date;
    city: string;
    photos: Photo[];

}
