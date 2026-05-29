import {registerUser} from '../api/account';
import { useMutation } from '@tanstack/react-query';

export const useRegister = (data) =>{
    return useMutation ({
        mutationFn: registerUser
    })
}