using System;
using Plugin.BLE;
using App1.iOS;


[assembly: Xamarin.Forms.Dependency(typeof(RestorationIdentifier))]
namespace App1.iOS
{
    public class RestorationIdentifier : IRestorationIdentifier
    {
        public void Use(string restorationIdentifier)
        {
            BleImplementation.UseRestorationIdentifier(restorationIdentifier);
        }
    }
}


