using Microsoft.EntityFrameworkCore;
using webapi.inlock.codeFirst.manha.Domains;

namespace webapi.inlock.codeFirst.manha.Contexts
{
    public class InLockContext : DbContext
    {
        //essa classe vai representar a nossa conexão com banco de dados 
        //vamos definir as entidades do banco de dados

        //          <classe>  Tabela
        public DbSet<Estudio> Estudio { get; set; }
        public DbSet<Jogo> Jogo { get; set; }
        public DbSet<TiposUsuario> TiposUsuario { get; set; }
        public DbSet<Usuario> Usuario { get; set; }


        /// <summary>
        /// vamos definir as opções de construção do banco (string de Conexão)
        /// </summary>
        /// <param name="optionsBuilder">Objeto com as configurações definidas</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=NOTE16-S15; Database=inlock_games_codeFirst_manha; user id= sa; Pwd=Senai@134; TrustServerCertificate=True");

            base.OnConfiguring(optionsBuilder);
        }
    }
}
