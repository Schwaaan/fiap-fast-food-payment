namespace FourSix.Application.UseCases.Clientes.NovoCliente
{
    public interface INovoClienteUseCase
    {
        /// <summary>
        /// Executa o Caso de Uso
        /// </summary>
        Task Execute(string cpf, string nomeCompleto, string email);

        /// <summary>
        /// Define a porta de saída
        /// </summary>
        /// <param name="outputPort">Porta de Saída</param>
        void SetOutputPort(IOutputPort outputPort);
    }
}
