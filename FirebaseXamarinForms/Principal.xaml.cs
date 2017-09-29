using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FirebaseXamarinForms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Principal : ContentPage
    {
        
        public Principal()
        {
            InitializeComponent();
            
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            drawer.MainContent = null;
            drawer.MainContent = (View)new DashboardView( );
            
            drawer.IsOpen = false;
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            drawer.MainContent = null;
            drawer.MainContent = (View)new ListaEmpleados();

            drawer.IsOpen = false;
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            drawer.MainContent = null;
            drawer.MainContent = (View)new XFControlsCV();

            drawer.IsOpen = false;
        }
    }
}
