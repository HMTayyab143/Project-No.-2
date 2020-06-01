using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

using Xamarin.Forms;

namespace BetterNotes.ViewModels
{
    public class MainPageViewModel:BaseViewModel
    {
        public Command LoadNotes { get; set; }
        public Command RemoveNote { get; set; }
        public Command CreateNote { get; set; }
        public Command EditNote { get; set; }
        readonly INavigation Navigation;
       
        public ObservableCollection<string> Notes { get; set; }
        public MainPageViewModel()
        {
            LoadNotes = new Command(() =>
            {
                //Load notes from the database 
            });

            RemoveNote = new Command<string>((id) =>
            {
                //Remove note by id
            });

            EditNote = new Command<object>((obj) =>
            {
                //Push a page to edit existing note using INavigation
            });

            CreateNote = new Command(() =>
            {
                //Push a page to create a new note
            });

        }

        public MainPageViewModel(INavigation nav) : this()
        {
            this.Navigation = nav;
        }
    }
}
