using FourSix.Controllers.Adapters.Pagamentos.AlteraStatusPagamento;
using FourSix.Controllers.Adapters.Pagamentos.BuscaPagamento;
using FourSix.Controllers.Adapters.Pagamentos.GeraPagamento;
using FourSix.Controllers.Adapters.Pedidos.ObtemStatusPagamentoPedido;

namespace FourSix.WebApi.Modules
{
    public static class AdaptersExtensions
    {
        public static IServiceCollection AddAdapters(this IServiceCollection services)
        {

            #region [ Pagamentos ]
            services.AddScoped<IBuscaPagamentoAdapter, BuscaPagamentoAdapter>();
            services.AddScoped<IGeraPagamentoAdapter, GeraPagamentoAdapter>();
            services.AddScoped<IObtemStatusPagamentoPedidoAdapter, ObtemStatusPagamentoPedidoAdapter>();
            services.AddScoped<IAlteraStatusPagamentoAdapter, AlteraStatusPagamentoAdapter>();
            #endregion

            return services;
        }
    }
}
