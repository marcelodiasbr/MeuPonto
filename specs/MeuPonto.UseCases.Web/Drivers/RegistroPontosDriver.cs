﻿using AngleSharp.Html.Dom;
using MeuPonto.Helpers;
using MeuPonto.Support;
using System.ComponentModel;
using MeuPonto.Models.Pontos;

namespace MeuPonto.Drivers;

public class RegistroPontosDriver
{
    private readonly AngleSharpContext _angleSharp;

    public IHtmlDocument Document { get; private set; }

    public IHtmlAnchorElement RegistroPontoAnchor { get; private set; }

    public RegistroPontosDriver(AngleSharpContext angleSharp)
    {
        _angleSharp = angleSharp;
    }

    public void GoTo()
    {
        Document = _angleSharp.GetDocument("/Pontos");

        RegistroPontoAnchor = Document.GetAnchor("Criacao.Ponto");

        //RegistroPontoAnchor.Should().NotBeNull("o registro de pontos deve ter um link para o registro de ponto");
    }

    public Ponto SolicitarRegistroPonto()
    {
        GoTo();

        Document = _angleSharp.GetDocument(RegistroPontoAnchor.Href);

        var form = Document.GetForm();

        var dataHoraInput = form.GetInput("Ponto.DataHora");
        var momentoInput = form.GetCheckedRadioInput("Ponto.MomentoId");
        var pausaInput = form.GetCheckedRadioInput("Ponto.PausaId");

        var dataHoraValue = string.IsNullOrEmpty(dataHoraInput.Value) ? new DateTime?() : DateTime.Parse(dataHoraInput.Value);
        var momentoValue = momentoInput == null ? null : momentoInput.Value;
        var pausaValue = pausaInput == null ? null : pausaInput.Value;

        var ponto = new Ponto
        {
            DataHora = dataHoraValue,
            ContratoId = null,
            MomentoId = string.IsNullOrEmpty(momentoValue) ? null : (MomentoEnum)Enum.Parse(typeof(MomentoEnum), momentoValue),
            PausaId = string.IsNullOrEmpty(pausaValue) ? null : (PausaEnum)Enum.Parse(typeof(PausaEnum), pausaValue),
            Observacao = form.GetTextArea("Ponto.Observacao").Value
        };

        return ponto;
    }

    public void RegistrarPonto(Ponto ponto)
    {
        GoTo();

        Document = _angleSharp.GetDocument(RegistroPontoAnchor.Href);

        var form = Document.GetForm();

        if (ponto.Contrato != null)
        {
            var contratoIdOption = form.GetSelect("Ponto.ContratoId").GetOption(ponto.Contrato.Nome);

            if (contratoIdOption != null)
            {
                contratoIdOption.IsSelected = true;
            }
        }
        if (ponto.DataHora != null)
        {
            form.GetInput("Ponto.DataHora").Value = ponto.DataHora.Value.ToString("yyyy-MM-dd\\THH:mm:ss");
        }
        if (ponto.MomentoId != null)
        {
            form.GetInput("Ponto.MomentoId", ponto.MomentoId.GetDisplayName()).IsChecked = true;
        }
        if (ponto.PausaId != null)
        {
            form.GetInput("Ponto.PausaId", ponto.PausaId.GetDisplayName()).IsChecked = true;
        }
        form.GetTextArea("Ponto.Observacao").Value = ponto.Observacao;

        var submitButton = form.GetSubmitButton();

        var resultPage = _angleSharp.Send(form, submitButton);

        Document = _angleSharp.GetDocument(resultPage);

        var hasErrors = Document.GetValidationErrors().Any();

        if (hasErrors)
        {
            var erros = Document.GetValidationErrors();

            var span = erros.FirstSpan();

            throw new Exception(span.InnerHtml);
        }
        else
        {
            //var pontoRegistrado = ObtemDetalhes();

            //return pontoRegistrado;
        }
    }

    private Ponto ObtemDetalhes()
    {
        var hasErrors = Document.GetValidationErrors().Any();

        //hasErrors.Should().BeFalse();

        var dl = Document.GetDefinitionList("Ponto");

        //bool estimado = false;

        //bool.TryParse(((IHtmlSelectElement)dl.QuerySelector("dd.estimado > select")).Value, out estimado);

        var momentoValue = dl.GetDataListItem("Momento").GetInput().Value;
        var pausaValue = dl.GetDataListItem("Pausa").GetInput().Value;

        var pontoRegistrado = new Ponto
        {
            Contrato = new()
            {
                Nome = dl.GetDataListItem("Contrato").GetString()
            },
            DataHora = DateTime.Parse(dl.GetDataListItem("DataHora").GetString()),
            MomentoId = (MomentoEnum)Enum.Parse(typeof(MomentoEnum), momentoValue),
            PausaId = string.IsNullOrEmpty(pausaValue) ? null : (PausaEnum)Enum.Parse(typeof(PausaEnum), pausaValue),
            Estimado = dl.GetDataListItem("Estimado").GetInput().IsChecked,
            Observacao = dl.GetDataListItem("Observacao").TextContent
        };

        return pontoRegistrado;
    }
}
