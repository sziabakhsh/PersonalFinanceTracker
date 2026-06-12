import {registerUser} from '../api/account';
import { useMutation } from '@tanstack/react-query';

export const useRegister = () =>{
    return useMutation ({
        mutationFn: registerUser
    })
}