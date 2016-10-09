using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;

namespace GeolocatorSample
{
	class MainPage : ContentPage
	{
		public MainPage()
		{
			Title = "MainPage"; //ページのタイトル

			//ボタンを生成
			var gpsGetButton = new Button { Text = "GPS情報を取得" };

			//ボタンクリック時の処理
			gpsGetButton.Clicked += async (s, a) =>
			{
				try
				{
					IGeolocator locator = CrossGeolocator.Current;
					locator.DesiredAccuracy = 50;

					Position position = await locator.GetPositionAsync(timeoutMilliseconds: 10000);

					System.Diagnostics.Debug.WriteLine("Position Status: {0}", position.Timestamp);
					System.Diagnostics.Debug.WriteLine("Position Latitude: {0}", position.Latitude);
					System.Diagnostics.Debug.WriteLine("Position Longitude: {0}", position.Longitude);
				}
				catch (Exception ex)
				{
					System.Diagnostics.Debug.WriteLine("Unable to get location, may need to increase timeout: " + ex);
				}
			};

			Content = new StackLayout
			{
				Children = {
					gpsGetButton,
				},
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.Center
			};
		}
	}
}
