import api from "./api";

// Account Login
export interface LoginRequest {
  email: string;
  password: string;
}

export interface LoginResponse {
  token: string;
  fullname: string;
}

export const loginUser = async (request: LoginRequest): 
  Promise<LoginResponse> => {
    const response = await api.post<LoginResponse>(
      "/account/login",
      request
    );
    return response.data;
  };

// Account Register
export interface RegisterRequest {
  fullname: string;
  email: string;
  password: string;
}

export interface RegisterResponse {
  fullname: string;
  email: string;
  token: string;
}

export const registerUser = async (request: RegisterRequest):
Promise<RegisterResponse> => {
  const response = await api.post<RegisterResponse>(
    "account/register",
    request
  )
  return response.data;
};