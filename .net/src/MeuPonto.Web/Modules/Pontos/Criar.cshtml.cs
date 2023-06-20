﻿using MeuPonto.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MeuPonto.Modules.Pontos;

public class CriarModel : PageModel
{
    private readonly MeuPontoDbContext _db;

    public CriarModel(MeuPontoDbContext db)
    {
        _db = db;
    }

    public IActionResult OnGet()
    {
        ViewData["PerfilId"] = new SelectList(_db.Perfis, "Id", "Nome");
        return Page();
    }

    [BindProperty]
    public Ponto Ponto { get; set; }

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
        var transaction = new TransactionContext(User.Identity.Name);

        if (!ModelState.IsValid)
        {
            return Page();
        }

        Ponto.RecontextualizaPonto(transaction);

        var perfil = await _db.Perfis.FindByIdAsync(Ponto.PerfilId, User.Identity.Name);

        perfil.QualificaPonto(Ponto);

        _db.Pontos.Add(Ponto);
        await _db.SaveChangesAsync();

        return RedirectToPage("./Detalhar", new { id = Ponto.Id });
    }
}
