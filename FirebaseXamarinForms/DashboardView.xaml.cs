using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Telerik.XamarinForms.Chart;
using Xamarin.Forms;
using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
namespace FirebaseXamarinForms
{
    public partial class DashboardView : ContentView
    {
        public DashboardView()
        {
            InitializeComponent();
            
            /*NavigationPage.SetTitleIcon(this, "truck.png");
            App.Current.MainPage.Title = "Prueba de View";
            App.Current.MainPage.BackgroundColor = Color.FromHex("#174873");
            */
            
        }
        public async Task SendData(string name_, string age_)
        {
            try
            {
                IFirebaseConfig config = new FirebaseConfig
                {
                    AuthSecret = "a9UxW4ZVfdJRGHHQ8NusZmTZ0c3NRZgSlrakVXXM",
                    BasePath = "https://myxamarintest.firebaseio.com/"
                };
                IFirebaseClient client = new FirebaseClient(config);

                //List<MyClass> myclass_list = new List<MyClass>();

                /*myclass_list.Add(new MyClass()
                {
                    age = int.Parse(age_),
                    name = name_
                });*/

                Chat mc = new Chat()
                {
                    Llave = "",
                    NombreChat = "Nombre : " + DateTime.Now.Minute.ToString() + "-" + DateTime.Now.Second.ToString(),
                    MensajeChat = "Este es el mensaje del chat: " + DateTime.Now.Minute.ToString() + "-" + DateTime.Now.Second.ToString(),
                    TipoChat = "Chat",
                    FechaModificacionChat = DateTime.Now

                };

                await client.PushAsync("mensajes", mc);
                
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }


        }
        private void btnGrabar_Clicked(object sender, EventArgs e)
        {
            
            var series = new PieSeries();
            series.SetBinding(PieSeries.ItemsSourceProperty, new Binding("Data"));
            series.ValueBinding = new PropertyNameDataPointBinding("Value");
            chart.Series.Add(series);
            try
            {
                SendData(DateTime.Now.ToString(), DateTime.Now.Minute.ToString());
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            
        }
    }
}
