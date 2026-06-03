import { useMutation } from "@tanstack/react-query";
import { loginUser } from "../api/account";

export const useLogin = () => {
  return useMutation({
    mutationFn: loginUser,
  });
};