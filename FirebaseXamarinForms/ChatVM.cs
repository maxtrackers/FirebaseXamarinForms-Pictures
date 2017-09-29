using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
namespace FirebaseXamarinForms
{
    class ChatVM
    {

        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        #endregion

        private Chat Chat { get; set; }

        public string Llave
        {
            get
            {
                return Chat.Llave;
            }
            set
            {
                Chat.Llave = value;
                OnPropertyChanged(nameof(Llave));
            }
        }

        public string NombreChat
        {
            get
            {
                return Chat.NombreChat;
            }
            set
            {
                Chat.NombreChat = value;
                OnPropertyChanged(nameof(NombreChat));
            }
        }

        public string MensajeChat
        {
            get
            {
                return Chat.MensajeChat;
            }
            set
            {
                Chat.MensajeChat = value;
                OnPropertyChanged(nameof(MensajeChat));
            }
        }


        public DateTime FechaModificacionChat
        {
            get
            {
                return Chat.FechaModificacionChat;
            }
            set
            {
                Chat.FechaModificacionChat = value;
                OnPropertyChanged(nameof(FechaModificacionChat));
            }
        }

        public  ChatVM(Chat @chat)
        {
            Chat = @chat;
        }
    }
}

