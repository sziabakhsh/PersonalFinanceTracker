import { Link, useNavigate } from "react-router-dom";
import { useContext } from "react";
import { AccountContext } from "../context/AccountContext";

export default function Nav() {
  const { user, logout } = useContext(AccountContext);
  const navigate = useNavigate();

  const handleLogout = () => {
    logout();
    navigate("/login");
  };

  return (
    <div className="bg-dark text-white p-3" style={{ width: "250px" }}>
      <h5>Finance App</h5>

      <div className="d-flex flex-column gap-2 mt-3">
        <Link to="/" className="text-white">Dashboard</Link>
        <Link to="/transactions" className="text-white">Transactions</Link>
        <Link to="/categories" className="text-white">Categories</Link>
      </div>

      <hr />

        {!user?.token ? (
    <div className="d-flex flex-column gap-2">
      <Link to="/login" className="text-white">Login</Link>
      <Link to="/register" className="text-white">Register</Link>
    </div>
  ) : (
    <div className="d-flex flex-column gap-2">
      <span className="text-success">👤 {user.fullName}</span>
      <button className="btn btn-danger btn-sm" onClick={logout}>
        Logout
      </button>
    </div>
  )}



    </div>
  );
}
