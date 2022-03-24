import { useEffect, useState } from "react";
import { useNavigate } from 'react-router-dom';
import { getCustomers, postOrder } from "../common/api.service";
import { CustomerModel } from "../models/customer.model";
import {useLocation} from 'react-router-dom';
import { OrderModel } from "../models/order.model";


function BuyCar() {
    const navigate = useNavigate()
    const [customers, setCustomers] = useState<CustomerModel[]>([])
    const [quantity, setQuantity] = useState(0)
    const [customerId, setCustomerId] = useState(1)
    const [displayAlert, setDisplayAlert] = useState(0)
    const location = useLocation();

    useEffect(()=>{
        getCustomers().then(c => setCustomers(c))
    },[])

    async function handleClick() {
        const order : OrderModel = {
            customerId,
            carOfferId: (location.state as any).id,
            quantity
        }
        let request = await postOrder(order);
        if(request == 400) {
            setDisplayAlert(1);
        } else {
            navigate('/caroffers', { replace: true });
            setDisplayAlert(0);
        }  
    }
    return (
        <>
            {
                displayAlert?
                <div className="alert alert-danger" role="alert">
                    We dont have that many in stock!
                </div> :
                <></>
            }
            <h2>Buy</h2>
            {
                location.state &&(location.state as any).model && (location.state as any).make?
                <>
                    <h1>{(location.state as any).make} {(location.state as any).model}</h1>
                </> :
                <> </>
            }

            <div>
                <div className="mb-3">
                    <label className="form-label">Customer</label>
                    <select className="form-control" placeholder="Name" onChange={ev => setCustomerId(Number(ev.target.value))}>
                        {customers.map(c => <option value={c.id}>{c.name}</option>)}
                    </select>
                </div>
                <div className="mb-3">
                    <label className="form-label">Quantity</label>
                    <input type="number" className="form-control" placeholder="Quantity" onChange={ev => setQuantity(Number(ev.target.value))}/>
                </div>
                <a className="btn btn-primary" onClick={() => handleClick()}>Buy</a>
            </div>
        </>);
}
export default BuyCar