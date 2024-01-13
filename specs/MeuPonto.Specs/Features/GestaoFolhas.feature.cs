﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.9.0.0
//      SpecFlow Generator Version:3.9.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace MeuPonto.Features
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class GestaoFolhasFeature : object, Xunit.IClassFixture<GestaoFolhasFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private static string[] featureTags = ((string[])(null));
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "GestaoFolhas.feature"
#line hidden
        
        public GestaoFolhasFeature(GestaoFolhasFeature.FixtureData fixtureData, MeuPonto_XUnitAssemblyFixture assemblyFixture, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("pt-br"), "Features", "Gestão Folhas", null, ProgrammingLanguage.CSharp, featureTags);
            testRunner.OnFeatureStart(featureInfo);
        }
        
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public void TestInitialize()
        {
        }
        
        public void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Xunit.Abstractions.ITestOutputHelper>(_testOutputHelper);
        }
        
        public void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        void System.IDisposable.Dispose()
        {
            this.TestTearDown();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Trabalhador abre uma folha de ponto usando seu único contrato")]
        [Xunit.TraitAttribute("FeatureTitle", "Gestão Folhas")]
        [Xunit.TraitAttribute("Description", "Trabalhador abre uma folha de ponto usando seu único contrato")]
        public void TrabalhadorAbreUmaFolhaDePontoUsandoSeuUnicoContrato()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Trabalhador abre uma folha de ponto usando seu único contrato", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 7
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 8
 testRunner.Given("que o trabalhador tem um contrato cadastrado com o nome \'Marcelo - Ateliex\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line hidden
#line 9
 testRunner.Given("que o trabalhador qualifica a folha com o contrato \'Marcelo - Ateliex\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line hidden
#line 10
 testRunner.When("o trabalhador abrir uma folha de ponto", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line hidden
#line 11
 testRunner.Then("uma folha de ponto deverá ser aberta", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Então ");
#line hidden
#line 12
 testRunner.And("o contrato da folha de ponto deverá deverá ser \'Marcelo - Ateliex\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Trabalhador abre uma folha ponto para o mês de novembro de 2022")]
        [Xunit.TraitAttribute("FeatureTitle", "Gestão Folhas")]
        [Xunit.TraitAttribute("Description", "Trabalhador abre uma folha ponto para o mês de novembro de 2022")]
        public void TrabalhadorAbreUmaFolhaPontoParaOMesDeNovembroDe2022()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Trabalhador abre uma folha ponto para o mês de novembro de 2022", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 16
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 17
 testRunner.Given("que o trabalhador tem um contrato cadastrado", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line hidden
#line 18
 testRunner.And("que o trabalhador deseja apurar a folha de ponto da competência \'2022/11\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line hidden
#line 19
 testRunner.When("o trabalhador abrir uma folha de ponto", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line hidden
#line 20
 testRunner.Then("uma folha de ponto deverá ser aberta", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Então ");
#line hidden
#line 21
 testRunner.And("o status da folha de ponto deverá ser \'Aberta\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line hidden
#line 22
 testRunner.And("a folha de ponto deverá ter \'30\' dias", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line hidden
#line 24
 testRunner.But("a folha de ponto não deverá ter tempo total apurado", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Mas ");
#line hidden
#line 25
 testRunner.And("a folha de ponto não deverá ter tempo total período anterior", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line hidden
#line 26
 testRunner.And("a folha de ponto não deverá ter uma observação", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Trabalhador abre uma folha de ponto anotando que deve confirmar os feriados do mê" +
            "s")]
        [Xunit.TraitAttribute("FeatureTitle", "Gestão Folhas")]
        [Xunit.TraitAttribute("Description", "Trabalhador abre uma folha de ponto anotando que deve confirmar os feriados do mê" +
            "s")]
        public void TrabalhadorAbreUmaFolhaDePontoAnotandoQueDeveConfirmarOsFeriadosDoMes()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Trabalhador abre uma folha de ponto anotando que deve confirmar os feriados do mê" +
                    "s", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 30
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 31
 testRunner.Given("que o trabalhador tem um contrato cadastrado", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line hidden
#line 32
 testRunner.And("que o trabalhador anota a seguinte observação na folha de ponto:", "Verificar se a última sexta-feira do mês vai ser feriado.", ((TechTalk.SpecFlow.Table)(null)), "E ");
#line hidden
#line 36
 testRunner.When("o trabalhador abrir uma folha de ponto", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line hidden
#line 37
 testRunner.Then("uma folha de ponto deverá ser aberta", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Então ");
#line hidden
#line 38
 testRunner.And("a folha de ponto deverá ter uma observação", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableTheoryAttribute(DisplayName="Trabalhador registra a entrada e a saída do expediente")]
        [Xunit.TraitAttribute("FeatureTitle", "Gestão Folhas")]
        [Xunit.TraitAttribute("Description", "Trabalhador registra a entrada e a saída do expediente")]
        [Xunit.InlineDataAttribute("27/11/2022 09:14", "27/11/2022 11:30", "02:16", new string[0])]
        [Xunit.InlineDataAttribute("27/11/2022 12:27", "27/11/2022 18:03", "05:36", new string[0])]
        public void TrabalhadorRegistraAEntradaEASaidaDoExpediente(string entrada, string saida, string apurado, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("entrada", entrada);
            argumentsOfScenario.Add("saída", saida);
            argumentsOfScenario.Add("apurado", apurado);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Trabalhador registra a entrada e a saída do expediente", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 42
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
                TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                            "dia semana",
                            "tempo"});
                table3.AddRow(new string[] {
                            "Sunday",
                            "00:00:00"});
                table3.AddRow(new string[] {
                            "Monday",
                            "08:00:00"});
                table3.AddRow(new string[] {
                            "Tuesday",
                            "08:00:00"});
                table3.AddRow(new string[] {
                            "Wednesday",
                            "08:00:00"});
                table3.AddRow(new string[] {
                            "Thursday",
                            "08:00:00"});
                table3.AddRow(new string[] {
                            "Friday",
                            "08:00:00"});
                table3.AddRow(new string[] {
                            "Saturday",
                            "00:00:00"});
#line 43
 testRunner.Given("que o trabalhador tem um contrato cadastrado com a seguinte jornada de trabalho s" +
                        "emanal prevista:", ((string)(null)), table3, "Dado ");
#line hidden
#line 52
 testRunner.And(string.Format("que o trabalhador registrou a entrada no expediente às \'{0}\'", entrada), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line hidden
#line 53
 testRunner.And(string.Format("que o trabalhador registrou a saída no expediente às \'{0}\'", saida), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line hidden
#line 54
 testRunner.And("que o trabalhador tem uma folha de ponto aberta na competência \'2022/11\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line hidden
#line 55
 testRunner.When("o trabalhador apurar a folha de ponto", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line hidden
#line 56
 testRunner.Then(string.Format("o tempo total apurado da folha de ponto deverá ser de \'{0}\'", apurado), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Então ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Trabalhador confirma que uma folha de ponto aberta foi fechada")]
        [Xunit.TraitAttribute("FeatureTitle", "Gestão Folhas")]
        [Xunit.TraitAttribute("Description", "Trabalhador confirma que uma folha de ponto aberta foi fechada")]
        public void TrabalhadorConfirmaQueUmaFolhaDePontoAbertaFoiFechada()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Trabalhador confirma que uma folha de ponto aberta foi fechada", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 65
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 66
 testRunner.Given("que o trabalhador tem uma folha de ponto aberta na competência \'2022/11\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line hidden
#line 67
 testRunner.And("que o ano/mês é \'2022/11\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line hidden
#line 68
 testRunner.When("o trabalhador fechar a folha de ponto", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line hidden
#line 69
 testRunner.Then("a folha de ponto deverá ser fechada", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Então ");
#line hidden
#line 70
 testRunner.And("o status da folha de ponto deverá ser \'Fechada\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Trabalhador guarda a apuração mensal dos pontos registrados")]
        [Xunit.TraitAttribute("FeatureTitle", "Gestão Folhas")]
        [Xunit.TraitAttribute("Description", "Trabalhador guarda a apuração mensal dos pontos registrados")]
        public void TrabalhadorGuardaAApuracaoMensalDosPontosRegistrados()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Trabalhador guarda a apuração mensal dos pontos registrados", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 74
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 75
 testRunner.Given("que o trabalhador tem uma folha de ponto aberta na competência \'2022/11\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line hidden
#line 76
 testRunner.And("que o ano/mês é \'2022/11\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line hidden
                TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                            "data/hora",
                            "momento"});
                table4.AddRow(new string[] {
                            "27/11/2022 09:14",
                            "Entrada"});
                table4.AddRow(new string[] {
                            "27/11/2022 11:30",
                            "Saida"});
                table4.AddRow(new string[] {
                            "27/11/2022 12:27",
                            "Entrada"});
                table4.AddRow(new string[] {
                            "27/11/2022 18:03",
                            "Saida"});
#line 77
 testRunner.And("que os pontos registrados foram:", ((string)(null)), table4, "E ");
#line hidden
#line 83
 testRunner.When("o trabalhador fechar a folha de ponto", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line hidden
#line 84
 testRunner.Then("a folha de ponto deverá ser fechada", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Então ");
#line hidden
#line 85
 testRunner.And("o tempo total apurado deverá ser \'07:52\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line hidden
#line 86
 testRunner.But("o tempo total período anterior deverá ser nulo", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Mas ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                GestaoFolhasFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                GestaoFolhasFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
