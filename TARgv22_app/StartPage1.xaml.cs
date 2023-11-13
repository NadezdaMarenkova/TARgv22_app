using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TARgv22_app;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TARgv2206112023
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartPage1 : ContentPage
    {
        List<ContentPage> pages = new List<ContentPage>() { new EntryPage(), new BoxView_Page(), new TimerPage() };
        List<string> teksts = new List<string> { "Ava Entry leht", " Ava BoxView Leht", "Avava Timer Leht" };
        StackLayout st;
        public StartPage1()
        {
            st = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                BackgroundColor = Color.YellowGreen
            };
            for (int i = 0; i < pages.Count; i++)
            {
                Button button = new Button
                {
                    Text = teksts[i],
                    TabIndex = i,
                    BackgroundColor = Color.Red,
                    TextColor = Color.White
                };
                st.Children.Add(button);
                button.Clicked += Button_Clicked;

            }
            ScrollView sv = new ScrollView { Content = st };
            Content = sv;
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            await Navigation.PushAsync(pages[btn.TabIndex]);
        }
    }
}