import { useNavigate } from "react-router-dom";
import { CustomerModel } from "../models/customer.model";

interface TProps{
    customer: CustomerModel;
}

function Customer(props: TProps){ 

    const { customer } = props;
    const navigate = useNavigate()
    function handleClick() {
        navigate(`/customers/${customer.id}`, {state:{customer: customer}})
    }
    return (

        <tr>
            <td>
                <button className="badge alert-success" onClick={()=>{handleClick()}}>{customer.name}</button>          
            </td>
            <td>{customer.email}</td>
        </tr>
    )
}

export default Customer;