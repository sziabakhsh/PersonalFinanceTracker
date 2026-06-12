import {useForm} from 'react-hook-form'
import * as yup from 'yup'
import { yupResolver } from '@hookform/resolvers/yup';

export default function CategoryForm() {

    const schema=yup.object().shape({
        name: yup.string().required()
    })

  const {handleSubmit, register} = useForm({resolver:yupResolver(schema)});

  const OnSubmit=(data) => {
    console.log(data);
  }

  return (
    <form onSubmit={handleSubmit(OnSubmit)}>
        <div className='mb-3'>
            <label className='form-label'>
                Category name:
            </label>
             <input type='text' {...register("name")} className='form-control' />
        </div>
        <div className='mb-3'>
            <label className='form-label' >Type</label>
            <select {...register("type")} className='form-select'>
                <option value="">Select Type</option>
                <option value="Income">Income</option>
                <option value="Expense">Expense</option>
            </select>
        </div>
        <div className='mb-3'>
            <input type='submit' className='btn btn-primary'  />
        </div>
    </form>
  )
}
