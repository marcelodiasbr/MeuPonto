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
    public partial class ApuracaoPontosFeature : object, Xunit.IClassFixture<ApuracaoPontosFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private static string[] featureTags = ((string[])(null));
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "ApuracaoPontos.feature"
#line hidden
        
        public ApuracaoPontosFeature(ApuracaoPontosFeature.FixtureData fixtureData, MeuPonto_XUnitAssemblyFixture assemblyFixture, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("pt-br"), "Features", "Apuração Pontos", "O sistema deverá fornecer para o trabalhador a capacidade de apurar seus pontos.", ProgrammingLanguage.CSharp, featureTags);
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
        
        [Xunit.SkippableTheoryAttribute(DisplayName="[Apurar Pontos] Trabalhador registra a entrada e a saída do expediente")]
        [Xunit.TraitAttribute("FeatureTitle", "Apuração Pontos")]
        [Xunit.TraitAttribute("Description", "[Apurar Pontos] Trabalhador registra a entrada e a saída do expediente")]
        [Xunit.TraitAttribute("Category", "wip")]
        [Xunit.InlineDataAttribute("27/11/2022 09:14", "27/11/2022 11:30", "02:16", new string[0])]
        [Xunit.InlineDataAttribute("27/11/2022 12:27", "27/11/2022 18:03", "05:36", new string[0])]
        public void ApurarPontosTrabalhadorRegistraAEntradaEASaidaDoExpediente(string entrada, string saida, string apurado, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "wip"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("entrada", entrada);
            argumentsOfScenario.Add("saída", saida);
            argumentsOfScenario.Add("apurado", apurado);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("[Apurar Pontos] Trabalhador registra a entrada e a saída do expediente", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 10
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
                TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                            "dia semana",
                            "tempo"});
                table1.AddRow(new string[] {
                            "Sunday",
                            "00:00:00"});
                table1.AddRow(new string[] {
                            "Monday",
                            "08:00:00"});
                table1.AddRow(new string[] {
                            "Tuesday",
                            "08:00:00"});
                table1.AddRow(new string[] {
                            "Wednesday",
                            "08:00:00"});
                table1.AddRow(new string[] {
                            "Thursday",
                            "08:00:00"});
                table1.AddRow(new string[] {
                            "Friday",
                            "08:00:00"});
                table1.AddRow(new string[] {
                            "Saturday",
                            "00:00:00"});
#line 11
 testRunner.Given("que existe um contrato aberto com a seguinte jornada de trabalho semanal prevista" +
                        ":", ((string)(null)), table1, "Dado ");
#line hidden
#line 20
 testRunner.And(string.Format("que o trabalhador registrou a entrada no expediente às \'{0}\'", entrada), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line hidden
#line 21
 testRunner.And(string.Format("que o trabalhador registrou a saída no expediente às \'{0}\'", saida), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line hidden
#line 22
 testRunner.And("que o trabalhador tem uma folha de ponto aberta na competência \'2022/11\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line hidden
#line 23
 testRunner.When("o trabalhador apurar a folha de ponto", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line hidden
#line 24
 testRunner.Then(string.Format("o tempo total apurado da folha de ponto deverá ser de \'{0}\'", apurado), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Então ");
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
                ApuracaoPontosFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                ApuracaoPontosFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
