// import { Contact } from './vehicle';

export interface KeyValuePairModel {
    id: number;
    name: string;
  }
  
  export interface ContactModel {
    name: string;
    phone: string;
    email: string;
  }
  
  export interface VehicleModel {
    id: number;
    model: KeyValuePairModel;
    make: KeyValuePairModel;
    isOwner: boolean;
    features: KeyValuePairModel[];
    contact: ContactModel;
    lastUpdate: string;
    code?: string;
    yearMade: Date;
    color: string;
    transmission: string;
    engineType: string;
    engineSize: string;
    price: string;
  }
  
  export interface SaveVehicleModel {
    id?: number;
    modelId: number;
    makeId?: number;
    IsOwner: boolean;
    features: number[];
    contact: ContactModel;
    code?: string;
    yearMade: Date;
    color: string;
    transmission: string;
    engineType: string;
    engineSize: string;
    price: string;
  
  }
  