using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppDroid.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppPage : ContentPage
    {
        public AppPage()
        {
            InitializeComponent();
            var htmlcontent = new HtmlWebViewSource();
            htmlcontent.Html = "<iframe width='560' height='315' src='https://www.youtube.com/embed/peX9k5wMqWk' frameborder='0' allow='accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture' allowfullscreen></iframe>";
            Video.Source = htmlcontent;

            
        }

        private void BtnDescargar_Click(object sender, EventArgs e)
        {

        }
    }
}