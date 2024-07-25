export interface AppUser {
  id: string;
  fname: string;
  lname: string;
  birth: Date;
  location: string;
  userName: string;
  email: string;
  passwordHash: string;
  nickname?: string;
  summary?: string;
  profilePicturePath?: string;
}

export interface LoginUser {
  usernameOrEmail: string;
  password: string;
}