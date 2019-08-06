using Plugin.BLE;
using Plugin.BLE.Abstractions;
using Plugin.BLE.Abstractions.Contracts;
using Plugin.BLE.Abstractions.Exceptions;
using System;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

//using NuGet Plugin.BLE

namespace App1
{
    public class Bluetooth
    {
        IBluetoothLE ble;
        public BluetoothState State { get { return ble.State; } }
        IAdapter adapter;
        ObservableCollection<IDevice> deviceList;

        public Bluetooth()
        {
            ble = CrossBluetoothLE.Current;
            adapter = CrossBluetoothLE.Current.Adapter;
            deviceList = new ObservableCollection<IDevice>();
            adapter.ScanTimeout = 60000;
        }

        public async Task<IDevice> ScanForDevice(string wantedServiceUUID)
        {
            deviceList.Clear();
            IDevice device = null;

            //Device discovery event handler
            adapter.DeviceDiscovered += (s, a) =>
            {
                deviceList.Add(a.Device);
                Console.WriteLine("Discovered periperhal. Name: \"" + a.Device.Name + " \"");

                adapter.StopScanningForDevicesAsync();
                device = a.Device;
            };

            if (!ble.Adapter.IsScanning)
            {
                Console.WriteLine("Starting scan for " + wantedServiceUUID);
                await adapter.StartScanningForDevicesAsync(new Guid[] { Guid.Parse(wantedServiceUUID) });
                Console.WriteLine("Scan for " + wantedServiceUUID + " ended");
            }
            return device;
        }
    }
}
