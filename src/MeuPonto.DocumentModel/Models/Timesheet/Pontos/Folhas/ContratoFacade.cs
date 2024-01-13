﻿using MeuPonto.Models.Timesheet.Contratos;

namespace MeuPonto.Models.Timesheet.Pontos.Folhas;

public static class ContratoFacade
{
    public static void QualificaFolha(this Contrato contrato, Folha folha)
    {
        folha.Contrato = new ContratoRef
        {
            Nome = contrato.Nome
        };

        folha.ContratoId = contrato.Id;
    }
}
