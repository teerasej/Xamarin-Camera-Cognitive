using System;
using System.Collections.Generic;
using Microsoft.ProjectOxford.Face.Contract;
using Xamarin.Forms;

namespace CameraApp
{
    public partial class FacePage : ContentPage
    {
        private Face detectedFace;

        public FacePage(Face face)
        {
            InitializeComponent();

            this.detectedFace = face;

            labelAge.Text = this.detectedFace.FaceAttributes.Age.ToString();
            labelHeadPosePitch.Text = this.detectedFace.FaceAttributes.HeadPose.Pitch.ToString();
            labelHeadPoseRoll.Text = this.detectedFace.FaceAttributes.HeadPose.Roll.ToString();
            labelHeadPoseYaw.Text = this.detectedFace.FaceAttributes.HeadPose.Yaw.ToString();
            labelSmile.Text = this.detectedFace.FaceAttributes.Smile.ToString();
            labelGlasses.Text = this.detectedFace.FaceAttributes.Glasses.ToString();
            labelOcclusionEyeOccluded.Text = this.detectedFace.FaceAttributes.Occlusion.EyeOccluded.ToString();
            labelOcclusionForeheadOccluded.Text = this.detectedFace.FaceAttributes.Occlusion.ForeheadOccluded.ToString();
            labelOcclusionMouthOccluded.Text = this.detectedFace.FaceAttributes.Occlusion.MouthOccluded.ToString();
;
        }
    }
}
