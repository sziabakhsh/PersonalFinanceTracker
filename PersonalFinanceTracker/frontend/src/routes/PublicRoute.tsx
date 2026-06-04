import { Navigate, Outlet } from "react-router-dom";
import { useContext } from "react";
import { AccountContext } from "../context/AccountContext";

export default function PublicRoute() {
  const { user } = useContext(AccountContext);

  if (user) {
    return <Navigate to="/" replace />;
  }

  return <Outlet />;
}