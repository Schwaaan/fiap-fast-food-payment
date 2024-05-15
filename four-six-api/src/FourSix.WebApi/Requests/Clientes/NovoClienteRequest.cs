using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace FourSix.WebApi.Requests.Clientes
{
    [SwaggerSchema(Required = new[] { "cpf", "nomeCompleto", "email" })]
    public class NovoClienteRequest
    {
        /// <summary>
        /// CPF do cliente
        /// </summary>
        /// <example>12345678921</example>
        [SwaggerSchema(Nullable = false)]
        public string Cpf { get; set; }
        /// <summary>
        /// Nome Completo do Cliente
        /// </summary>
        /// <example>João da Silva Gomes</example>
        [SwaggerSchema(Nullable = false)]
        public string NomeCompleto { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        /// <example>joao.silva@dominio.com.br</example>
        [SwaggerSchema(Nullable = false)]
        public string Email { get; set; }
    }
}
