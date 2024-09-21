using MeuPonto.Models.Folhas;
using MeuPonto.Pages.Folhas;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace MeuPonto.Models;

public class IndexModel
{
    [BindProperty(SupportsGet = true)]
    [DisplayName("Contrato")]
    public Guid? ContratoId { get; set; }

    [BindProperty(SupportsGet = true)]
    [DisplayName("Competência")]
    public DateTime? Competencia { get; set; }

    public Folha Folha { get; set; }

    public ApuracaoMensalViewModel ApuracaoMensal { get; set; }

}
