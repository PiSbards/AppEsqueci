using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppEsqueci.Model;
using AppEsqueci.Services;

namespace AppEsqueci.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageListar : ContentPage
    {
        public PageListar()
        {
            InitializeComponent();
            atualizaLista();
        }

        public void atualizaLista()
        {
            string titulo = "";
            if (txtNota.Text != null) titulo = txtNota.Text;            
            ServiceDBNotas dbNotas = new ServiceDBNotas(App.DbPath);
            if (swFavoritos.IsToggled)
            {
                ListaNotas.ItemsSource = dbNotas.Localizar(titulo, true);
            }
            else
            {
                ListaNotas.ItemsSource = dbNotas.Localizar(titulo);
            }
        }

        private void swFavoritos_Toggled(object sender, ToggledEventArgs e)
        {
            atualizaLista();
        }

        private void btLocalizar_Clicked(object sender, EventArgs e)
        {
            atualizaLista();
        }

        private void ListaNotas_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ModelNotas nota = (ModelNotas)ListaNotas.SelectedItem;
            MasterDetailPage p = (MasterDetailPage)Application.Current.MainPage;
            p.Detail = new NavigationPage(new PageCadastrar(nota));
        }
    }
}