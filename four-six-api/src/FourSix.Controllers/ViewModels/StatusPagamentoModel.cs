using FourSix.Domain.Entities.PagamentoAggregate;

namespace FourSix.Controllers.ViewModels
{
    public class StatusPagamentoModel
    {
        public StatusPagamentoModel(StatusPagamento statusPagamento)
        {
            StatusId = statusPagamento.Id;
            Descricao = statusPagamento.Descricao;
        }

        public EnumStatusPagamento StatusId { get; }
        public string Descricao { get; }
    }
}
