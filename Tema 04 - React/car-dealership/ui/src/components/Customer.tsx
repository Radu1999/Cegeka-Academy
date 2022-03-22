import { CustomerModel } from "../models/customer.model";

interface TProps{
    customer: CustomerModel;
}

function Customer(props: TProps){ 
    return (
        <div>
            <h1>BRO</h1>
        </div>
    )
}

export default Customer;