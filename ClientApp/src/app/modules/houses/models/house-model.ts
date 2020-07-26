export interface KeyValuePairModel {
    id: number;
    name: string;
  }
  
  export interface ContactModel {
    name: string;
    phone: string;
    email: string;
  }
export interface HouseModel {
    id: number;
    city: KeyValuePairModel;
    location: KeyValuePairModel;
    isOwner: boolean;
    contact: ContactModel;
    lastUpdate: string;
    code?: string;
    title: string;
    description: string;
    category: string;
    propertyFor: string;
    price: string;
    bedrooms: number;
    bathrooms: number;
    area: string;
    noFloors: number;
    Built: string;
}
export interface SaveHouseModel {
    id: number;
    cityId: number;
    locationId: number;
    isOwner: boolean;
    contact: ContactModel;
    code?: string;
    title: string;
    description: string;
    category: string;
    propertyFor: string;
    price: string;
    bedrooms: number;
    bathrooms: number;
    area: string;
    noFloors: number;
    Built: string;

}
