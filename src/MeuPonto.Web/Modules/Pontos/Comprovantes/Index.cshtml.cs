﻿using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using MeuPonto.Modules.Shared;
using Microsoft.AspNetCore.Mvc.Rendering;
using MeuPonto.Helpers;

namespace MeuPonto.Modules.Pontos.Comprovantes;

public class IndexModel : PageModel
{
    private readonly Data.MeuPontoDbContext _db;

    [BindProperty(SupportsGet = true)]
    public Guid? PontoId { get; set; }

    [BindProperty(SupportsGet = true)]
    public FiltroPontoRef Ponto { get; set; }

    [BindProperty(SupportsGet = true)]
    public TipoImagemEnum? TipoImagem { get; set; }

    [BindProperty(SupportsGet = true)]
    public string? Numero { get; set; }

    public IList<Comprovante> Comprovantes { get; set; } = default!;

    [BindProperty(SupportsGet = true)]
    public int? PaginaAtual { get; set; }

    public PaginationModel Pagination { get; set; }

    public IndexModel(Data.MeuPontoDbContext db)
    {
        _db = db;
    }

    public async Task OnGetAsync()
    {
        if (Ponto == null)
        {
            Ponto = new FiltroPontoRef();
        }

        ViewData["PerfilId"] = new SelectList(_db.Perfis.Where(x => x.TrabalhadorId == User.GetUserId()), "Id", "Nome").AddEmptyValue();

        var totalRegistros = await _db.Comprovantes.CountAsync(x => x.TrabalhadorId == User.GetUserId());

        Pagination = new PaginationModel(totalRegistros, PaginaAtual ?? 1);

        if (_db.Comprovantes != null)
        {
            Comprovantes = await _db.Comprovantes
                .Include(x => x.Ponto)
                .Where(x => true
                    && (Ponto.PerfilId == null || x.Ponto.PerfilId == Ponto.PerfilId)
                    && (Ponto.DataHora == null || x.Ponto.DataHora == Ponto.DataHora)
                    && (Ponto.Momento == null || x.Ponto.MomentoId == Ponto.Momento)
                    && (Ponto.Pausa == null || x.Ponto.PausaId == Ponto.Pausa)
                    && (TipoImagem == null || x.TipoImagemId == TipoImagem)
                    && (Numero == null || x.Numero == Numero)
                    && x.TrabalhadorId == User.GetUserId())
                .OrderByDescending(x => x.Ponto.DataHora)
                .Skip((Pagination.PaginaAtual - 1) * Pagination.TamanhoPagina.Value)
                .Take(Pagination.TamanhoPagina.Value)
                .ToListAsync();
        }
    }
}

public class FiltroPontoRef
{
    [BindProperty(SupportsGet = true)]
    public Guid? PerfilId { get; set; }

    [BindProperty(SupportsGet = true)]
    public DateTime? DataHora { get; set; }

    [BindProperty(SupportsGet = true)]
    public MomentoEnum? Momento { get; set; }

    [BindProperty(SupportsGet = true)]
    public PausaEnum? Pausa { get; set; }
}