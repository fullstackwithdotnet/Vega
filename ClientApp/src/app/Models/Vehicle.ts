
export interface KeyValuePair {
    id: number;
    name: string;
}

export interface Contact {
    name: string;
    phone: string;
    email: string;
}


export interface Vehicle {
    id: number;
    make: KeyValuePair;
    model: KeyValuePair;
    isRegistered: boolean;
    contact: Contact;
    features: KeyValuePair[];
}

export interface SaveVehicle {
    id: number;
    makeId: number;
    modelId: number;
    isRegistered: boolean;
    contact: Contact;
    features: number[];
}
