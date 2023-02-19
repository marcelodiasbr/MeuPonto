﻿using MeuPonto.Data;
using MeuPonto.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;

namespace MeuPonto.Modules;

public class ConfiguracoesModel : PageModel
{
    private readonly MeuPontoDbContext _db;

    private readonly IMemoryCache _cache;

    private readonly ILogger<ConfiguracoesModel> _logger;

    public bool ResetSuccess { get; set; }

    [BindProperty]
    public string AskConfirmation { get; set; }

    [BindProperty]
    public bool JavascriptIsEnabled { get; set; }

    public bool AskResetConfirmation { get; set; }

    [BindProperty]
    public ConfiguracaoPorUsuario Configuracoes { get; set; } = default!;

    public ConfiguracoesModel(
        MeuPontoDbContext db,
        IMemoryCache cache,
        ILogger<ConfiguracoesModel> logger)
    {
        _db = db;

        _cache = cache;

        _logger = logger;
    }

    public async Task<IActionResult> OnGet()
    {
        ResetSuccess = false;

        Configuracoes = await _db.Configuracoes.FindAsync(User.Identity.Name);

        if (Configuracoes == null)
        {
            Configuracoes = new ConfiguracaoPorUsuario();
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(string command)
    {
        if (AskConfirmation == "Reset 2")
        {
            AskResetConfirmation = true;

            ViewData.ShowModal(true);
        }

        if (command == "Reset")
        {
            _db.Database.EnsureDeleted();
            _db.Database.EnsureCreated();
            _cache.Remove("JavascriptIsEnabled");

            ResetSuccess = true;
        }

        var configuracoes = await _db.Configuracoes.FindAsync(User.Identity.Name);

        if (configuracoes == null)
        {
            configuracoes = new ConfiguracaoPorUsuario
            {
                UserName = User.Identity.Name,
                JavascriptIsEnabled = JavascriptIsEnabled
            };

            _db.Configuracoes.Add(configuracoes);
        }

        if (JavascriptIsEnabled)
        {
            configuracoes.JavascriptIsEnabled = true;
        }
        else
        {
            configuracoes.JavascriptIsEnabled = false;
        }

        try
        {
            await _db.SaveChangesAsync();

            _cache.Set("JavascriptIsEnabled", JavascriptIsEnabled);

            HttpContext.JavascriptIsEnabled(JavascriptIsEnabled);
        }
        catch (Exception _)
        {
            throw;
        }

        return Page();
    }
}