using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using BetterNotes.Utils;

namespace BetterNotes.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddNotePage : ContentPage
    {
        public AddNotePage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

        }

        private void AddTextBlock(object sender, EventArgs args)
        {
            var addtext = new Editor();
            addtext.HeightRequest = 250;
            addtext.Unfocused += (s, e) =>
            {
                var LabelText = (s as Editor).Text;
                MainContent.Children.Remove(s as Editor);
                if (!string.IsNullOrEmpty(LabelText))
                    MainContent.Children.Add(new Label()
                    {
                        Text = LabelText,
                        TextColor = Color.Black,
                        FontSize = 20
                    });
            };
            addtext.TextChanged += Addtext_TextChanged;
            addtext.Focus();
            MainContent.Children.Add(addtext);
        }

        private void Addtext_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.OldTextValue) && !string.IsNullOrEmpty(e.NewTextValue))
            {
                if (e.OldTextValue.Length < e.NewTextValue.Length)
                {
                    if (e.NewTextValue.Contains("1."))
                    {
                        var text = e.NewTextValue;
                        var count = EntriesCounter.CountEntries(e.NewTextValue);
                        if (text[text.Length - 1].ToString() == "\n")
                        {
                            (sender as Editor).Text += $"{count + 1}. ";
                        }
                    }

                    if (e.NewTextValue.Contains("* "))
                    {
                        var text = e.NewTextValue;
                        if (text[text.Length - 1].ToString() == "\n")
                        {
                            (sender as Editor).Text += "* ";
                        }
                    }
                }
            }
           
        }
    }
}