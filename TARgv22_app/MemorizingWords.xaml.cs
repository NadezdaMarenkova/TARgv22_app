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
    public partial class MemorizingWords : ContentPage
    {
        Button start;
        bool help = false;
        Label name;
        Label score;
        int point = 0;
        Button button;
        Button finish;

        private Dictionary<int, string> buttonLabels = new Dictionary<int, string>
        {
            { 1, "Машина" },
            { 2, "Книга" },
            { 3, "Кошка" },
            { 4, "Человек" },
            { 5, "Небо" },
            { 6, "Собака" },
            { 7, "Город" },
            { 8, "Семья" },
            { 9, "Команда" },
            { 10, "Молоко" },
            { 11, "Билет" },
            { 12, "Дерево" },
        };

        private List<string> translation = new List<string>
        {
            "Car",
            "Book",
            "Cat",
            "Human",
            "Sky",
            "Dog",
            "Town",
            "Family",
            "Team",
            "Milk",
            "Ticket",
            "Tree"
        };

        public MemorizingWords()
        {
            name = new Label
            {
                Text = "",
                FontSize = 20,
                TextColor = Color.Black,
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.End,
                Margin = 2
            };

            score = new Label
            {
                Text = "",
                FontSize = 20,
                TextColor = Color.Black,
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.End,
                Margin = 2,
            };


            start = new Button
            {
                Text = "Start the game!",
                FontSize = 20,
                TextColor = Color.Black,
                BorderColor = Color.Black,
                CornerRadius = 10,
                WidthRequest = 280,
                HeightRequest = 55,
                BorderWidth = 2,
                BackgroundColor = Color.LightGreen,
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Center
            };

            start.Clicked += Start_Clicked;

            finish = new Button
            {
                Text = "Out of the game",
                FontSize = 20,
                TextColor = Color.Black,
                BorderColor = Color.Black,
                CornerRadius = 10,
                WidthRequest = 280,
                HeightRequest = 55,
                BorderWidth = 2,
                BackgroundColor = Color.LightGreen,
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Center
            };

            finish.IsVisible = false;
            finish.Clicked += Finish_ClickedAsync;

            Grid grid = new Grid
            {
                RowDefinitions =
            {
                new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                new RowDefinition { Height = new GridLength(1, GridUnitType.Star) }
            },
                ColumnDefinitions =
            {
                new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }
            }
            };

            int wordIndex = 0;
            for (int row = 0; row < 4; row++)
            {
                for (int column = 0; column < 3; column++)
                {
                    int buttonNumber = row * 3 + column + 1;
                    if (buttonNumber > buttonLabels.Count) 
                        break;

                    string buttonText = buttonLabels[buttonNumber];

                    button = new Button
                    {
                        Text = buttonText,
                        FontSize = 20,
                        TextColor = Color.Black,
                        BorderColor = Color.Black,
                        CornerRadius = 10,
                        HeightRequest = 100,
                        BorderWidth = 2,
                        BackgroundColor = Color.Gray,
                    };

                    grid.Children.Add(button, column, row);
                    button.Clicked += Button_ClickedAsync;
                }
            }

            Content = new StackLayout { Children = { name, score, start, grid, finish } };
        }

        private async void Finish_ClickedAsync(object sender, EventArgs e)
        {
            Button sampel = sender as Button;
            await Navigation.PopAsync();
        }

        private async void Button_ClickedAsync(object sender, EventArgs e)
        {
            if (help == true)
            {
                Button button = (Button)sender;
                string result = await DisplayPromptAsync("Task:", $"Translate to English '{button.Text}': ", "OK", keyboard: Keyboard.Chat);
                if (result == translation[0] & button.Text == buttonLabels[1] &&
                    result == translation[1] & button.Text == buttonLabels[2] &&
                    result == translation[2] & button.Text == buttonLabels[3] &&
                    result == translation[3] & button.Text == buttonLabels[4] &&
                    result == translation[4] & button.Text == buttonLabels[5] &&
                    result == translation[5] & button.Text == buttonLabels[6] &&
                    result == translation[6] & button.Text == buttonLabels[7] &&
                    result == translation[7] & button.Text == buttonLabels[8] &&
                    result == translation[8] & button.Text == buttonLabels[9])
                {
                    button.BackgroundColor = Color.Green;
                    point += 1;
                    score.Text = "Your result " + point.ToString();
                    await DisplayAlert("Congratulations!", "You've translated all words correctly!", "OK");
                }
                else if (result == translation[0] & button.Text == buttonLabels[1] ||
                         result == translation[1] & button.Text == buttonLabels[2] ||
                         result == translation[2] & button.Text == buttonLabels[3] ||
                         result == translation[3] & button.Text == buttonLabels[4] ||
                         result == translation[4] & button.Text == buttonLabels[5] ||
                         result == translation[5] & button.Text == buttonLabels[6] ||
                         result == translation[6] & button.Text == buttonLabels[7] ||
                         result == translation[7] & button.Text == buttonLabels[8] ||
                         result == translation[8] & button.Text == buttonLabels[9])
                {
                    button.BackgroundColor = Color.Green;
                    point += 1;
                    score.Text = "Your result " + point.ToString();
                }
                else
                {
                    button.BackgroundColor = Color.Red;
                    DisplayAlert("Your result:", "Learn some more!", "ОК");
                }
            }
            else
            {
                DisplayAlert("Attention!", "First press the 'Start Game' button", "ОК");
            }

        }
        private async void Start_Clicked(object sender, EventArgs e)
        {
            help = true;
            string result = await DisplayPromptAsync("A question", "Write your name: ", "OK", keyboard: Keyboard.Chat);
            name.Text = "Hi, " + result + "!";
            score.Text = "Your result: " + point;
            score.IsVisible = true;
            start.BackgroundColor = Color.Pink;
            start.IsVisible = false;
            if (start.IsVisible == false)
            {
                finish.IsVisible = true;
            }
        }
    }
}