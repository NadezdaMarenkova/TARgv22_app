using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TARgv22_app
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TimerPage : ContentPage
    {
        public TimerPage()
        {
            InitializeComponent();
        }

        private async void btn_tagasi_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        bool onoff = false;
        private async void ShowTime()
        {
            while (onoff)
            {
                timer_value.Text = DateTime.Now.ToString("T");
                await Task.Delay(1000);
            }
        }
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            if (onoff==true)
            {
                onoff= false;
                timer_start.Text = "Start";
            }
            else
            {
                onoff= true;
                ShowTime();
                timer_start.Text = "Stop";
            }
        }
    }
}