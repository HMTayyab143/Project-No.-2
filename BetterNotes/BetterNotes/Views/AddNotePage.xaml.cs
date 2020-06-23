using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using BetterNotes.Utils;
using BetterNotes.CustomControls;

using Plugin.Media.Abstractions;
using Plugin.Media;

using Plugin.Permissions.Abstractions;
using Plugin.Permissions;

using BetterNotes.Converters;

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
            var addtext = new CustomEditor();
            addtext.CornerRadii = new int[] { 30, 30, 30, 30 };
            addtext.BackGroundColor = Color.Gray;
            addtext.EndColor = Color.White;
            addtext.HeightRequest = 250;
            addtext.Unfocused += (s, e) =>
            {
                var LabelText = (s as Editor).Text;
                MainContent.Children.Remove(s as Editor);
                if (!string.IsNullOrEmpty(LabelText))
                    MainContent.Children.Add(new Label()
                    {
                        FormattedText = (new GroupDescriptionConverter()).Convert(LabelText, typeof(FormattedString)) as FormattedString,
                        TextColor = Color.Black,
                        FontSize = 20
                    }) ;
            };
            addtext.TextChanged += Addtext_TextChanged;
            MainContent.Children.Add(addtext);
            Device.BeginInvokeOnMainThread(() => addtext.Focus());
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

        private void AddLinkBlock(object sender, EventArgs args)
        {
            
        }

        private async void AddPhoto(object sender, EventArgs args)
        {
            var permission_result = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Camera);
            if (permission_result != PermissionStatus.Granted)
            {
                await CrossPermissions.Current.RequestPermissionsAsync(Permission.Camera);
            }
            var photo = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
            {
                PhotoSize = PhotoSize.Medium,
                AllowCropping = true
            });

            if (photo != null)
            {
                MainContent.Children.Add(new Image
                {
                    HorizontalOptions = LayoutOptions.Center,
                    Source = ImageSource.FromStream(() =>
                    {
                        var stream = photo.GetStream();
                        return stream;
                    })
                });
            }
        }

    }
}