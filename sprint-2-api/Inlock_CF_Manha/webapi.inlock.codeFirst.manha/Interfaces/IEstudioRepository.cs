using webapi.inlock.codeFirst.manha.Domains;

namespace webapi.inlock.codeFirst.manha.Interfaces
{
    public interface IEstudioRepository
    {
        /// <summary>
        /// Método para realizar a listagem dos estudios criados
        /// </summary>
        /// <returns></returns>
        List<Estudio> Listar();

        /// <summary>
        /// Método para listar com jogos
        /// </summary>
        /// <returns></returns>
        List<Estudio> ListarComJogos();

        /// <summary>
        /// Método para buscar um determinado estudio
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Estudio BuscarPorId(Guid id);

        /// <summary>
        /// método para cadastrar um determinado estudio
        /// </summary>
        /// <param name="estudio"></param>
        void Cadastrar(Estudio estudio);

        /// <summary>
        /// método para realizar a atualização do estudio
        /// </summary>
        /// <param name="id"></param>
        /// <param name="estudio"></param>
        void Atualizar(Guid id, Estudio estudio);

        /// <summary>
        /// metodo para deletar um determinado Estudio
        /// </summary>
        /// <param name="id"></param>
        void Deletar(Guid id);
    }
}
