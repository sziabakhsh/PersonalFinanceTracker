import {registerUser} from '../api/account.tsx';
import { useMutation } from '@tanstack/react-query';

export const useRegister = () =>{
    return useMutation ({
        mutationFn: registerUser
    })
}