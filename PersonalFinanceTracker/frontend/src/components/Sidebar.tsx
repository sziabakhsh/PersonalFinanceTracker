import { NavLink } from "react-router-dom";

export default function Sidebar() {
  return (
    <div
      className="bg-dark text-white p-3"
      style={{ width: "250px", minHeight: "100vh" }}
    >
      <h4 className="mb-4">Finance App</h4>

      <ul className="nav flex-column">
        <li className="nav-item">
          <NavLink className="nav-link text-white" to="/">
            Dashboard
          </NavLink>
        </li>

        <li className="nav-item">
          <NavLink className="nav-link text-white" to="/transactions">
            Transactions
          </NavLink>
        </li>

        <li className="nav-item">
          <NavLink className="nav-link text-white" to="/categories">
            Categories
          </NavLink>
        </li>
      </ul>
    </div>
  );
}