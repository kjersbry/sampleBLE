using System;
using System.Threading;
using Xamarin.Forms;
using System.Diagnostics;

namespace App1
{
    public partial class MainPage : ContentPage
    {
        static public Bluetooth Bluetooth;
        public MainPage()
        {
            InitializeComponent();
            Bluetooth = new Bluetooth();
            Plugin.BLE.Abstractions.Trace.TraceImplementation = (format, @params) =>
            {
                Debug.WriteLine($"{DateTime.Now}: {format}", @params);
            };
        }

        async void OnButtonClickSearch(object sender, System.EventArgs e)
        {
            Console.WriteLine("start sleeping");
            Thread.Sleep(5000);
            Console.WriteLine("done sleeping");
            await Bluetooth.ScanForDevice("46a970e0-0d5f-11e2-8b5e-0002a5d5c51b");
        }
    }
}
