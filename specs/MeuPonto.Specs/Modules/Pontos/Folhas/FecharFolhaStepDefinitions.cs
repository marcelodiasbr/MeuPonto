using MeuPonto.Data;
using MeuPonto.Modules.Perfis;
using System.ComponentModel;

namespace MeuPonto.Modules.Pontos.Folhas;

[Binding]
public class FecharFolhaStepDefinitions
{
    private readonly ScenarioContext _scenario;

    private readonly GestaoFolhasContext _gestaoFolhas;

    private readonly GestaoFolhasInterface _gestaoFolhasInterface;

    private readonly MeuPontoDbContext _db;

    public FecharFolhaStepDefinitions(
        ScenarioContext scenario,
        GestaoFolhasContext gestaoFolhas,
        GestaoFolhasInterface gestaoFolhasInterface,
        MeuPontoDbContext db)
    {
        _scenario = scenario;

        _gestaoFolhas = gestaoFolhas;

        _gestaoFolhasInterface = gestaoFolhasInterface;

        _db = db;
    }

    [Given(@"que o trabalhador tem uma folha de ponto aberta")]
    public async Task GivenQueOTrabalhadorTemUmaFolhaDePontoAberta()
    {
        var perfil = CadastroPerfisStub.ObtemPerfil();

        _db.Perfis.Add(perfil);
        await _db.SaveChangesAsync();

        var competencia = new DateTime(2022, 11, 1);

        var folhaAberta = GestaoFolhasStub.ObtemFolhaAbertaFrom(perfil, competencia);

        _db.Folhas.Add(folhaAberta);
        await _db.SaveChangesAsync();

        _gestaoFolhas.ConsideraQueExiste(folhaAberta);
    }

    [Given(@"que o ano/mês é '([^']*)'")]
    public void GivenQueOAnoMesE(string competencia)
    {

    }

    [Given(@"que os pontos registrados foram:")]
    public async Task GivenQueOsPontosRegistradosForam(Table table)
    {
        var perfil = _db.Perfis.FirstOrDefault();

        var pontos = table.Rows.Select(row =>
        {
            var dataHora = DateTime.Parse(row["data/hora"]);

            var momento = (MomentoEnum)Enum.Parse(typeof(MomentoEnum), row["momento"]);

            return RegistroPontosStub.ObtemPonto(perfil, dataHora, momento);
        });

        _db.Pontos.AddRange(pontos);
        await _db.SaveChangesAsync();
    }

    [When(@"o trabalhador fechar a folha de ponto")]
    public async Task WhenOTrabalhadorFecharAFolhaDePonto()
    {
        var folhaFechada = await _gestaoFolhasInterface.FecharFolha(_gestaoFolhas.Folha);

        _gestaoFolhas.Define(folhaFechada);
    }

    [Then(@"a folha de ponto deverá ser fechada")]
    public void ThenAFolhaDePontoDeveraSerFechada()
    {
        _gestaoFolhas.FolhaAberta.Status.Nome.Should().Be(StatusEnum.Fechada.GetDisplayName());
    }

    [Then(@"o tempo total apurado deverá ser '([^']*)'")]
    public void ThenOTempoTotalApuradoDeveraSer(TimeSpan tempoTotalApurado)
    {
        _gestaoFolhas.FolhaAberta.ApuracaoMensal.TempoTotalApurado.Should().Be(tempoTotalApurado);
    }

    [Then(@"o tempo total período anterior deverá ser nulo")]
    public void ThenOTempoTotalPeriodoAnteriorDeveraSerNulo()
    {
        _gestaoFolhas.FolhaAberta.ApuracaoMensal.TempoTotalPeriodoAnterior.Should().BeNull();
    }

    [Then(@"o tempo total período anterior deverá ser '([^']*)'")]
    public void ThenOTempoTotalPeriodoAnteriorDeveraSer(TimeSpan tempoTotalPeriodoAnterior)
    {
        _gestaoFolhas.FolhaAberta.ApuracaoMensal.TempoTotalPeriodoAnterior.Should().Be(tempoTotalPeriodoAnterior);
    }
}
