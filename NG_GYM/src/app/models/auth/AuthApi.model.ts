export interface LoginRequest{ 
    Username: string, 
    Password: string 
}

export interface RegisterRequest{ 
    Username: string, 
    Password: string 
}

export interface LoginResponse { 
    Token: string;
    Error: string;
    IsSuccess: boolean;
}