import {useForm} from 'react-hook-form'
import * as yup from 'yup'
import { yupResolver } from '@hookform/resolvers/yup';
import { useCreateCategory } from '../hooks/useCreateCategory';

export default function CategoryForm() {

    const schema=yup.object().shape({
        name: yup.string().required()
    })

  const {handleSubmit, register ,reset} = useForm({resolver:yupResolver(schema)});

  const {mutate, isError, isPending, error} = useCreateCategory();

  const OnSubmit=(data) => {
    //console.log(data);
    mutate(data, {
        onSuccess: ()=>{
            reset();
        }
    });
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
