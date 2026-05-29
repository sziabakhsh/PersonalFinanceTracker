import api from "./api";

export const loginUser = async (data) =>{
    await api.post(api+"/account/login", data).then(res => res.data)
} 

export const registerUser = async(data) =>{
    await api.post(api+"/account/register", data).then(res => res.data)
}

