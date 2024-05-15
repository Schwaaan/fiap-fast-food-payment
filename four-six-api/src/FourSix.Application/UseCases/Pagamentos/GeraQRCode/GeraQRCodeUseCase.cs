using FourSix.Application.ExtensionsMethods;
using System.Text;

namespace FourSix.Application.UseCases.Pagamentos.GeraQRCode
{
    public class GeraQRCodeUseCase : IGeraQRCodeUseCase
    {
        private IOutputPort<string> _outputPort;

        public GeraQRCodeUseCase()
        {
            this._outputPort = new GeraQRCodePresenter();
        }

        /// <inheritdoc />
        public void SetOutputPort(IOutputPort<string> outputPort) => this._outputPort = outputPort;

        /// <inheritdoc />
        public Task<string> Execute(Guid pedidoId, decimal valor) =>
            this.GerarQRCode(pedidoId, valor);

        private async Task<string> GerarQRCode(Guid pedidoId, decimal valor)
        {
            string cnpjEmpresa = "01.001.001/0001-00";
            string nomeBeneficiario = "FOUR SIX";
            string nomeCidade = "SÃO PAULO";
            string cep = "01201-000";

            StringBuilder builder = new StringBuilder();
            builder.Append("01");
            builder.Append(cnpjEmpresa.Replace(".", "").Replace("-", ""));
            builder.Append("BR.GOV.BCB.PIX");
            builder.Append(pedidoId);
            builder.Append("0000");
            builder.Append("986");
            builder.AppendFormat("0.00", valor);
            builder.Append("BR");
            builder.Append(nomeBeneficiario.RemoverAcentos());
            builder.Append(nomeCidade.RemoverAcentos());
            builder.Append(cep);

            this._outputPort?.Ok(builder.ToString());
            return builder.ToString();
        }
    }
}
