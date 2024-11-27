import { Role } from "./role.model";

export class User {

    // Définir les propriétés de la classe avec leurs types
    firstName: string;
    lastName: string;
    email: string;
    password: string;
    contactPhone: string;
    dateOfBirth: Date;
    roleId: number;
    role?: Role;
  
    // Constructeur pour initialiser la classe
    constructor(firstName: string, lastName: string, email: string, password: string, contactPhone: string, dateOfBirth: Date, roleId: number) {
      this.firstName = firstName;
      this.lastName = lastName;
      this.email = email;
      this.password = password;
      this.contactPhone = contactPhone;
      this.dateOfBirth = dateOfBirth;
      this.roleId = roleId;
    }
  
    getFullName(): string {
      return this.firstName + ' ' + this.lastName;
    }
}

export class UserLogin {

  // Définir les propriétés de la classe avec leurs types
  email: string;
  password: string;

  // Constructeur pour initialiser la classe
  constructor(email: string, password: string) {
    this.email = email;
    this.password = password;
  }
}