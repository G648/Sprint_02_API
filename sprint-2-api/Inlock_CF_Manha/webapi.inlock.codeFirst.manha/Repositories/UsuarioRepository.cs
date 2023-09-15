using webapi.inlock.codeFirst.manha.Contexts;
using webapi.inlock.codeFirst.manha.Domains;
using webapi.inlock.codeFirst.manha.Interfaces;
using webapi.inlock.codeFirst.manha.Utils;

namespace webapi.inlock.codeFirst.manha.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        /// <summary>
        /// Variável privada e somente leitura para armazenar os dados do contexto
        /// </summary>
        private readonly InLockContext ctx;

        /// <summary>
        /// construtor do repositório
        /// Toda vez que o repositório for instanciado, 
        /// ele terá acesso aos dados fornecidos pelo contexto
        /// </summary>
        public UsuarioRepository()
        {
            ctx = new InLockContext();
        }

        public Usuario BuscarUsuario(string email, string senha)
        {
            try
            {
                Usuario usuarioBuscado = ctx.Usuario.FirstOrDefault(u => u.Email == email);

                if (usuarioBuscado != null)
                {
                    //                                   senha wagger    senha do banco de dados
                    bool confere = Criptografia.CompararHash(senha, usuarioBuscado.Senha);

                    if (confere == true)
                    {
                        return usuarioBuscado;
                    }
                }

                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Usuario usuario)
        {
            try
            {
                usuario.Senha = Criptografia.GerarHash(usuario.Senha!);

                ctx.Usuario.Add(usuario);

                //salvar alterações no banco
                ctx.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
