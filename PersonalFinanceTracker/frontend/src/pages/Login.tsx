import { useForm } from 'react-hook-form';

export default function Login() {
  return (
    <form>
      <input type="email" placeholder="Enter email" />

      <input type="password" placeholder="Enter Password" />

      <button type="submit">
        Sign in
      </button>
    </form>
  );
}