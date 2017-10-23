using System;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace Diagnostico
{
    public class CustomDialog
    {
        public static Task<string> InputBox(INavigation navigation, string title, string label, string placeholder)
        {
            // wait in this proc, until user did his input 
            var tcs = new TaskCompletionSource<string>();

            var lblTitle = new Label { Text = title, HorizontalOptions = LayoutOptions.Center, FontAttributes = FontAttributes.Bold };
            var lblMessage = new Label { Text = label };
            var txtInput = new Entry { Text = placeholder };

            var btnOk = new Button
            {
                Text = "Ok",
                WidthRequest = 100,
                BackgroundColor = Color.FromRgb(0.8, 0.8, 0.8),
            };
            btnOk.Clicked += async (s, e) =>
            {
                // close page
                var result = txtInput.Text;
                await navigation.PopModalAsync();
                // pass result
                tcs.SetResult(result);
            };

            var btnCancel = new Button
            {
                Text = "Cancel",
                WidthRequest = 100,
                //BackgroundColor = Color.FromRgb(0.8, 0.8, 0.8)
            };
            btnCancel.Clicked += async (s, e) =>
            {
                // close page
                await navigation.PopModalAsync();
                // pass empty result
                tcs.SetResult(null);
            };

            var slButtons = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children = { btnCancel, btnOk },
            };

            var layout = new StackLayout
            {
                Padding = new Thickness(0, 40, 0, 0),
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Orientation = StackOrientation.Vertical,
                Children = { lblTitle, lblMessage, txtInput, slButtons },
            };

            // create and show page
            var page = new ContentPage();
            page.Content = layout;
            navigation.PushModalAsync(page);
            // open keyboard
            txtInput.Focus();

            // code is waiting her, until result is passed with tcs.SetResult() in btn-Clicked
            // then proc returns the result
            return tcs.Task;
        }
    }
}
