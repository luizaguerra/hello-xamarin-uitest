using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.UITest;

namespace HelloXamarinAndroid.Test
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            if (platform == Platform.Android)
            {
                return ConfigureApp
                    .Android

                    //.ApkFile("C:/Users/luiza.guerra/Desktop/Palestra/App/HelloXamarinAndroid/HelloXamarinAndroid/bin/Debug/HelloXamarinAndroid.HelloXamarinAndroid-Signed.apk")
                    .ApkFile("C:/Users/Luiza/Documents/Palestra/App/HelloXamarinAndroid/HelloXamarinAndroid/bin/Release/HelloXamarinAndroid.HelloXamarinAndroid-Signed.apk")
                    .EnableLocalScreenshots()
                    .StartApp();
            }
            return ConfigureApp
                .iOS
                .StartApp();
        }
    }
}
