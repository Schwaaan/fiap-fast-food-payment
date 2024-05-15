using FourSix.Domain.Entities.ClienteAggregate;
using FourSix.Domain.Entities.PedidoAggregate;

namespace FourSix.Application.UseCases.Pedidos.ObtemPedidosPorStatus
{
    public class ObtemPedidosPorStatusPresenter : IOutputPort<ICollection<Pedido>>
    {
        public ICollection<Pedido> Pedidos { get; private set; }
        public bool? IsNotFound { get; private set; }
        public bool? InvalidOutput { get; private set; }
        public bool ExistOutput { get; private set; }

        public void Invalid() => this.InvalidOutput = true;
        public void NotFound() => this.IsNotFound = true;
        public void Exist() => this.ExistOutput = true;

        public void Ok(ICollection<Pedido> Pedidos) => this.Pedidos = Pedidos;
    }
}
