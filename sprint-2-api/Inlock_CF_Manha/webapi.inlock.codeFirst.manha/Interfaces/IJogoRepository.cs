using webapi.inlock.codeFirst.manha.Domains;

namespace webapi.inlock.codeFirst.manha.Interfaces
{
    public interface IJogoRepository
    {
        List<Jogo> Listar();
        List<Jogo> ListarComJogos();
        Jogo BuscarPorId(Guid id);
        void Cadastrar(Jogo estudio);
        void Atualizar(Guid id, Jogo jogo);
        void Deletar(Guid id);
    }
}
