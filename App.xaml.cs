using Android.Bluetooth;
using Java.Util;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace App2
{
    public partial class App : Application
    {


        public static BluetoothAdapter adapter;
        public static BluetoothDevice device1;
        public static BluetoothSocket BthSocket1;

        public static BluetoothDevice device2;
        public static BluetoothSocket BthSocket2;

        public App()
        {
            InitializeComponent();
            StartConnection();
            MainPage = new App2.MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
        public void StartConnection()
        {
            adapter = BluetoothAdapter.DefaultAdapter;
            BthSocket1 = null;
            BthSocket2 = null;


            if (adapter == null) {
                System.Diagnostics.Debug.WriteLine("No Bluetooth adapter found.");
            }

            if (!adapter.IsEnabled) {

                System.Diagnostics.Debug.WriteLine("Bluetooth adapter is not enabled.");
            }

            device1 = null;
            device2 = null;

            foreach (var bd in adapter.BondedDevices)
            {
                if (bd.Name.StartsWith("yourBluetoothname"))
                {
                    device1 = bd;
                }
                if (bd.Name.StartsWith("yourBluetoothname"))
                {
                    device2 = bd;

                }
            }

            if (device1 == null) {
                System.Diagnostics.Debug.WriteLine("Named device 1 not found.");
            }
            else
            if (device2 == null) {
                System.Diagnostics.Debug.WriteLine("Named device 2 not found.");
            }
            else
            {

                System.Diagnostics.Debug.WriteLine("device name :" + device1.Name);
                System.Diagnostics.Debug.WriteLine("device name :" + device2.Name);
                BthSocket1 = device1.CreateRfcommSocketToServiceRecord(UUID.FromString("00001101-0000-1000-8000-00805f9b34fb"));
               BthSocket2 = device2.CreateRfcommSocketToServiceRecord(UUID.FromString("00001101-0000-1000-8000-00805f9b34fb"));
               if (BthSocket1 != null && BthSocket2 != null)
               {

                    try
                    {
                        System.Diagnostics.Debug.WriteLine("now we will try to connect ");

                        if (!BthSocket1.IsConnected)
                        {
                            System.Diagnostics.Debug.WriteLine("oppps");
                            BthSocket1.Connect();
                        }

                        if (!BthSocket2.IsConnected)
                        {
                            System.Diagnostics.Debug.WriteLine("oppps");
                            BthSocket2.Connect();
                        }



                    }
                    catch(Exception e)
                    {


                        throw e;
                    }
                }
            }
        }
    }
}
