using BuissnesLogic_Interface;
using DataAccessInterface;
using Domain;
using Exceptiones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography;
using System.Text;

namespace BuissnesLogic
{
    public class Usuario_Logic : IUsuario
    {
        private readonly IRepository<Usuario> repository;

        public Usuario_Logic(IRepository<Usuario> repo)
        {
            this.repository = repo;
        }

        public Usuario ObtenerPorId(int id)
        {
            return this.repository.Get(id);
        }

        public Usuario ObtenerPorNombre(string nombre)
        {
            Usuario usuario = this.ObtenerTodos().Where(x => x.Datos.Nombre.Equals(nombre)).FirstOrDefault();
            NoExisteUsuario(usuario);
            return usuario;
        }

        private static void NoExisteUsuario(Usuario usuario)
        {
            if (usuario == null)
                throw new EntidadNoExisteExcepcion();
        }

        public List<Usuario> ObtenerTodos()
        {
            return this.repository.GetAll().ToList();
        }

        public string ValidarMail(string emailAComprobar)
        {
            emailAComprobar = this.ValidarString(emailAComprobar);
            ValidadorFormatoMail.ValidarFormato(emailAComprobar);
            MailUnico(emailAComprobar);
            return emailAComprobar;
        }     

        private void MailUnico(string emailAComprobar)
        {
            Usuario usuario = this.ObtenerTodos().Where(x => x.Datos.Mail.Equals(emailAComprobar)).FirstOrDefault();
            if (usuario != null)
                throw new MailNoUnicoException();
        }

        public string ValidarString(string stringAValidar)
        {
            return ValidadorString.ValidarStringVacio(stringAValidar);
        }

        public Usuario CrearUsuario(int id,Usuario modelo)
        {
            Usuario usuario = new Usuario();
            usuario.Id = id;
            usuario.Datos = new DatosUsuario();
            usuario.Datos.Mail = this.ValidarMail(modelo.Datos.Mail);
            AsignarDatos(usuario, modelo);
            return usuario;
        }

        private static void ChequearDatos(Usuario modelo)
        {
            if (modelo.Datos == null)
                throw new StringVacioException();
        }

        public void AgregarUsuario(Usuario usuario)
        {
            this.repository.Create(usuario);
            this.repository.Save();
        }

        public void BorrarUsuario(int id)
        {
            Usuario usuarioABorrar=this.ObtenerPorId(id);
            this.repository.Delete(usuarioABorrar);
            this.repository.Save();
        }

        public void ActualizarUsuario(int id,Usuario usuarioNuevo)
        {
            Usuario usuario = this.ObtenerPorId(id);
            if (!(usuario.Datos.Mail.Equals(usuarioNuevo.Datos.Mail)))
                usuario.Datos.Mail = this.ValidarMail(usuarioNuevo.Datos.Mail);
            AsignarDatos(usuario, usuarioNuevo);
            this.repository.Update(usuario);
            this.repository.Save();
        }
        private void AsignarDatos(Usuario destino,Usuario origen)
        {
            ChequearDatos(origen);
            DatosUsuario datos = origen.Datos;
            destino.Contrasenia = this.ValidarString(origen.Contrasenia);
            destino.IsAdmin = origen.IsAdmin;
            destino.Token = "Recien creado";
            destino.Datos.Nombre = datos.Nombre;
            if (!destino.IsAdmin)
                destino.Datos.Apellido = this.ValidarString(datos.Apellido);
        }

        public Usuario ObtenerPorCredenciales(string mail, string contrasenia)
        {
            ValidadorString.ValidarStringVacio(mail);
            ValidadorFormatoMail.ValidarFormato(mail);
            ValidadorString.ValidarStringVacio(contrasenia);
            Usuario usuario=this.repository.GetAll().Where(x => x.Datos.Mail.Equals(mail)
                                && x.Contrasenia.Equals(contrasenia)).FirstOrDefault();
            NoExisteUsuario(usuario);
            return usuario;
        }
    }
}
