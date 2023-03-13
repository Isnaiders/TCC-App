using System.ComponentModel;
using TCC_App.ViewModels;
using Xamarin.Forms;

namespace TCC_App.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}