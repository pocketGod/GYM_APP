import { GenericInputValue } from "../common/GenericInputValue.model";

export interface LoginCredentials{
    user: GenericInputValue<string>,
    pass: GenericInputValue<string>
}

export interface RegisterCredentials{
    user: GenericInputValue<string>,
    pass: GenericInputValue<string>
}