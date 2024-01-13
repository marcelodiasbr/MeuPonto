﻿using MeuPonto.Models.Timesheet.Contratos;

namespace MeuPonto.Models.Timesheet.Pontos;

public static class ContratoFacade
{
    public static void QualificaPonto(this Contrato contrato, Ponto ponto)
    {
        ponto.Contrato = new ContratoRef
        {
            Nome = contrato.Nome
        };

        ponto.ContratoId = contrato.Id;
    }
}
