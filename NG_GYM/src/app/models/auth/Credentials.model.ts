import { GenericInputValue } from "../common/GenericInputValue.model";

export interface LoginCredentials{
    user: GenericInputValue<string>,
    pass: GenericInputValue<string>
}