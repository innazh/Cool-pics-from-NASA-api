using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjectNASA
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MarsRoversPhotosPage : ContentPage
    {
        string roverName = "";
        string cameraName = "";
        string[] curiosityCameras = { "Front Hazard Avoidance Camera", "Rear Hazard Avoidance Camera", "Mast Camera",  "Chemistry and Camera Complex", "Mars Hand Lens Imager", "Mars Descent Imager", "Navigation Camera"};
        string[] opportunityspiritCameras = { "Front Hazard Avoidance Camera", "Rear Hazard Avoidance Camera", "Navigation Camera", "Panoramic Camera", "Miniature Thermal Emission Spectrometer (Mini-TES)" };
        MarsPicsManager m = new MarsPicsManager();
        List<LatestPhoto> marsPics;
        public MarsRoversPhotosPage()
        {
            InitializeComponent();
        }

        //When a rover is picked, the appropriate array of values gets assigned to the cameraPicker
        private void onRoverPicked(object sender, EventArgs e)
        {
            Picker p = sender as Picker;

            if (p.SelectedIndex != -1)
            {
                if (p.SelectedItem.Equals("Curiosity"))
                {
                    cameraPicker.ItemsSource = curiosityCameras;
                    roverImg.Source = "curiosity.jpg";
                }
                else
                {
                    cameraPicker.ItemsSource = opportunityspiritCameras;
                    roverImg.Source = "spiritOpportunity.jpg";
                }

                roverName = p.SelectedItem.ToString();
            }
        }

        private void onCameraPicked(object sender, EventArgs e)
        {
            Picker p = sender as Picker;

            if (p.SelectedIndex != -1)
            {
                cameraName = p.SelectedItem.ToString();
            }
        }

        //The submit button calls the api with the values that user selected
        private async void submitBtn_Clicked(object sender, EventArgs e)
        {
            if (!roverName.Equals(""))
            {
                if (!cameraName.Equals(""))
                {
                    marsPics = (await m.getMarsPiscRoverCam(roverName, cameraName)).latest_photos;
                }
                else marsPics = (await m.getMarsPicsRover(roverName)).latest_photos;
            }
            else await DisplayAlert("Error", "Please pick a rover", "OK");

            //Clean up the selections
            cameraPicker.SelectedIndex = -1;
            roverPicker.SelectedIndex = -1;
            cameraName = "";
            roverName = "";

            marsPicsListView.ItemsSource = marsPics;
        }
        //Gives user a clue on how to save objects to their list.
        private void toolBarItemInstructions(object sender, EventArgs e)
        {
            DisplayAlert("Save", "To save one of the mars pictures to your list, long press the item", "OK");
        }

        private async void saveToDB(object sender, EventArgs e)
        {
            LatestPhoto mpo = (sender as MenuItem).CommandParameter as LatestPhoto;
            await App.Database.SaveObjectToList(new myListObject(mpo.rover.name, mpo.img_src, mpo.earth_date, "", mpo.camera.full_name));
        }
    }
}