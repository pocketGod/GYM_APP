export enum ValidationType {
    Email = 'email',
    PhoneNumber = 'phoneNumber',
    Password = 'password',
    Username = 'username'
}

export const VALIDATION_PATTERNS: { [key in ValidationType]: RegExp } = {
    [ValidationType.Email]: /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$/,
    [ValidationType.PhoneNumber]: /^\d{10}$/,
    [ValidationType.Password]: /^(?=.*[a-zA-Z])(?=.*\d).{6,}$/, /// at least 6 characters, at least 1 letter, at least 1 number
    [ValidationType.Username]: /^.{5,}$/ /// at least 5 characters
};