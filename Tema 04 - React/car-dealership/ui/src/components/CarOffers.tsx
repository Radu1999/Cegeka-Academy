import { useEffect, useState } from "react";
import { getCars } from "../common/api.service";
import { CarModel } from "../models/car.model";
import Car from "./Car";
import { useNavigate } from 'react-router-dom';

//1. Props change
//2. State change

function CarOffers() {
    const [cars, setCars] = useState<CarModel[]>([]);
    const navigate = useNavigate();

    useEffect(()=>{
        getCars().then(c => setCars(c));
    },[])

    function handleAddCarClick() {
        navigate('/newcar');
    }

    return (
    <div>
        <h2>All cars</h2>
        <a className="btn btn-primary" onClick={() => handleAddCarClick()}>Add new car</a>
        <div></div>
        <div style={{display:'flex', flexWrap:'wrap'}}>
            {cars.map(c => <Car car={c} />)}
        </div>
    </div>);
}

export default CarOffers;