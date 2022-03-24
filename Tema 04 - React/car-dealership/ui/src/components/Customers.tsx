import { useEffect, useState } from "react";
import { getCustomers } from "../common/api.service";
import { CustomerModel } from "../models/customer.model";
import Customer from "./Customer";
import { useNavigate } from 'react-router-dom';

function Customers() {
    const [customers, setCustomers] = useState<CustomerModel[]>([])
    const navigate = useNavigate()

    useEffect(()=>{
        getCustomers().then(c => setCustomers(c))
    },[])

    function handleAddCustomerClick() {
        navigate('/newcustomer')
    }

    return (<div>
        <h2>Customers</h2>
        <a className="btn btn-primary" onClick={() => handleAddCustomerClick()}>Add customer</a>
        <div></div>
        <table className="table">
            <thead>
                <tr>
                    <th scope="col">Name</th>
                    <th scope="col">Email</th>
            </tr>
            </thead>
            <tbody>
                {customers.map(c => <Customer customer={c} />)}
            </tbody>
        </table>
    </div>);
}

export default Customers;