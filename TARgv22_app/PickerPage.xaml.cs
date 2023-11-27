using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TARgv22_app
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PickerPage : ContentPage
    {
        Picker picker;
        WebView webView;
        StackLayout st;
        Frame frame;

        string[] lehed = new string[4] { "https://moodle.edu.ee", "https://www.tthk.ee/", "https://tahvel.edu.ee", "https://thk.edupage.org/timetable/view.php?fullscreen=1" };
        public PickerPage()
        {
            picker = new Picker
            {
                Title = "Webilehed"
            };
            picker.Items.Add("Moodle");
            picker.Items.Add("TTHK");
            picker.Items.Add("Tahvel");
            picker.Items.Add("Tunniplaan");
            picker.SelectedIndexChanged += Picker_SelectedIndexChanged;
            webView = new WebView();

            frame = new Frame
            {
                BorderColor = Color.AliceBlue,
                CornerRadius = 20,
                HeightRequest = 20,
                WidthRequest = 400,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HasShadow = true
            };
            st = new StackLayout { Children = { picker, webView } };
            Content = st;


        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (webView != null)
            {
                st.Children.Remove(webView);
            }
            webView = new WebView
            {
                Source = new UrlWebViewSource { Url = lehed[picker.SelectedIndex] },
                VerticalOptions = LayoutOptions.FillAndExpand,
            };
            st.Children.Add(webView);
        }
    }
}