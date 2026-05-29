import {Link} from 'react-router-dom'
import { useContext } from 'react'
import { AccountContext } from '../context/AccountContext'

export default function Nav() {
    const {user, logout} = useContext(AccountContext)

  return (
    <nav>
        <Link to="/" >Dashboard</Link> | 
        {!user? (<Link to="/login" >Login</Link> ):
        (<button onClick={logout} >Logout</button>)
        } |
        <Link to="/register" >Register</Link> | 
        <Link to="/transactions" >Transactions</Link> | 
        <Link to="/categories" >Categories</Link> | 
    </nav>
  )
}
