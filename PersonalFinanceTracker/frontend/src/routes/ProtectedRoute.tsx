import { Navigate, Outlet, useLocation } from "react-router-dom";
import { useContext } from "react";
import { AccountContext } from "../context/AccountContext";

export default function ProtectedRoute() {
  const { user } = useContext(AccountContext);
  const location = useLocation();

  if (!user) {
    return (
      <Navigate
        to="/login"
        replace
        state={{ from: location }}
      />
    );
  }

  return <Outlet />;
}