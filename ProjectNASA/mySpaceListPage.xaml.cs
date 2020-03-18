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
    public partial class mySpaceListPage : ContentPage
    {
        List<myListObject> l;
        public mySpaceListPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            l = await App.Database.GetMyFavSpaceObjects();
            if(l.Count == 0)
            {
                mysavedspacelistview.IsVisible = false;
                nothingHereLabel.IsVisible = true;
            }
            else mysavedspacelistview.ItemsSource = l;

            base.OnAppearing();
        }

        private async void mysavedspacelistview_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            myListObject o = e.Item as myListObject;
            //if media type is empty then it's a mars pic object, else it's APOD
            if (o.media_type == "")
            {
                await Navigation.PushAsync(new MarsPhotoDetailPage(o));
            }
            else
            {
                await Navigation.PushAsync(new APODetail(new APOD(o.title, o.date, o.expl, o.media_type, o.img_url), false));
            }
        }
    }
}