using System.Transactions;
using MeuPonto.Models.Folhas;

namespace MeuPonto.Features.GestaoFolha;

public static class GestaoFolhaFacade
{
    public static Folha IniciarAberturaFolha(this TransactionContext transaction, Guid? id = null)
    {
        var folha = new Folha
        {
            Id = id ?? Guid.NewGuid(),
            UserId = transaction.UserId,
            CreationDate = transaction.DateTime
        };

        return folha;
    }

    public static void RecontextualizaFolha(this TransactionContext transaction, Folha folha, Guid? id = null)
    {
        folha.Id = folha.Id ?? id ?? Guid.NewGuid();
        folha.UserId = transaction.UserId;
        folha.CreationDate = transaction.DateTime;
    }
}
