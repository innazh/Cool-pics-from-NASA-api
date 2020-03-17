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
    public partial class APODetail : ContentPage
    {
        public APODetail(APOD d)
        {
            InitializeComponent();

            if (d.media_type.Equals("image"))
            {
                web.IsVisible = false;

                APODTitle.Text = d.title;
                APODexpl.Text = d.explanation;
                APODimgD.Source = d.url;
            }
            else
            {
                ImgStackLay.IsVisible = false;

                HtmlWebViewSource personHtmlSource = new HtmlWebViewSource();
                personHtmlSource.SetBinding(HtmlWebViewSource.HtmlProperty, "HTMLDesc");
                personHtmlSource.Html = @"<html>
                                            <body> 
                                                <div align='center' style='font-size: 20px; margin: 10px'>" + d.title + "</div>" +
                                                "<div style=' position: relative; padding-bottom: 56.25%; padding-top: 25px; margin: 10px'> " +
                                                    "<iframe style='position: absolute; top: 0; left: 0; width: 100%; height: 100%;'  src='" + d.url + "'  ' frameborder='0' allowfullscreen>" +
                                                    "</iframe>" +
                                                "</div>" +
                                                "<div style='margin: 10px'>" +
                                                    "<p>" + d.explanation +"</p>" +
                                                "</div>" +
                                           "</body>" +
                                        "</html>";
                web.Source = personHtmlSource;
                //var browser = new WebView();
                //browser.Source = personHtmlSource;
                //Content = browser;
            }
        }
    }
}