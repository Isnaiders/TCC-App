using System;
using System.Collections.Generic;
using System.ComponentModel;
using TCC_App.Models;
using TCC_App.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TCC_App.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}