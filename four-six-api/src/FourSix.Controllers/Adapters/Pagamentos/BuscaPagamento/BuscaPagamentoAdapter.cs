﻿using FourSix.Controllers.ViewModels;
using FourSix.UseCases.UseCases.Pagamentos.BuscaPagamento;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FourSix.Controllers.Adapters.Pagamentos.BuscaPagamento
{
    public class BuscaPagamentoAdapter : IBuscaPagamentoAdapter
    {
        private readonly IBuscaPagamentoUseCase _useCase;

        public BuscaPagamentoAdapter(IBuscaPagamentoUseCase useCase)
        {
            _useCase = useCase;
        }


        [AllowAnonymous]
        [HttpGet("{pagamentoId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BuscaPagamentoResponse))]
        public async Task<BuscaPagamentoResponse> Buscar(Guid pagamentoId)
        {
            var model = new PagamentoModel(await _useCase.Execute(pagamentoId));

            return new BuscaPagamentoResponse(model);
        }
    }
}
