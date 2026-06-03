import { Navigate } from "react-router-dom";
import { useContext } from "react";
import { AccountContext } from "../context/AccountContext";

export function PublicRoute({ children }) {
  const { user } = useContext(AccountContext);

  if (user) {
    return <Navigate to="/" replace />;
  }

  return children;
}