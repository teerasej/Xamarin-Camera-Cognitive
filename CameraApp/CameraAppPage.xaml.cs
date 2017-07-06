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
			if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
			{
				await DisplayAlert("No Camera", ":( No camera available.", "OK");
				return;
			}

            // get file from TakePhotoAsync with Plugin.Media.Abstractions.StoreCameraMediaOptions{ Directory & Name }
			var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
			{
				Directory = "Sample",
				Name = "test.jpg"
			});

            // Check if file is null
			if (file == null)
				return;

            // Show file.Path in DisplayAlert
			await DisplayAlert("File Location", file.Path, "OK");

            // Use ImageSource.FromStream to show file in image.Source
			image.Source = ImageSource.FromStream(() =>
			{
				var stream = file.GetStream();
				file.Dispose();
				return stream;
			});

			


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
			var file = await CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
			{
			});

            // Check file
			if (file == null)
				return;

            // Show file.Path
			await DisplayAlert("File Location", file.Path, "OK");

            // Use file.Path in Image.FromFile();
			image.Source = ImageSource.FromFile(file.Path);
			
		}
    }
}
