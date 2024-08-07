namespace FourSix.Controllers.ViewModels
{
    public class PedidoModel
    {
        public PedidoModel(Guid id, int statusId)
        {
            Id = id;
            StatusId = statusId;
        }

        public Guid Id { get; }
        public int StatusId { get; }
    }
}
