import { useEffect, useState } from "react";
import { getCustomers } from "../common/api.service";
import { CustomerModel } from "../models/customer.model";
import Customer from "./Customer";

function Customers() {
    const [customers, setCustomers] = useState<CustomerModel[]>([]);

    useEffect(()=>{
        getCustomers().then(c => setCustomers(c));
    },[])

    return (<div>
        <h2>Customers</h2>
        <div></div>
        <div style={{display:'flex', flexWrap:'wrap'}}>
            {customers.map(c => <Customer customer={c} />)}
        </div>
    </div>);
}

export default Customers;