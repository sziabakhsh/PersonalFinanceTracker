import { useMutation, useQueryClient } from "@tanstack/react-query";
import { deleteCategory } from "../api/category";

export const useDeleteCategory = ()=>{
    const qc = useQueryClient();

    return useMutation({
        mutationFn:deleteCategory,
        onSuccess(){
            qc.invalidateQueries({
                queryKey: ["categories"]
            });
        }
    });
};