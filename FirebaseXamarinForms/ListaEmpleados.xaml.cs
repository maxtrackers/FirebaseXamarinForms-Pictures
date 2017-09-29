using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.ComponentModel;
using AsNum.XFControls;
namespace FirebaseXamarinForms
{
    
        public partial class ListaEmpleados : ContentView
    {
        public ListView ListView { get; set; } = new ListView();

        Dictionary<string, string> valores = new Dictionary<string, string>();
        ObservableCollection<ChatVM> ListViewData { get; set; } = new ObservableCollection<ChatVM>();

        public ListaEmpleados()
        {
            
            

            InitializeComponent();
            
            listViewChat.ItemsSource = ListViewData;
            ListenToStream();
            
        }

        private async void ListenToStream()
        {
            IFirebaseConfig config = new FirebaseConfig
            {
                AuthSecret = "a9UxW4ZVfdJRGHHQ8NusZmTZ0c3NRZgSlrakVXXM",
                BasePath = "https://myxamarintest.firebaseio.com//"
            };
            IFirebaseClient client;
            client = new FirebaseClient(config);

            await client.OnAsync("mensajes", added: (sender, args, d) =>
            {
                //Gets the Unique ID and deletes the any other string attached to it
                string dataFromFB = args.Data;
                string paths = args.Path;


                valores.Add(paths, dataFromFB);
                if (valores.Count >= 5)
                {
                    Chat ct = new Chat();
                    ChatVM ctVM = new ChatVM(ct);
                    for (int i = 0; i < valores.Count; i++)
                    {
                        if (valores.ElementAt(i).Key.EndsWith("MensajeChat"))
                        {
                            ct.MensajeChat = valores.ElementAt(i).Value;
                        }
                        else if (valores.ElementAt(i).Key.EndsWith("NombreChat"))
                        {
                            ct.NombreChat = valores.ElementAt(i).Value;
                        }
                    }


                    ListViewData.Insert(0, ctVM);
                    //ListViewData.Add();
                 //   if (listaChat.Count >= 20)
                 //   {
                     
                        
                        
                  //  }
                    System.Diagnostics.Debug.WriteLine("Lista: " + ListViewData.Count.ToString());
                    // DisplayAlert("Alert", valores.ToString(), "OK");
                    valores.Clear();
                }


            }, changed: (sender, args, d) =>
            {
                //Gets the Unique ID and deletes the any other string attached to it
                string dataFromFB = args.Data;
                string paths = args.Path;

            }
              , removed: (sender, args, d) =>
              {
                  //Gets the Unique ID and deletes the any other string attached to it
                  var dataFromFB = args;
                  string paths = args.Path;

              });



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
                string so = "";
                if(Device.RuntimePlatform==Device.iOS)
                {
                    so = "IPhone dice:";
                }
                else
                {
                    so = "Android dice:";

                }
             

                Chat mc = new Chat()
                {
                    Llave = "",
                    NombreChat = so,
                    MensajeChat = DateTime.Now.Minute.ToString() + "-" + DateTime.Now.Second.ToString() + name_,
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
        private async void btnSend_Clicked(object sender, EventArgs e)
        {
            try
            {
                BusyIndicator.IsBusy = true;
                await SendData(txtMensaje.Text, DateTime.Now.Minute.ToString());
                txtMensaje.Text = "";
                txtMensaje.Focus();
                BusyIndicator.IsBusy = false;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
    }
}
