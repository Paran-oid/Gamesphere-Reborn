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
  roles: string[];
}

export interface LoginUser {
  usernameOrEmail: string;
  password: string;
}

export interface RegisterUser {
  fname: string;
  lname: string;
  birth: Date;
  location: string;
  userName: string;
  email: string;
  password: string;
}
