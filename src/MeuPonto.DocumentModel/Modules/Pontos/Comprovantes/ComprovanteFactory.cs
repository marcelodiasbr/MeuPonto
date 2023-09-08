﻿namespace MeuPonto.Modules.Pontos.Comprovantes;

public static class ComprovanteFactory
{
    public static Comprovante CriaComprovante(TransactionContext transaction, Guid? id = null)
    {
        var comprovante = new Comprovante
        {
            Id = id ?? Guid.NewGuid(),
            TrabalhadorId = transaction.UserId,
            PartitionKey = $"{transaction.UserId}",
            CreationDate = transaction.DateTime
        };

        return comprovante;
    }

    public static void RecontextualizaComprovante(this Comprovante comprovante, TransactionContext transaction, Guid? id = null)
    {
        comprovante.Id ??= id ?? Guid.NewGuid();
        comprovante.TrabalhadorId = transaction.UserId;
        //comprovante.PartitionKey = $"{transaction.UserId}|{comprovante.Ponto.DataHora:yyyy}";
        comprovante.CreationDate ??= transaction.DateTime;
    }
}
