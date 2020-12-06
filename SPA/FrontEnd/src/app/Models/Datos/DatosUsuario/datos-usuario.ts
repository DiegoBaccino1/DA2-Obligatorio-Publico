export class DatosUsuario {
    id: number;
    nombre: string;
    mail: string;
    apellido: string;

    constructor(nombre: string, mail: string, apellido: string) {
        this.nombre = nombre;
        this.mail = mail;
        this.apellido = apellido;
    }
}
