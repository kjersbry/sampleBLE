using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Xamarin.Forms;

namespace App1
{
    public partial class MainPage : ContentPage
    {
        Bluetooth ble;
        public MainPage()
        {
            InitializeComponent();
            ble = new Bluetooth();
        }

        async void OnButtonClickSearch(object sender, System.EventArgs e)
        {
            Thread.Sleep(5000);
            Console.WriteLine("done sleeping");
            await ble.ScanForDevice("46a970e0-0d5f-11e2-8b5e-0002a5d5c51b");
        }
    }
}
