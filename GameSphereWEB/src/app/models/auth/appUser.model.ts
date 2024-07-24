export interface AppUser {
  id: string;
  fname: string;
  lname: string;
  birth: Date;
  location: string;
  userName: string;
  email: string;
  password: string;
  nickname?: string;
  summary?: string;
  profilePicturePath?: string;
}
