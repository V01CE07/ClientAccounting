using System.Collections.Generic;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using demoDrozdov.Context;
using demoDrozdov.Models;
using Microsoft.EntityFrameworkCore;

namespace demoDrozdov;

public partial class NewPartner : Window
{
    private Partner currentPartner {  get; set; }
    public bool IsNewPartner { get; set; }
    public NewPartner()
    {
        InitializeComponent();
        currentPartner = new Partner();
    }
    public NewPartner(Partner partner)
    {
        InitializeComponent();
        currentPartner = partner;
        partnerModel.DataContext = currentPartner;
        IsNewPartner = false;

    }

    public void createPartner(object? sender, RoutedEventArgs e)
    {
        if (IsNewPartner)
        {
            Helper.Database.Partners.Add(currentPartner);
        }
        else
        {
            Helper.Database.Partners.Update(currentPartner);
        }
        Helper.Database.SaveChanges();
        var MainWindow = new MainWindow();
        MainWindow.UpdatedPartner = currentPartner;
        MainWindow.Show();
        Close();
        



    }

    private void goToPartners(object? sender, RoutedEventArgs e)
    {
        MainWindow mainWindow = new MainWindow();   
        mainWindow.Show();
        Close();
    }
}