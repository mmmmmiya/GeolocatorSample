using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace GeolocatorSample
{
	public class App : Application
	{
		public App()
		{
			// NavigationPageを使用して最初のページを表示する
			MainPage = new NavigationPage(new MainPage());

		}
	}
}