using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using Xamarin.Forms;

namespace FirebaseXamarinForms
{
	public class SendPage : ContentPage
	{
        private async void ListenToStream()
        {
            IFirebaseConfig config = new FirebaseConfig
            {
                AuthSecret = "a9UxW4ZVfdJRGHHQ8NusZmTZ0c3NRZgSlrakVXXM",
                BasePath = "https://myxamarintest.firebaseio.com//"
            };
            IFirebaseClient client;
            client = new FirebaseClient(config);
            
            await client.OnAsync("MyClass", (sender, args, d) =>
            {
                //Gets the Unique ID and deletes the any other string attached to it
                string dataFromFB = args.Data;
                string paths = args.Path;
               /* string key = RemoveNameSubstring(paths);
                string uniqueKey = key.Split('/').Last();
                if (keyHolder.ContainsKey(uniqueKey))
                {
                    keyHolder[uniqueKey] = dataFromFB;
                    AddToListView(dataFromFB);
                }
                else
                {
                    keyHolder.Add(uniqueKey, dataFromFB);
                    AddToListView(dataFromFB);
                }*/
            });

        }

        public SendPage ()
		{
			Title = "Send";

			var entry_name = new Entry {
				Placeholder = "Enter your name",
				Keyboard = Keyboard.Text
			};

			var entry_age = new Entry {
				Placeholder = "Enter your age",
				Keyboard = Keyboard.Numeric
			};


			var button_send = new Button {
				Text = "Send"
			};

            ListenToStream();


            button_send.Clicked += async (object sender, EventArgs e) => {
				try {

					button_send.IsEnabled = false;
					await SendData (entry_name.Text, entry_age.Text);
					button_send.IsEnabled = true;
					await DisplayAlert ("", "Data uploaded successfully on Firebase", "OK");

				} catch (Exception ex) {
					System.Diagnostics.Debug.WriteLine (ex.ToString ());
					await DisplayAlert ("", "Something wrong :/", "Ouf");
					button_send.IsEnabled = true;
				}
			};

			Content = new StackLayout {
				Children = {
					entry_name,
					entry_age,
					button_send
				}
			};
		}

		public async Task SendData (string name_, string age_)
		{

			IFirebaseConfig config = new FirebaseConfig {
				AuthSecret = "AchfUEuAOVILqYAz3nOw2NB0QLvW3qVbUfrxloot",
				BasePath = "https://fir-xamarinforms.firebaseio.com/"
			};
			IFirebaseClient client = new FirebaseClient (config);

			List<Chat> myclass_list = new List<Chat> ();

            myclass_list.Add(new Chat() {
                Llave = "",
                NombreChat = DateTime.Now.Month.ToString()
                
			});

			//await client.SetAsync ("MyClass", myclass_list);


		}
	}

}