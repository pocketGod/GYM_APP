export interface LoginRequest{ 
    Username: string, 
    Password: string 
}

export interface RegisterRequest{ 
    Username: string, 
    Password: string 
}

export interface LoginResponse { 
    token: string;
    error: string;
    isSuccess: boolean;
}