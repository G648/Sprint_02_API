using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using webapi.inlock.codeFirst.manha.Domains;
using webapi.inlock.codeFirst.manha.Interfaces;
using webapi.inlock.codeFirst.manha.Repositories;
using webapi.inlock.codeFirst.manha.ViewModels;

namespace webapi.inlock.codeFirst.manha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class LoginController : ControllerBase
    {

        private readonly IUsuarioRepository _usuarioRepository;

        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        public IActionResult Login(LoginViewModel usuario) 
        {
            try
            {
                Usuario usuarioBuscadoLogin = _usuarioRepository.BuscarUsuario(usuario.Email, usuario.Senha);

                if (usuarioBuscadoLogin == null)
                {
                    return NotFound("Email ou Senha Inválidos!");
                }

                //Caso encontre o usuário , prossegue para a criação do token

                //1º - Definir as informações(Claims) que serão fornecidos no token (PAYLOAD)
                var claims = new[]
                {
                    //formato da claim
                    new Claim(JwtRegisteredClaimNames.Jti,usuarioBuscadoLogin.IdUsuario.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email,usuarioBuscadoLogin.Email),
                    new Claim(ClaimTypes.Role,usuarioBuscadoLogin.TipoUsuario.ToString()),

                    //existe a possibilidade de criar uma claim personalizada
                    //new Claim("Claim Personalizada","Valor da Claim Personalizada")
                };

                //2º - Definir a chave de acesso ao token
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("InLock-chave-autenticacao-webapi-codeFirst"));

                //3º - Definir as credenciais do token (HEADER)
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                //4º - Gerar token
                var token = new JwtSecurityToken
                (
                    //emissor do token
                    issuer: "webapi.inlock.codeFirst.manha",

                    //destinatário do token
                    audience: "webapi.inlock.codeFirst.manha",

                    //dados definidos nas claims(informações)
                    claims: claims,

                    //tempo de expiração do token
                    expires: DateTime.Now.AddMinutes(5),

                    //credenciais do token
                    signingCredentials: creds
                );

                //5º - retornar o token criado
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
    }
}
