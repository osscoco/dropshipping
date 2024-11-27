export class ResponseApi {

    // Définir les propriétés de la classe avec leurs types
    success: boolean;
    data: any;
    message: string;
      
    // Constructeur pour initialiser la classe
    constructor(success: boolean, data: any, message: string) {
      this.success = success;
      this.data = data;
      this.message = message;
    }
}