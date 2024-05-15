using FourSix.Application.Services;

namespace FourSix.Application.UseCases.Pagamentos.GeraQRCode
{
    public class GeraQRCodeValidationUseCase : IGeraQRCodeUseCase
    {
        private readonly Notification _notification;
        private readonly IGeraQRCodeUseCase _useCase;
        private IOutputPort<string> _outputPort;

        public GeraQRCodeValidationUseCase(IGeraQRCodeUseCase useCase, Notification notification)
        {
            this._useCase = useCase;
            this._notification = notification;
            this._outputPort = new GeraQRCodePresenter();
        }

        public void SetOutputPort(IOutputPort<string> outputPort)
        {
            this._outputPort = outputPort;
            this._useCase.SetOutputPort(outputPort);
        }

        public async Task<string> Execute(Guid pedidoId, decimal valor)
        {
            if (valor <= 0)
                this._notification
                    .Add(nameof(valor), $"{nameof(valor)} é obrigatório.");

            if (this._notification
            .IsInvalid)
            {
                this._outputPort
                    .Invalid();
                return "";
            }

            return await this._useCase
                .Execute(pedidoId, valor)
                .ConfigureAwait(false);
        }
    }
}
