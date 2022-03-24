import { useState } from "react";
import { postCustomer } from "../common/api.service";
import { CustomerModel } from "../models/customer.model";
import { useNavigate } from 'react-router-dom';

function NewCustomer() {
    const [name, setName] = useState('')
    const [email, setEmail] = useState('')
    const navigate = useNavigate()

    async function handleClick() {
        const customer: CustomerModel = {
            name,
            email
        }
        let resp = await postCustomer(customer);
        navigate('/customers', { replace: true });  
    }
    return (
        <>
            <h2>New Customer</h2>
            <div>
                <div className="mb-3">
                    <label className="form-label">Name</label>
                    <input type="text" className="form-control" placeholder="Name" onChange={ev => setName(ev.target.value)} />
                </div>
                <div className="mb-3">
                    <label className="form-label">Email</label>
                    <input type="text" className="form-control" placeholder="Email" onChange={ev => setEmail(ev.target.value)}/>
                </div>
                <a className="btn btn-primary" onClick={() => handleClick()}>Save</a>
            </div>
        </>);
}
export default NewCustomer