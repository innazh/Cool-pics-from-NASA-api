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
    public partial class MarsPhotoDetailPage : ContentPage
    {
        myListObject mlo;
        public MarsPhotoDetailPage(myListObject m)
        {
            mlo = m;
            InitializeComponent();
            RoverTitle.Text = "Rover: " + m.title;
            MarsImg.Source = m.img_url;
            picDescr.Text = "This picture was taken on Mars by rover " + m.title + " on " + m.date + " with " + m.expl + ".";
        }
    }
}