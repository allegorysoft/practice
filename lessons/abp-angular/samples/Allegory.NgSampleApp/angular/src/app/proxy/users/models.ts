export interface User {
    id: number;
    name: string;
    username: string;
}

export interface UserCreateDto {
    name: string;
    username: string;
    email: string
}
