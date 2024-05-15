using FourSix.Domain.Entities.ClienteAggregate;

namespace FourSix.Application.UseCases.Clientes.ObtemCliente
{
    public interface IOutputPort
    {
        void Invalid();
        void NotFound();
        void Ok(Cliente cliente);
    }
}
