using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AsNum.XFControls;
using Xamarin.Forms;

namespace FirebaseXamarinForms
{
    public partial class XFControlsCV : ContentView
    {
        public XFControlsCV()
        {
            InitializeComponent();
            CheckBox chk = new CheckBox();
            chk.Text = "El seis por código";
            chk.ShowLabel = true;
            chk.ClassId = "ElSeis";
            chk.CheckChanged += CheckBox_CheckChanged;
            slChecks.Children.Add(chk);
        }

        private void CheckBox_CheckChanged(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(((CheckBox)sender).ClassId + ":" + ((CheckBox)sender).Checked.ToString());
        }
    }
}
