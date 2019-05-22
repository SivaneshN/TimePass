using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Essentials;

namespace TimePass.ViewModels
{
	public class MotionViewModel : ViewModelBase
	{
        SensorSpeed speed = SensorSpeed.UI;

        private string _accReadings;
        public string AccReadings
        {
            get { return _accReadings; }
            set { SetProperty(ref _accReadings, value); }
        }

        public MotionViewModel(INavigationService navigationService) : base(navigationService)
        {
            ToggleAccelerometer();
            AccReadings = "Getting Readings...Please Wait";
            DetectReading();
        }

        public void DetectReading()
        {
            // Register for reading changes, be sure to unsubscribe when finished
            Accelerometer.ReadingChanged += Accelerometer_ShakeDetected;
        }

        void Accelerometer_ShakeDetected(object sender, AccelerometerChangedEventArgs e)
        {
            // Process shake event
            //ToggleTorchMethodExecute(TorchStatus);
            var data = e.Reading;
            //Console.WriteLine($"Reading: X: {data.Acceleration.X}, Y: {data.Acceleration.Y}, Z: {data.Acceleration.Z}");
            AccReadings = $"Reading: X: {data.Acceleration.X}, Y: {data.Acceleration.Y}, Z: {data.Acceleration.Z}";
        }

        public void ToggleAccelerometer()
        {
            try
            {
                if (Accelerometer.IsMonitoring)
                    Accelerometer.Stop();
                else
                    Accelerometer.Start(speed);
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Feature not supported on device
            }
            catch (Exception ex)
            {
                // Other error has occurred.
            }
        }
    }
}
