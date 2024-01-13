﻿using MeuPonto.Models.Timesheet.Empregadores;
using MeuPonto.Models.Timesheet.Perfis;
using MeuPonto.Models.Timesheet.Pontos;
using Microsoft.Azure.Cosmos;
using Microsoft.EntityFrameworkCore;

namespace MeuPonto.Data;

public static class DbSetExtensions
{
    public static ValueTask<TEntity?> FindByIdAsync<TEntity>(this DbSet<TEntity> dbSet, Guid? id, string partitionKey) where TEntity : class
    {
        return dbSet.FindAsync(id, partitionKey);
    }

    public static ValueTask<Empregador> FindByIdAsync(this DbSet<Empregador> dbSet, Guid? id, Guid userId)
    {
        var partitionKey = $"{userId}";

        return dbSet.FindAsync(id, partitionKey);
    }

    public static ValueTask<Perfil> FindByIdAsync(this DbSet<Perfil> dbSet, Guid? id, Guid userId)
    {
        var partitionKey = $"{userId}";

        return dbSet.FindAsync(id, partitionKey);
    }

    public static ValueTask<Ponto> FindByIdAsync(this DbSet<Ponto> dbSet, Guid? id, Guid userId, int ano)
    {
        var partitionKey = $"{userId}|{ano}";

        return dbSet.FindAsync(id, partitionKey);
    }

    public static string HandleException(this Exception ex)
    {
        if (ex.InnerException is CosmosException cosmosException)
        {
            if (cosmosException.ResponseBody.Contains("Request size is too large"))
            {
                return "Request size is too large";
            }

            return cosmosException.Message;
        }

        return ex.Message;
    }
}
