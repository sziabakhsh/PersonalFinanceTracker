import { loginUser } from "../api/account";
import { useMutation } from "@tanstack/react-query";

export const useLogin = (data) =>{
    return useMutation({
        mutationFn: loginUser
    });
}