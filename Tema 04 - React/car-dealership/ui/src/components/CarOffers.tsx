import { useEffect, useState } from "react";
import { getCars } from "../common/api.service";
import { CarModel } from "../models/car.model";
import Car from "./Car";

//1. Props change
//2. State change

function CarOffers() {
    const [cars, setCars] = useState<CarModel[]>([]);

    useEffect(()=>{
        getCars().then(c => setCars(c));
    },[])

    return (
    <div>
        <h2>All cars</h2>
        <div></div>
        <div style={{display:'flex', flexWrap:'wrap'}}>
            {cars.map(c => <Car car={c} />)}
        </div>
    </div>);
}

export default CarOffers;