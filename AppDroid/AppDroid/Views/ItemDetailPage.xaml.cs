using AppDroid.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace AppDroid.Views
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