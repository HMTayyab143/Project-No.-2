using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using BetterNotes.ViewModels;

namespace BetterNotes.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        MainPageViewModel viewModel { get; set; }
        public MainPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new MainPageViewModel(this.Navigation);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            viewModel.LoadNotes.Execute(null);
        }

        
    }
}