using FourSix.Controllers.Presenters;
using FourSix.UseCases.UseCases.Pagamentos.AlterarStatusPagamento;
using FourSix.UseCases.UseCases.Pagamentos.BuscaPagamento;
using FourSix.UseCases.UseCases.Pagamentos.GeraPagamento;
using FourSix.UseCases.UseCases.Pagamentos.GeraQRCode;
using FourSix.UseCases.UseCases.Pedidos.ObtemStatusPagamentoPedido;

namespace FourSix.WebApi.Modules
{
    public static class UseCasesExtensions
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<Notification, Notification>();

            #region [ Pagamento ]
            services.AddScoped<IGeraQRCodeUseCase, GeraQRCodeUseCase>();
            services.AddScoped<IGeraPagamentoUseCase, GeraPagamentoUseCase>();
            services.AddScoped<IObtemStatusPagamentoPedidoUseCase, ObtemStatusPagamentoPedidoUseCase>();
            services.AddScoped<IBuscaPagamentoUseCase, BuscaPagamentoUseCase>();
            services.AddScoped<IAlterarStatusPagamentoUseCase, AlterarStatusPagamentoUseCase>();
            #endregion

            return services;
        }
    }
}
