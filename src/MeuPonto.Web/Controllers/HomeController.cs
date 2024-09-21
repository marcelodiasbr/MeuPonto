using MeuPonto.Extensions;
using MeuPonto.Models;
using MeuPonto.Models.Folhas;
using MeuPonto.Pages.Folhas;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace MeuPonto.Controllers;

[Authorize]
public class HomeController : Controller
{
    private readonly Data.MeuPontoDbContext _db;

    private readonly ILogger<HomeController> _logger;

    public HomeController(Data.MeuPontoDbContext db, ILogger<HomeController> logger)
    {
        _db = db;
        _logger = logger;
    }

    public async Task<IActionResult> Index()
    {
        var model = new IndexModel();

        if (User.Identity.IsAuthenticated == false)
        {
            return View(model);
        }

        var contratosSelectList = new SelectList(_db.Contratos.Where(x => x.UserId == User.GetUserId()), "Id", "Nome");

        ViewData["ContratoId"] = contratosSelectList;

        ViewData["HasContrato"] = contratosSelectList.Any();

        model.ApuracaoMensal = new ApuracaoMensalViewModel();

        var hoje = DateTime.Today;

        if (model.Competencia == null)
        {
            model.Competencia = hoje;
        }
        else
        {
            var competencia = model.Competencia;

            model.Folha = await _db.Folhas.FirstOrDefaultAsync(x => true
                && x.ContratoId == model.ContratoId
                && x.Competencia == competencia
                && x.UserId == User.GetUserId());

            if (model.Folha != null)
            {
                var competenciaAtual = new DateTime(hoje.Year, hoje.Month, 1);

                var competenciaFolha = model.Folha.Competencia.Value;

                var competenciaFolhaPosterior = competenciaFolha.AddMonths(1);

                model.ApuracaoMensal = await _db.ApurarFolha(model.Folha, User, hoje, competenciaAtual, competenciaFolha, competenciaFolhaPosterior);
            }
        }

        return View(model);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [AllowAnonymous]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
