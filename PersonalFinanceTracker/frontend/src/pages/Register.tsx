import {useForm} from 'react-hook-form'
import * as yup from 'yup'
import { yupResolver } from '@hookform/resolvers/yup'

export default function Register() {

  const schema = yup.object().shape({
    fullname: yup.string().required().min(5,"Enter a valid fullname"),
    email: yup.string().required().email('Enter correct format of email'),
    password : yup.string().required().matches(/[0-9]+/).matches(/[a-z]+/).matches(/[A-Z]+/).min(5).max(8),
    repassword: yup.string().required().oneOf([yup.ref("password")])
  })

  const {handleSubmit, register} = useForm({resolver:yupResolver(schema)});
  const onSubmit=(data) => {
    console.log(data);
  }

  return (
    <form autoComplete='off' onSubmit={handleSubmit(onSubmit)}>
      <h3 className='mb-3'>Register</h3>
      <input type='text' placeholder='Enter Full name' {...register("fullname")} className='form-control mb-2' autoComplete='off' />
      <input type='email' placeholder='Enter email' {...register("email")} className='form-control mb-2' autoComplete='off' />
      <input type='password' placeholder='Enter password' {...register("password")} className='form-control mb-2' autoComplete='new-password'/>
      <input type='password' placeholder='Repeat password' {...register("repassword")} className='form-control mb-2' autoComplete='new-password' />
    
      <input type='submit' className='btn btn-primary ' />
      
    </form>
  )
}
