using FourSix.Domain.Entities.PagamentoAggregate;

namespace FourSix.Application.UseCases.Pagamentos.GeraPagamento
{
    public sealed class GeraPagamentoPresenter : IOutputPort<Pagamento>
    {
        public Pagamento Pagamento { get; private set; }
        public bool InvalidOutput { get; private set; }
        public bool NotFoundOutput { get; private set; }
        public bool ExistOutput { get; private set; }
        public void Invalid() => InvalidOutput = true;
        public void NotFound() => NotFoundOutput = true;
        public void Exist() => ExistOutput = true;
        public void Ok(Pagamento pagamento) => Pagamento = pagamento;
    }
}
