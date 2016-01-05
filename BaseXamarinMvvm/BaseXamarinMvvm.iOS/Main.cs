using UIKit;
using BaseXamarinMvvm.ViewModels;

namespace BaseXamarinMvvm.iOS
{
    public class Application
	{
        private static ViewModelLocator _locator;
        public static ViewModelLocator Locator
        {
            get
            {
                return _locator ?? (_locator = new ViewModelLocator());
            }
        }

        static void Main (string[] args)
		{
			UIApplication.Main (args, null, "AppDelegate");
		}
	}
}
