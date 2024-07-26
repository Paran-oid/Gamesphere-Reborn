export interface LoginResponse {
  accessToken: string;
  expiresIn: number;
  refreshToken: string;
}

export interface RegisterResponse {
  accessToken: string;
  expiresIn: number;
}
