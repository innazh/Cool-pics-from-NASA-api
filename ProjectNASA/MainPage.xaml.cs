using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Net.Http;

namespace ProjectNASA
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        APODManager apodManager = new APODManager();
        DateTime localDate = DateTime.Now;
        APOD d;
        public MainPage()
        {
            InitializeComponent();
        }

        //Before loading the main page, we call the APOD api and get our APOD object.
        protected async override void OnAppearing()
        {
            datePicker.MaximumDate = localDate;
            d = await apodManager.getAPOD(localDate);

            APODTitle.Text = d.title;
            if (d.media_type.Equals("image"))
            {
                ImageOfTheDayAPOD.Source = d.url;
            }
            else ImageOfTheDayAPOD.Source = "videoDummy.png";

            System.Diagnostics.Debug.WriteLine(d);

            base.OnAppearing();
        }

        

        //Sends a new request to the API when the date on DatePicker gets changed.
        private async void DateSelected(object sender, DateChangedEventArgs e)
        {
            d = await apodManager.getAPOD(e.NewDate);
            APODTitle.Text = d.title;
            if (d.media_type.Equals("image"))
            {
                ImageOfTheDayAPOD.Source = d.url;
            }
            else ImageOfTheDayAPOD.Source = "videoDummy.png";
        }

        //Sends user to the page where they can search for pictures taken by the NASA's Mars Rovers.
        private async void goMarsRoverPhotos(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MarsRoversPhotosPage());
        }

        //Triggered when the image is clicked, redirects user to a more detailed APOD page.
        public async void goAPODetail(Object sender, EventArgs e)
        {
            await Navigation.PushAsync(new APODetail(d, true));
        }

        private async void goSpaceList(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new mySpaceListPage());
        }
    }
}
