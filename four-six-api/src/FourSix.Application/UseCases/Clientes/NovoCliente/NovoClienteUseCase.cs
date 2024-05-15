using FourSix.Application.Services;
using FourSix.Domain.Entities.ClienteAggregate;

namespace FourSix.Application.UseCases.Clientes.NovoCliente
{
    public class NovoClienteUseCase : INovoClienteUseCase
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IUnitOfWork _unitOfWork;
        private IOutputPort _outputPort;

        public NovoClienteUseCase(
            IClienteRepository clienteRepository,
            IUnitOfWork unitOfWork)
        {
            this._clienteRepository = clienteRepository;
            this._unitOfWork = unitOfWork;
            this._outputPort = new NovoClientePresenter();
        }

        /// <inheritdoc />
        public void SetOutputPort(IOutputPort outputPort) => this._outputPort = outputPort;

        /// <inheritdoc />
        public Task Execute(string cpf, string nomeCompleto, string email) =>
            this.NovoCliente(
                new Cliente(Guid.NewGuid(),
                cpf,
                nomeCompleto,
                email));

        private async Task NovoCliente(Cliente cliente)
        {
            if (this._clienteRepository
                .Listar(q => q.Cpf == cliente.Cpf).Any())
            {
                this._outputPort.Exist();
                return;
            }

            await this._clienteRepository
                 .Incluir(cliente)
                 .ConfigureAwait(false);

            await this._unitOfWork
                .Save()
                .ConfigureAwait(false);

            this._outputPort?.Ok(cliente);
        }
    }
}
