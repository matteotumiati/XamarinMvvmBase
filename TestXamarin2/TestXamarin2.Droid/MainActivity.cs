using Android.App;
using Android.OS;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using GalaSoft.MvvmLight.Ioc;
using Android.Widget;
using Android.Views;
using System;
using GalaSoft.MvvmLight.Helpers;
using TestXamarin2.Models;

namespace TestXamarin2.Droid
{
    [Activity (Label = "TestXamarin2.Droid", MainLauncher = true, Icon = "@drawable/icon")]
	public partial class MainActivity : AdapterView.IOnItemClickListener
    {
        public void OnItemClick(AdapterView parent, View view, int position, long id)
        {
            ViewModel.SelectedPersonCommand.Execute(ViewModel.People[position]);
        }

        protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

            RefreshButton.SetCommand("Click", ViewModel.RefreshCommand);
            PeopleList.Adapter = ViewModel.People.GetAdapter(GetAdapter);
            PeopleList.OnItemClickListener = this;
        }

        private View GetAdapter(int position, Person p, View convertView)
        {
            convertView = LayoutInflater.Inflate(Resource.Layout.PersonLayout, null);

            var title = convertView.FindViewById<TextView>(Resource.Id.NameTextView);
            title.Text = p.Name;

            var desc = convertView.FindViewById<TextView>(Resource.Id.DescriptionTextView);
            desc.Text = p.LastName;
            
            return convertView;
        }
    }
}