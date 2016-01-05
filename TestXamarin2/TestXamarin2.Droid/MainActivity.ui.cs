using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using GalaSoft.MvvmLight.Views;
using TestXamarin2.ViewModels;

namespace TestXamarin2.Droid
{
    public partial class MainActivity : ActivityBase
    {
        public MainViewModel ViewModel
        {
            get { return App.Locator.Main; }
        }

        private ListView _peopleList;
        public ListView PeopleList
        {
            get
            {
                return _peopleList ?? (_peopleList = FindViewById<ListView>(Resource.Id.PeopleList));
            }
        }
        
        private Button _refreshButton;
        public Button RefreshButton
        {
            get
            {
                return _refreshButton ?? (_refreshButton = FindViewById<Button>(Resource.Id.RefreshButton));
            }
        }
    }
}