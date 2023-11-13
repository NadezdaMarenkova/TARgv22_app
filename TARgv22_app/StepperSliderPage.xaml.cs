﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TARgv2206112023
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StepperSlider_Page : ContentPage
    {
        Stepper stepper;
        Slider slider;
        Label label;
        public StepperSlider_Page()
        {
            label = new Label
            {
                Text = "...",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
            slider = new Slider
            {
                Minimum = 0,
                Maximum = 100,
                Value = 50,
                MinimumTrackColor = Color.White,
                MaximumTrackColor = Color.BlueViolet,
                ThumbColor = Color.Red

            };
            slider.ValueChanged += Slider_ValueChanged;
            stepper = new Stepper
            {
                Minimum = 0,
                Maximum = 100,
                Value = 5,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center

            };
            stepper.ValueChanged += Stepper_ValueChanged;
            StackLayout st = new StackLayout
            {
                Children = { slider, stepper, label }

            };
            Content = st;

        }

        private void Stepper_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            label.Text = String.Format("Oli valitud: {0:F1}", e.NewValue);
            label.FontSize = e.NewValue;
            //label.Rotation = e.NewValue;
        }

        private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            label.Text = String.Format("Oli valitud: {0:F1}", e.NewValue);
            label.FontSize = e.NewValue;
            //label.Rotation = e.NewValue;
        }
    }
}