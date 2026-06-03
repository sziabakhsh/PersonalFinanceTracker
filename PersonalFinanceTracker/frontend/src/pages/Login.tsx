import { useForm } from "react-hook-form";
import { useLogin } from "../hooks/useLogin";
import { useContext } from "react";
import { AccountContext } from "../context/AccountContext";
import {Link, useNavigate, useLocation } from "react-router-dom";

export default function Login() {
  const { login } = useContext(AccountContext);
  const navigate = useNavigate();
  const location = useLocation();

  const { mutate, isPending, error } = useLogin();

  const from = location.state?.from?.pathname || "/";

  const { register, handleSubmit } = useForm();

  const onSubmit = (data) => {
    mutate(data, {
      onSuccess: (res) => {
        login(res);
        navigate(from, { replace: true });
      },
    });
  };

  return (
    <form onSubmit={handleSubmit(onSubmit)}>
      <h3 className="mb-3">Login</h3>

      <input
        className="form-control mb-2"
        placeholder="Email"
        {...register("email")}
      />

      <input
        className="form-control mb-3"
        type="password"
        placeholder="Password"
        {...register("password")}
      />

      <button className="btn btn-primary w-100" disabled={isPending}>
        {isPending ? "Loading..." : "Login"}
      </button>

      <div className="text-center mt-3">
        <span>Don't have an account? </span>
        <Link to="/register">Register</Link>
      </div>
    </form>
  );
}