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
    public partial class TrafficLights : ContentPage
    {
        Button On, Off;
        Label mould;
        bool help = false;
        Frame[] fps;
        string[] names = { "Red", "Yellow", "Green" };

        public TrafficLights()
        {
            TapGestureRecognizer first = new TapGestureRecognizer();
            TapGestureRecognizer second = new TapGestureRecognizer();
            TapGestureRecognizer third = new TapGestureRecognizer();
            TapGestureRecognizer[] taps = new TapGestureRecognizer[3] { first, second, third };

            first.Tapped += first_Tapped;
            second.Tapped += second_Tapped;
            third.Tapped += third_Tapped;

            fps = new Frame[3];

            for (int i = 0; i < fps.Length; i++)
            {
                mould = new Label
                {
                    Text = names[i],
                    FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                    HorizontalTextAlignment = TextAlignment.Center,
                    VerticalTextAlignment = TextAlignment.Center,
                };

                fps[i] = new Frame
                {
                    Content = mould,
                    BackgroundColor = Color.FromHex("#cccccc"),
                    CornerRadius = 1000,
                    WidthRequest = 200,
                    HeightRequest = 200,
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center
                };

                fps[i].GestureRecognizers.Add(taps[i]);
            }
            On = new Button
            {
                Text = "On"
            };
            On.Clicked += On_Clicked;
            Off = new Button
            {
                Text = "Off",
                HorizontalOptions = LayoutOptions.End
            };
            Off.Clicked += Off_Clicked;
            FlexLayout fl = new FlexLayout
            {
                Children = { On, Off },
                JustifyContent = FlexJustify.SpaceEvenly
            };
            Content = new StackLayout { Children = { fps[0], fps[1], fps[2], fl } };
        }

        private void third_Tapped(object sender, EventArgs e)
        {
            if (help == true)
            {
                Frame f = (Frame)sender;
                Label l = f.Content as Label;
                if (l.Text == "Go")
                {
                    l.Text = "Green";
                }
                else
                {
                    l.Text = "Go";
                    fps[2].BackgroundColor = Color.FromHex("#00bf00");
                }
            }
            else
            {
                DisplayAlert("Attention:", "Before start the traffic lights, first press button ON", "OK");
            }

        }

        private void second_Tapped(object sender, EventArgs e)
        {
            if (help == true)
            {
                Frame f = (Frame)sender;
                Label l = f.Content as Label;
                if (l.Text == "Wait")
                {
                    l.Text = "Yellow";
                }
                else
                {
                    l.Text = "Wait";
                    fps[1].BackgroundColor = Color.FromHex("#ffe600");
                }
            }
            else
            {
                DisplayAlert("Attention:", "Before start the traffic lights, first press button ON", "OK");
            }

        }
        private void first_Tapped(object sender, EventArgs e)
        {
            if (help == true)
            {
                Frame f = (Frame)sender;
                Label l = f.Content as Label;
                if (l.Text == "Stop")
                {
                    l.Text = "Red";
                }
                else
                {
                    l.Text = "Stop";
                    fps[0].BackgroundColor = Color.FromHex("#d42b00");
                }
            }
            else
            {
                DisplayAlert("Attention:", "Before start the traffic lights, first press button ON", "OK");
            }

        }
        private void Off_Clicked(object sender, EventArgs e)
        {
            help = false;
            fps[0].BackgroundColor = Color.FromHex("#cccccc");
            fps[1].BackgroundColor = Color.FromHex("#cccccc");
            fps[2].BackgroundColor = Color.FromHex("#cccccc");
            On.BackgroundColor = Color.FromHex("#ffffff");
            Off.BackgroundColor = Color.FromHex("#ffffff");
        }
        private void On_Clicked(object sender, EventArgs e)
        {
            help = true;
            On.BackgroundColor = Color.FromHex("#c9ffdb");
            Off.BackgroundColor = Color.FromHex("#c9ffdb");

        }
    }
}