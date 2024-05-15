using FourSix.Domain.Entities.ClienteAggregate;

namespace FourSix.Application.UseCases.Clientes.NovoCliente
{
    public sealed class NovoClientePresenter : IOutputPort
    {
        public Cliente? Cliente { get; private set; }
        public bool InvalidOutput { get; private set; }
        public bool NotFoundOutput { get; private set; }
        public bool ExistOutput { get; private set; }
        public void Invalid() => this.InvalidOutput = true;
        public void NotFound() => this.NotFoundOutput = true;
        public void Exist() => this.ExistOutput = true;
        public void Ok(Cliente cliente) => this.Cliente = cliente;
    }
}
