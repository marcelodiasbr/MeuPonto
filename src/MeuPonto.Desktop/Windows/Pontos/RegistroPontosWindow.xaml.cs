﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using MeuPonto.Models.Pontos;

namespace MeuPonto.Windows.Pontos;

public partial class RegistroPontosWindow : Window
{
    private readonly IServiceScope _scope;

    private readonly Data.MeuPontoDbContext _db;

    private CollectionViewSource _pontosViewSource;

    private CollectionViewSource _contratosViewSource;

    private ObservableCollection<Ponto> _pontos;

    public RegistroPontosWindow(IServiceProvider serviceProvider)
    {
        InitializeComponent();

        _scope = serviceProvider.CreateScope();

        _db = _scope.ServiceProvider.GetRequiredService<Data.MeuPontoDbContext>();
    }

    private async void Window_Loaded(object sender, RoutedEventArgs e)
    {
        Cursor = Cursors.Wait;

        SetStatusBar("Carregando registro de pontos...");

        _pontosViewSource = ((CollectionViewSource)(this.FindResource("pontosViewSource")));

        await _db.Pontos
            //.Include(p => p.Recursos)
            .LoadAsync();

        _pontos = _db.Pontos.Local.ToObservableCollection();

        foreach (var ponto in _pontos)
        {
            //modelo.RecursosChanged += Modelo_RecursosChanged;
        }

        _pontosViewSource.Source = _pontos;

        Cursor = null;

        //

        SetStatusBar("Carregando contratos...");

        _contratosViewSource = ((CollectionViewSource)(this.FindResource("contratosViewSource")));

        var contratos = await _db.Contratos
            .ToListAsync();

        _contratosViewSource.Source = contratos;

        SetStatusBar("Pronto.");
    }

    private void SetStatusBar(string value)
    {
        statusBarLabel.Content = value;

        //statusBarTimer.Enabled = true;
    }

    private async void refreshButton_Click(object sender, RoutedEventArgs e)
    {
        Cursor = Cursors.Wait;

        SetStatusBar("Carregando registro de pontos...");

        await _db.Pontos
            //.Include(p => p.Recursos)
            .LoadAsync();

        _pontos = _db.Pontos.Local.ToObservableCollection();

        _pontosViewSource.Source = _pontos;

        SetStatusBar("Pronto.");

        Cursor = null;
    }

    private async void SaveButton_Click(object sender, RoutedEventArgs e)
    {
        //CollectionViewSource modelosViewSource = ((CollectionViewSource)(this.FindResource("modelosViewSource")));

        //var observableCollection = (ModelosCollection)modelosViewSource.Source;

        try
        {
            await _db.SaveChangesAsync();

            SetStatusBar("Pontos salvos com sucesso.");
        }
        catch (Exception ex)
        {
            SetStatusBar(ex.Message);
        }
    }

    private void Window_Unloaded(object sender, RoutedEventArgs e)
    {
        //_db.Database.CloseConnection();

        _db.Dispose();

        _scope.Dispose();
    }
}
