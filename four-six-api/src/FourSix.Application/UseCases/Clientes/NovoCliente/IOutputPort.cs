using FourSix.Domain.Entities.ClienteAggregate;

namespace FourSix.Application.UseCases.Clientes.NovoCliente
{
    public interface IOutputPort
    {
        /// <summary>
        /// Novo Cliente
        /// </summary>
        void Ok(Cliente cliente);

        /// <summary>
        /// Cliente não encontrado
        /// </summary>
        void NotFound();

        /// <summary>
        /// Entrada inválida
        /// </summary>
        void Invalid();

        /// <summary>
        /// Entrada inválida
        /// </summary>
        void Exist();
    }
}
