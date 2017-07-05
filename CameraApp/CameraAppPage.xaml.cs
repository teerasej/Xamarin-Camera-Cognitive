using System.Linq;
using Microsoft.ProjectOxford.Face;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Xamarin.Forms;

namespace CameraApp
{
    public partial class CameraAppPage : ContentPage
    {
        private MediaFile targetfile;

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

            this.targetfile = file;

            image.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                //file.Dispose();
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


            var file = await CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
            {
            });

            if (file == null)
                return;

            await DisplayAlert("File Location", file.Path, "OK");

            this.targetfile = file;

            image.Source = ImageSource.FromFile(file.Path);

        }

        async void Handle_Identify_Clicked(object sender, System.EventArgs e)
        {
            using (var stream = this.targetfile.GetStream())
            {
                var faceServiceClient = new FaceServiceClient("43ed00a8d83e4b6b9faafb2ea411c654", "https://westcentralus.api.cognitive.microsoft.com/face/v1.0");


                var requiredFaceAttributes = new FaceAttributeType[] {
                  FaceAttributeType.Age,
                  FaceAttributeType.Gender,
                  FaceAttributeType.Smile,
                  FaceAttributeType.HeadPose,
                  FaceAttributeType.Glasses,
                    FaceAttributeType.Occlusion
                  };

                // Step 4a - Detect the faces in this photo.
                var faces = await faceServiceClient.DetectAsync(stream, true, true, requiredFaceAttributes);

                if (faces.Length > 0 )
                {
                    await Navigation.PushAsync(new FacePage(faces[0]));
                }
                else 
                {
                    await DisplayAlert("No Face Detected","It seems no face in the image...","OK");   
                }


            }
        }
    }
}
