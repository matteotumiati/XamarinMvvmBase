using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using TestXamarin2.ViewModels;

namespace TestXamarin2.iOS
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
