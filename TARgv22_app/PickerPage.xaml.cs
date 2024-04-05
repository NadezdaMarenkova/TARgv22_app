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
        //Entry entry;
        Entry addressBar;
        Button backButton;
        Button nextButton;
       // Button textButton;
        StackLayout st;
        Frame frame;
        int currentIndex = 0;

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
            SwipeGestureRecognizer swipe = new SwipeGestureRecognizer();
            swipe.Swiped += Swipe_Swiped;
            swipe.Direction = SwipeDirection.Right | SwipeDirection.Left;

            frame = new Frame
            {
                BorderColor = Color.AliceBlue,
                CornerRadius = 20,
                HeightRequest = 20,
                WidthRequest = 400,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HasShadow = true
            };
     

            backButton = new Button
            {
                Text = "Back",
                Command = new Command(() => NavigateBack())
            };

            nextButton = new Button
            {
                Text = "Next",
                Command = new Command(() => NavigateNext())
            };

            addressBar = new Entry
            {
                Placeholder = "Enter URL",
                ReturnType = ReturnType.Go,
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };
            addressBar.Completed += AddressBar_Completed; ;
            st = new StackLayout { Children = { picker, addressBar, backButton, nextButton } };

            Button addButton = new Button
            {
                Text = "Add Page",
                Command = new Command(OpenAddPagePopup)
            };

            st = new StackLayout { Children = { picker, webView } };

            st.Children.Add(addButton);

            frame.GestureRecognizers.Add(swipe);
            
            Content = st;

        }

        private void AddressBar_Completed(object sender, EventArgs e)
        {
            Navigate(addressBar.Text);
        }
        private void NavigateBack()
        {
            currentIndex = Math.Max(0, currentIndex - 1);
            picker.SelectedIndex = currentIndex;
            NavigateToPage(currentIndex);
        }

        private void NavigateNext()
        {
            currentIndex = Math.Min(lehed.Length - 1, currentIndex + 1);
            picker.SelectedIndex = currentIndex;
            NavigateToPage(currentIndex);
        }
        private void Navigate(string url)
        {
            string enteredUrl = addressBar.Text;

            if (webView != null)
            {
                st.Children.Remove(webView);
            }

            webView = new WebView
            {
                Source = new UrlWebViewSource { Url = enteredUrl },
                VerticalOptions = LayoutOptions.FillAndExpand,
            };

            st.Children.Add(webView);
        }

        int ind = 0;

        private void Swipe_Swiped(object sender, SwipedEventArgs e)
        {
            webView.Source = new UrlWebViewSource { Url = lehed[ind] };

            ind++;

            if (ind == lehed.Length)
            {
                ind = 0;
            }
        }

        //private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (webView != null)
        //    {
        //        st.Children.Remove(webView);
        //    }
        //    webView = new WebView
        //    {
        //        Source = new UrlWebViewSource { Url = lehed[picker.SelectedIndex] },
        //        VerticalOptions = LayoutOptions.FillAndExpand,
        //    };
        //    st.Children.Add(webView);
        //}

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            NavigateToPage(picker.SelectedIndex);
        }
        private void NavigateToPage(int index)
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

        private async void OpenAddPagePopup()
        {
            string newPage = await InputPrompt("Add Page", "Enter URL:");
            if (!string.IsNullOrEmpty(newPage))
            {
                lehed = lehed.Concat(new[] { newPage }).ToArray();
                picker.Items.Add("New Page");
            }
        }
        private async Task<string> InputPrompt(string title, string message)
        {
            return await DisplayPromptAsync(title, message);
        }
    }
}