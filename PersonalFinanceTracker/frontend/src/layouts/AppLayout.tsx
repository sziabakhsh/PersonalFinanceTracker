import { Outlet } from "react-router-dom";
import Nav from "../components/Nav";

export default function AppLayout() {
  return (
    <div className="d-flex">
      <Nav />

      <div className="flex-grow-1">
        <div className="p-3">
          <Outlet />
        </div>
      </div>
    </div>
  );
}