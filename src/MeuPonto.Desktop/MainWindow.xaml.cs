﻿using MeuPonto.Windows.Contratos;
using MeuPonto.Windows.Folhas;
using MeuPonto.Windows.Pontos;
using MeuPonto.Windows.Trabalhadores;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace MeuPonto;

public partial class MainWindow : Window
{
    public IServiceProvider ServiceProvider { get; }

    public MainWindow(IServiceProvider serviceProvider)
    {
        InitializeComponent();

        ServiceProvider = serviceProvider;
    }

    private void CadastroTrabalhadoresMenuItem_Click(object sender, RoutedEventArgs e)
    {
        var cadastroTrabalhadoresWindow = ServiceProvider.GetRequiredService<CadastroTrabalhadoresWindow>();

        cadastroTrabalhadoresWindow.Show();
    }

    private void CadastroEmpregadoresMenuItem_Click(object sender, RoutedEventArgs e)
    {
        var cadastroEmpregadoresWindow = ServiceProvider.GetRequiredService<CadastroEmpregadoresWindow>();

        cadastroEmpregadoresWindow.Show();
    }

    private void GestaoContratosMenuItem_Click(object sender, RoutedEventArgs e)
    {
        var gestaoContratosWindow = ServiceProvider.GetRequiredService<GestaoContratosWindow>();

        gestaoContratosWindow.Show();
    }

    private void RegistroPontosMenuItem_Click(object sender, RoutedEventArgs e)
    {
        var registroPontosForm = ServiceProvider.GetRequiredService<RegistroPontosWindow>();

        registroPontosForm.Show();
    }

    private void GestaoFolhasMenuItem_Click(object sender, RoutedEventArgs e)
    {
        var gestaoFolhasForm = ServiceProvider.GetRequiredService<GestaoFolhasWindow>();

        gestaoFolhasForm.Show();
    }

    private void BackupComprovantesMenuItem_Click(object sender, RoutedEventArgs e)
    {
        var backupComprovantesForm = ServiceProvider.GetRequiredService<BackupComprovantesWindow>();

        backupComprovantesForm.Show();
    }

    private void configuracoesMenuItem_Click(object sender, RoutedEventArgs e)
    {
        //using (var scope = ServiceProvider.CreateScope())
        //{
        //    var db = scope.ServiceProvider.GetRequiredService<MeuPontoDbContext>();

        //    foreach (var trabalhador in db.Trabalhadores)
        //    {
        //        trabalhador.UserId = trabalhador.Id.ToString();
        //    }

        //    db.SaveChanges();

        //    foreach (var empregador in db.Empregadores)
        //    {
        //        empregador.UserId = empregador.TrabalhadorId.ToString();
        //    }

        //    db.SaveChanges();

        //    foreach (var contrato in db.Contratos)
        //    {
        //        contrato.UserId = contrato.TrabalhadorId.ToString();
        //    }

        //    db.SaveChanges();

        //    foreach (var ponto in db.Pontos)
        //    {
        //        ponto.UserId = ponto.TrabalhadorId.ToString();
        //    }

        //    db.SaveChanges();

        //    foreach (var comprovante in db.Comprovantes)
        //    {
        //        comprovante.UserId = comprovante.TrabalhadorId.ToString();
        //    }

        //    db.SaveChanges();

        //    foreach (var folha in db.Folhas)
        //    {
        //        folha.UserId = folha.TrabalhadorId.ToString();
        //    }

        //    db.SaveChanges();
        //}

        //_db.Database.EnsureDeleted();

        //_db.Database.Migrate();

        //_db.Database.CloseConnection();

        //statusBarLabel.Content = "Sucesso.";
    }
}
