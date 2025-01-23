using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using demoDrozdov.Context;
using demoDrozdov.Models;
using Avalonia.Input;
using System.Collections.ObjectModel;

namespace demoDrozdov
{
    public partial class MainWindow : Window
    {
        public Partner? UpdatedPartner { get; set; }
        public ObservableCollection<Partner> partners {  get; set; }
        public MainWindow()
        {
            InitializeComponent();
            DatabaseLoad();
            
        }

        public void DatabaseLoad()
        {
           partners = new ObservableCollection<Partner>(Helper.Database.Partners);
            Partners.ItemsSource = partners;
            if (UpdatedPartner != null)
            {
                partners.Add(UpdatedPartner);
            }

   
        }
        
        private void EditPartner(object? sender, RoutedEventArgs e)
        {
            var selectedPartner = (Partner)Partners.SelectedItem;
            NewPartner newPartner = new NewPartner(selectedPartner);
            newPartner.Show();
            Close();

        }

        private void exit(object? sender, RoutedEventArgs e)
        {
            Close();    
        }

        private void newPartner(object? sender, RoutedEventArgs e)
        {
            NewPartner newPartner = new NewPartner();
            newPartner.Show();
            Close();

        }
    }
}