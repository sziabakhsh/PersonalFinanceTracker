import {useForm } from 'react-hook-form'

export default function Login() {
  return (
    <form>
       <input type='email' placeholder='Enter email'></input>
       <input type='password' placeholder='Enter Password'></input>
       <input type='submit'>Sign in</input>
    </ form>
  )
}
