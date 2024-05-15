using FourSix.Domain.Entities.PedidoAggregate;

namespace FourSix.Application.UseCases.Pagamentos.GeraQRCode
{
    public sealed class GeraQRCodePresenter : IOutputPort<string>
    {
        public string QRCode { get; private set; }
        public bool InvalidOutput { get; private set; }
        public bool NotFoundOutput { get; private set; }
        public bool ExistOutput { get; private set; }
        public void Invalid() => this.InvalidOutput = true;
        public void NotFound() => this.NotFoundOutput = true;
        public void Exist() => this.ExistOutput = true;
        public void Ok(string qrCode) => this.QRCode = qrCode;
    }
}
