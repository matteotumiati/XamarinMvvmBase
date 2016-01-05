using Android.Widget;
using GalaSoft.MvvmLight.Views;
using BaseXamarinMvvm.ViewModels;
using BaseXamarinMvvm.Droid;

namespace BaseXamarinMvvm.Droid
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