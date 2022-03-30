import { useLocation } from "react-router-dom";
import { CustomerModel } from "../models/customer.model";

export default function CustomerDetails() {
    const {state} = useLocation();
   
    if(!state || !(state as any).customer) {
        return (
            <h1>Bad access</h1>
        )
    }
    const customer : CustomerModel = (state as any).customer;
    return (<div>
        <h3>{customer.name}</h3>
        <h5>{customer.email}</h5>
        

        
    </div>);
}