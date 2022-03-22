import '../App.css';
import {
    Routes,
    Route,
    Outlet,
    Link,
    useMatch,
    useResolvedPath,
} from "react-router-dom";

function NavLink(props) {
    const { to, children } = props;
    let resolved = useResolvedPath(to);
    let match = useMatch({ path: resolved.pathname, end: true });
    let itemClass = "list-group-item list-group-item-action" + (match ? ' active' : '');
    return (
        <Link className={itemClass} to={to} {...props} >
            {children}
        </Link>
    );
}

export function NavigationBar() {
    return (
        <div className='navigation-bar'>
            <div className='list-group'>
                <NavLink to='/' >Home</NavLink>
                <NavLink to='/customers' >Customers</NavLink>
                <NavLink to='/caroffers' >Cars</NavLink>
            </div>
        </div>);
}
