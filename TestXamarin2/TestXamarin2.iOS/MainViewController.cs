
using System;
using System.Drawing;

using Foundation;
using UIKit;
using TestXamarin2.ViewModels;
using GalaSoft.MvvmLight.Helpers;
using TestXamarin2.Models;

namespace TestXamarin2.iOS
{
    public partial class MainViewController : UIViewController
    {
        //private Binding<string, string> _lastLoadedBinding;
        private ObservableTableViewController<Person> _tableViewController;

        private MainViewModel Vm
        {
            get
            {
                return Application.Locator.Main;
            }
        }

        public MainViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            //_lastLoadedBinding = this.SetBinding(
            //   () => Vm.LastLoadedFormatted,
            //   () => LastLoadedText.Text);


            RefreshButton.TouchDown += (s, e) => Vm.RefreshCommand.Execute(null);

            _tableViewController = Vm.People.GetController(CreateCell, BindCell);
            _tableViewController.TableView = PeopleTableView;

            _tableViewController.SelectionChanged +=
                (s, e) => Vm.SelectedPersonCommand.Execute(_tableViewController.SelectedItem);
        }

        private void BindCell(UITableViewCell cell, Person p, NSIndexPath path)
        {
            cell.TextLabel.Text = p.Name;
            cell.DetailTextLabel.Text = p.LastName;
        }

        private UITableViewCell CreateCell(NSString reuseId)
        {
            var cell = new UITableViewCell(UITableViewCellStyle.Subtitle, null);
            return cell;
        }
    }
}