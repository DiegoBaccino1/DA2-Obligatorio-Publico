using BuissnesLogic_Interface;
using Domain;
using Exceptiones;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IUsuario logica;
        private readonly IConfiguration configuration;
        public LoginController(IUsuario logicaUsuario,IConfiguration configuration)
        {
            logica = logicaUsuario;
            this.configuration = configuration;
        }

        [HttpGet]
        public IActionResult GetPorCredenciales([FromQuery]string mail, [FromQuery] string contrasenia)
        {
            int expiracionValue = 1;
            try
            {
                Usuario usuario = logica.ObtenerPorCredenciales(mail, contrasenia);
                var claims = new[]
                {
                    new Claim("Mail", usuario.Datos.Mail),
                    new Claim("Contrasenia", usuario.Contrasenia),
                    new Claim(ClaimTypes.Role,usuario.IsAdmin ? "Admin":"Turista")
                };
                DateTime fechaAhora = DateTime.Now;

                SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Secret"]));
                SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
                var handler = new JwtSecurityTokenHandler();

                var token = new JwtSecurityToken(
                    issuer: configuration["Issuer"],
                    audience: configuration["Audience"],
                    claims,
                    notBefore: fechaAhora,
                    expires: fechaAhora.AddYears(expiracionValue),
                    credentials
                    );

                var tokenString = handler.WriteToken(token);
                return Ok(tokenString);
            }
            catch (StringVacioException)
            {
                return BadRequest("Ni el mail ni la contraseña pueden ser vacios");
            }
            catch (FormatoInvalidoException)
            {
                return BadRequest("El formato del mail no es valido");
            }
        }
    }
}
