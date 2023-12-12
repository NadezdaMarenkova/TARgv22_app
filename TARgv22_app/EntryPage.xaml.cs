using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TARgv22_app
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EntryPage : ContentPage
    {
        Editor editor;
        Label label,label2 ;
        public EntryPage()
        {
             editor = new Editor
            {
                Placeholder = "Sisesta siia tekst",
                BackgroundColor = Color.AntiqueWhite,
                TextColor = Color.Brown,
            };
            //editor.TextChanged += Editor_TextChanged;

            label = new Label
            {
                Text = "Pealkiri",
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Center,
                TextColor = Color.AntiqueWhite,
                BackgroundColor = Color.Brown
            };

            label2 = new Label
            {
                Text = Preferences.Get("key2", "Ei ole veel key2"),
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Center,
                TextColor = Color.AntiqueWhite,
                BackgroundColor = Color.Brown
            };

            Button b = new Button
            {
                Text = "To Start Page",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
            };

            b.Clicked += B_Clicked;


            Button c = new Button
            {
                Text = "Save",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
            };

            c.Clicked += C_Clicked;

            Button d = new Button
            {
                Text = "Save preference",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
            };

            d.Clicked += D_Clicked;

            StackLayout st = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Children = { label, editor, b ,c,d, label2},
                BackgroundColor = Color.Bisque
            };
            Content = st;

        }

        private void D_Clicked(object sender, EventArgs e)
        {
            string value2 = editor.Text;
            Preferences.Set("key2", value2);
            label2.Text = value2;
        }

        private void C_Clicked(object sender, EventArgs e)
        {
            object key = "";

            if (App.Current.Properties.TryGetValue("key", out key))
            {
                label.Text = (string)App.Current.Properties["key"];
            }
            base.OnAppearing();

           
        }

        private void Salvesta_Omadus(object sender, EventArgs e)
        {
            string value = editor.Text;
            App.Current.Properties.Remove("key");
            App.Current.Properties.Add("key", value);
            label.Text = (string)App.Current.Properties["key"];

        }
        protected override void OnAppearing()
        {
            object key = "";
            if (App.Current.Properties.TryGetValue("key", out key))
            {
                label.Text = (string)App.Current.Properties["key"];
            }
            base.OnAppearing();
        }

        int i = 0, k = 0;

        //
        /* public void Editor_TextChanged (object sender, TextChangedEventArgs e)
         {
             char key = e.NewTextValue?.LastOrDefault() ?? ' ';
             if (key == 'A')
             {
                 i++;
                 label.Text=key.ToString() + ": " + i.ToString();
             }
        } */
        public async void B_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}