using FourSix.Domain.Entities.ClienteAggregate;

namespace FourSix.Application.UseCases.Clientes.ObtemCliente
{
    public class ObtemClientePresenter : IOutputPort
    {
        public Cliente? Cliente { get; private set; }
        public bool? IsNotFound { get; private set; }
        public bool? InvalidOutput { get; private set; }
        public void Invalid() => this.InvalidOutput = true;
        public void NotFound() => this.IsNotFound = true;

        public void Ok(Cliente cliente) => this.Cliente = cliente;

    }
}
