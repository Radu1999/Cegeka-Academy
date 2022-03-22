import { CarModel } from "../models/car.model";

export function getCars(): Promise<CarModel[]> {
    return fetch('https://localhost:7198/CarOffer')
        .then(r => r.json())
}

export async function postCar(car: CarModel): Promise<any> {
    return fetch('https://localhost:7198/CarOffer', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(car)
    }).then(r => r.json()).then(data => {return data});
}