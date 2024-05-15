using FourSix.Domain.Entities.PedidoAggregate;

namespace FourSix.Application.UseCases.Pedidos.CancelaPedido
{
    public sealed class CancelaPedidoPresenter : IOutputPort<Pedido>
    {
        public Pedido? Pedido { get; private set; }
        public bool InvalidOutput { get; private set; }
        public bool NotFoundOutput { get; private set; }
        public bool ExistOutput { get; private set; }
        public void Invalid() => this.InvalidOutput = true;
        public void NotFound() => this.NotFoundOutput = true;
        public void Exist() => this.ExistOutput = true;
        public void Ok(Pedido pedido) => this.Pedido = pedido;
    }
}
