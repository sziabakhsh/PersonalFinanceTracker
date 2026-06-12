import { Outlet } from "react-router-dom";
import Nav from "../Shared/components/Nav";

export default function AppLayout() {
  return (
    <div className="d-flex">
      <Nav />

      <div className="flex-grow-1 p-3 bg-light min-vh-100">
        <Outlet />
      </div>
    </div>
  );
}
