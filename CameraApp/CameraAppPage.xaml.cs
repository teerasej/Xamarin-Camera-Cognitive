using Plugin.Media;
using Xamarin.Forms;

namespace CameraApp
{
	public partial class CameraAppPage : ContentPage
	{
		public CameraAppPage()
		{
			InitializeComponent();
		}

		// Async
		async void Handle_Take_Photo_Clicked(object sender, System.EventArgs e)
		{
			// Init
			await CrossMedia.Current.Initialize();


			// Check Is-Camera-Available and Is-Take-Photo-Support?
			

			// get file from TakePhotoAsync with Plugin.Media.Abstractions.StoreCameraMediaOptions{ Directory & Name }
			

			// Check if file is null
			

			// Show file.Path in DisplayAlert
			

			// Use ImageSource.FromStream to show file in image.Source
			




		}

		async void Handle_Camera_Roll_Clicked(object sender, System.EventArgs e)
		{
			await CrossMedia.Current.Initialize();


			if (!CrossMedia.Current.IsPickPhotoSupported)
			{
				await DisplayAlert("Pick Photo not supported", ":( No pick photo supported", "OK");
				return;
			}

			// get file from PickPhotoAsync with Plugin.Media.Abstractions.StoreCameraMediaOptions{  }
			

            // Check file null
			

			// Show file.Path
			

			// Use file.Path in Image.FromFile();
			

		}
	}
}
