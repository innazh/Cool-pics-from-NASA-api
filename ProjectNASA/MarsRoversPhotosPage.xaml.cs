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
        string[] curiosityCameras = { "Front Hazard Avoidance Camera", "Rear Hazard Avoidance Camera", "Mast Camera",  "Chemistry and Camera Complex", "Mars Hand Lens Imager", "Mars Descent Imager", "Navigation Camera"};
        string[] opportunityspiritCameras = { "Front Hazard Avoidance Camera", "Rear Hazard Avoidance Camera", "Navigation Camera", "Panoramic Camera", "Miniature Thermal Emission Spectrometer (Mini-TES)" };

        public MarsRoversPhotosPage()
        {
            InitializeComponent();
        }

        private void onRoverPicked(object sender, EventArgs e)
        {
            Picker p = sender as Picker;
            if(p.SelectedItem.Equals("Curiosity"))
            {
                cameraPicker.ItemsSource = curiosityCameras;
            }
            else
            {
                cameraPicker.ItemsSource = opportunityspiritCameras;
            }
        }
    }
}