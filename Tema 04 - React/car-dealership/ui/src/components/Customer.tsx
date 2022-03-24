import { CustomerModel } from "../models/customer.model";

interface TProps{
    customer: CustomerModel;
}

function Customer(props: TProps){ 

    const { customer } = props;

    return (

        <tr>
            <td>{customer.name}</td>
            <td>{customer.email}</td>
        </tr>
    )
}

export default Customer;