using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BetterNotes.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddNotePage : ContentPage
    {
        bool EditorFocused { get; set; }
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
            if (!EditorFocused)
            {
                var addtext = new Editor();
                addtext.HeightRequest = 250;
                addtext.Unfocused += (s, e) =>
                {
                    EditorFocused = false;
                    var LabelText = (s as Editor).Text;
                    MainContent.Children.Remove(s as Editor);
                    MainContent.Children.Add(new Label()
                    {
                        Text = LabelText
                    });
                };
                MainContent.Children.Add(addtext);
                EditorFocused = addtext.Focus();
            }
        }
    }
}