﻿namespace MeuPonto.Modules.Pontos.Comprovantes;

public static class ComprovanteFacade
{
    public static void ComprovaPonto(this Comprovante comprovante, Ponto ponto)
    {
        comprovante.Ponto = new PontoRef
        {
            PerfilId = ponto.PerfilId,
            DataHora = ponto.DataHora,
            Perfil = ponto.Perfil,
            MomentoId = ponto.MomentoId,
            PausaId = ponto.PausaId
        };

        comprovante.PontoId = ponto.Id;
    }
}
