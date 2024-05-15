using FourSix.Domain.Entities.ClienteAggregate;

namespace FourSix.Application.UseCases.Clientes.ObtemCliente
{
    public class ObtemClienteUseCase : IObtemClienteUseCase
    {
        private readonly IClienteRepository _clienteRepository;
        private IOutputPort _outputPort;

        public ObtemClienteUseCase(IClienteRepository clienteRepository)
        {
            this._clienteRepository = clienteRepository;
            this._outputPort = new ObtemClientePresenter();
        }

        public void SetOutputPort(IOutputPort outputPort) => this._outputPort = outputPort;

        public Task Execute(string cpf) =>
            this.ObtemCliente(cpf);

        private async Task ObtemCliente(string cpf)
        {
            var cliente = this._clienteRepository
                .Listar(q => q.Cpf == cpf).FirstOrDefault();

            if (cliente != null)
            {
                this._outputPort.Ok(cliente);
                return;
            }

            this._outputPort.NotFound();
        }
    }
}