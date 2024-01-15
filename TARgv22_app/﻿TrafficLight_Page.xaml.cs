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
    public partial class ﻿TrafficLight_Page : ContentPage
    {
        BoxView cirkleRed;
        BoxView cirkleYellow;
        BoxView cirkleGreen;
        private bool isOn = false;

        public TrafficLight_Page()
        {
            cirkleRed = new BoxView
            {
                BackgroundColor = Color.Gray,
                CornerRadius = 1000,
                WidthRequest = 200,
                HeightRequest = 200,
                HorizontalOptions = LayoutOptions.Center,
            };

            cirkleYellow = new BoxView
            {
                BackgroundColor = Color.Gray,
                CornerRadius = 1000,
                WidthRequest = 200,
                HeightRequest = 200,
                HorizontalOptions = LayoutOptions.Center,
            };

            cirkleGreen = new BoxView
            {
                BackgroundColor = Color.Gray,
                CornerRadius = 1000,
                WidthRequest = 200,
                HeightRequest = 200,
                HorizontalOptions = LayoutOptions.Center,
            };

            var tapGestureRecognizerRed = new TapGestureRecognizer();
            tapGestureRecognizerRed.Tapped += (s, e) => {
                if (isOn)
                {
                    DisplayAlert("Red", "Stop", "OK");
                }
                else
                {
                    DisplayAlert("Error", "Traffic light is off", "OK");
                }
            };
            cirkleRed.GestureRecognizers.Add(tapGestureRecognizerRed);

            var tapGestureRecognizerYellow = new TapGestureRecognizer();
            tapGestureRecognizerYellow.Tapped += (s, e) => {
                if (isOn)
                {
                    DisplayAlert("Yellow", "Wait", "OK");
                }
                else
                {
                    DisplayAlert("Error", "Traffic light is off", "OK");
                }
            };
            cirkleYellow.GestureRecognizers.Add(tapGestureRecognizerYellow);

            var tapGestureRecognizerGreen = new TapGestureRecognizer();
            tapGestureRecognizerGreen.Tapped += (s, e) => {
                if (isOn)
                {
                    DisplayAlert("Green", "Go", "OK");
                }
                else
                {
                    DisplayAlert("Error", "Traffic light is off", "OK");
                }
            };
            cirkleGreen.GestureRecognizers.Add(tapGestureRecognizerGreen);

            Grid buttonGrid = new Grid
            {
                ColumnDefinitions = {
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }
                }
            };


            Button on = new Button
            {
                Text = "On",
                BackgroundColor = Color.Green,
            };
            on.Clicked += On_Clicked;

            Button off = new Button
            {
                Text = "Off",
                BackgroundColor = Color.Red,
            };
            off.Clicked += Off_Clicked;


            buttonGrid.Children.Add(on, 0, 0);
            buttonGrid.Children.Add(off, 1, 0);


            StackLayout stack = new StackLayout
            {
                Children = { cirkleRed, cirkleYellow, cirkleGreen, buttonGrid }
            };
            stack.BackgroundColor = Color.White;
            Content = stack;

        }

        private void On_Clicked(object sender, EventArgs e)
        {
            isOn = true;
            cirkleRed.BackgroundColor = Color.Red;
            cirkleYellow.BackgroundColor = Color.Yellow;
            cirkleGreen.BackgroundColor = Color.Green;
        }

        private void Off_Clicked(object sender, EventArgs e)
        {
            isOn = false;
            cirkleRed.BackgroundColor = Color.Gray;
            cirkleYellow.BackgroundColor = Color.Gray;
            cirkleGreen.BackgroundColor = Color.Gray;
        }
    }
}