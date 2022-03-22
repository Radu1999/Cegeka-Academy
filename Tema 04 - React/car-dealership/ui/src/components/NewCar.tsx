import { useState } from "react";
import { postCar } from "../common/api.service";
import { CarModel } from "../models/car.model";

function NewCar() {

    const [make, setMake] = useState('');
    const [model, setModel] = useState('');
    const [availableStock, setAvailableStock] = useState(0);
    const [unitPrice, setUnitPrice] = useState(0);

    function handleClick(): void {
        const car:CarModel = {
            make,
            model,
            availableStock,
            unitPrice,
            discountPercentage:0,
            image:''
        };
        postCar(car);
    }

    return (
        <>
            <h2>New Car</h2>
            <div>
                <div className="mb-3">
                    <label className="form-label">Make</label>
                    <input type="text" className="form-control" placeholder="Make" onChange={ev => setMake(ev.target.value)} />
                </div>
                <div className="mb-3">
                    <label className="form-label">Model</label>
                    <input type="text" className="form-control" placeholder="Model" onChange={ev => setModel(ev.target.value)}/>
                </div>
                <div className="mb-3">
                    <label className="form-label">Stock</label>
                    <input type="number" className="form-control" placeholder="Stock" onChange={ev => setAvailableStock(Number(ev.target.value))}/>
                </div>
                <div className="mb-3">
                    <label className="form-label">Price</label>
                    <input type="number" className="form-control" placeholder="Price" onChange={ev => setUnitPrice(Number(ev.target.value))}/>
                </div>
                <a href="#" className="btn btn-primary" onClick={() => handleClick()}>Save</a>
            </div>
        </>);
}

export default NewCar;


