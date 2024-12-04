﻿using System.Transactions;
using MeuPonto.Models.Contratos;

namespace MeuPonto.Features.GestaoContratos;

public static class GestaoContratosFacade
{
    public static Contrato InciarAberturaContrato(this TransactionContext transaction, Guid? id = null)
    {
        var contrato = new Contrato
        {
            Id = id ?? Guid.NewGuid(),
            UserId = transaction.UserId,
            CreationDate = transaction.DateTime
        };

        contrato.Ativo = true;

        return contrato;
    }

    public static Contrato AbrirContrato(this Contrato contrato, Empregador empregador)
    {
        contrato.Empregador = empregador;

        contrato.EmpregadorId = empregador?.Id;

        return contrato;
    }

    public static Contrato AlterarContrato(this Contrato contrato, Empregador empregador)
    {
        contrato.Empregador = empregador;

        contrato.EmpregadorId = empregador?.Id;

        return contrato;
    }

    public static void RecontextualizaContrato(this Contrato contrato, TransactionContext transaction, Guid? id = null)
    {
        contrato.Id = contrato.Id ?? id ?? Guid.NewGuid();
        contrato.UserId = transaction.UserId;
        contrato.CreationDate = transaction.DateTime;
    }
}
