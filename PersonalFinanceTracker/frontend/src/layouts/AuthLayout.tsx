import { Outlet } from "react-router-dom";

export default function AuthLayout() {
  return (
    <div className="d-flex justify-content-center align-items-center vh-100 bg-light">
      <div className="card p-4 shadow" style={{ width: "400px" }}>
        <Outlet />
      </div>
    </div>
  );
}