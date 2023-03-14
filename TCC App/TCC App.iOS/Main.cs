using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using Google.Maps;
using UIKit;

namespace TCC_App.iOS
{
    public class Application
    {
        // This is the main entry point of the application.
        static void Main(string[] args)
        {
            string apiKey = "AIzaSyAd2xyxECeldukvPhSMZWquHGzk9ZNQL58";
            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.
            Xamarin.FormsGoogleMaps.Init(apiKey);
            UIApplication.Main(args, null, typeof(AppDelegate));
        }
    }
}
