namespace FourSix.Application.UseCases.Clientes.ObtemCliente
{
    public interface IObtemClienteUseCase
    {
        Task Execute(string cpf);
        void SetOutputPort(IOutputPort outputPort);
    }
}
