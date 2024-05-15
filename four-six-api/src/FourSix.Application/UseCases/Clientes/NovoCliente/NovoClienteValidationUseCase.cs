using FourSix.Application.Services;

namespace FourSix.Application.UseCases.Clientes.NovoCliente
{
    public class NovoClienteValidationUseCase : INovoClienteUseCase
    {
        private readonly Notification _notification;
        private readonly INovoClienteUseCase _useCase;
        private IOutputPort _outputPort;

        public NovoClienteValidationUseCase(INovoClienteUseCase useCase, Notification notification)
        {
            this._useCase = useCase;
            this._notification = notification;
            this._outputPort = new NovoClientePresenter();
        }

        public void SetOutputPort(IOutputPort outputPort)
        {
            this._outputPort = outputPort;
            this._useCase.SetOutputPort(outputPort);
        }

        public async Task Execute(string cpf, string nomeCompleto, string email)
        {
            if (string.IsNullOrEmpty(cpf))
                this._notification
                    .Add(nameof(cpf), $"{nameof(cpf)} é obrigatório.");

            if (string.IsNullOrEmpty(nomeCompleto))
                this._notification
                    .Add(nameof(nomeCompleto), $"{nameof(nomeCompleto)} é obrigatório.");

            if (string.IsNullOrEmpty(email))
                this._notification
                    .Add(nameof(email), $"{nameof(email)} é obrigatório.");

            if (this._notification
            .IsInvalid)
            {
                this._outputPort
                    .Invalid();
                return;
            }

            await this._useCase
                .Execute(cpf, nomeCompleto, email)
                .ConfigureAwait(false);
        }
    }
}
