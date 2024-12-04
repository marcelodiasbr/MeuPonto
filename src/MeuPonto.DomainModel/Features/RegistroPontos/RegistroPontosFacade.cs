﻿using System.Transactions;
using MeuPonto.Models.Pontos;

namespace MeuPonto.Features.RegistroPontos;

public static class RegistroPontosFacade
{
    public static Ponto CriaPonto(TransactionContext transaction, Guid? id = null)
    {
        var ponto = new Ponto
        {
            Id = id ?? Guid.NewGuid(),
            UserId = transaction.UserId,
            CreationDate = transaction.DateTime
        };

        return ponto;
    }

    public static void RecontextualizaPonto(this Ponto ponto, TransactionContext transaction, Guid? id = null)
    {
        ponto.Id = ponto.Id ?? id ?? Guid.NewGuid();
        ponto.UserId = transaction.UserId;
        ponto.CreationDate = transaction.DateTime;
    }
}
