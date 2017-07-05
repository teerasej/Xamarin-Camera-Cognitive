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

        async void Handle_Take_Photo_Clicked(object sender, System.EventArgs e)
        {
			await CrossMedia.Current.Initialize();

			if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
			{
				await DisplayAlert("No Camera", ":( No camera available.", "OK");
				return;
			}

			var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
			{
				Directory = "Sample",
				Name = "test.jpg"
			});

			if (file == null)
				return;

			await DisplayAlert("File Location", file.Path, "OK");

			image.Source = ImageSource.FromStream(() =>
			{
				var stream = file.GetStream();
				file.Dispose();
				return stream;
			});

			//or:
			//image.Source = ImageSource.FromFile(file.Path);
			//image.Dispose();


		}

        async void Handle_Camera_Roll_Clicked(object sender, System.EventArgs e)
        {
			await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsPickPhotoSupported)
			{
				await DisplayAlert("Pick Photo not supported", ":( No pick photo supported", "OK");
				return;
			}


            var file = await CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
			{
			});

			if (file == null)
				return;

			await DisplayAlert("File Location", file.Path, "OK");

			
			image.Source = ImageSource.FromFile(file.Path);
			
		}
    }
}
