using System;
using System.Timers;
using System.ComponentModel;
using Xamarin.Forms;
using System.Diagnostics;

namespace MVVMTimer.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        int counter = 60;
        Stopwatch stopWatch = new Stopwatch();
        string timer;
        private bool timeRunning;
        Stopwatch sixtyStopWatch = new Stopwatch();
        string sCounter;

        public MainPageViewModel()
        {
            sixtyStopWatch.Start();
            Device.StartTimer(TimeSpan.FromSeconds(0), () =>
            {
                sCounter = (counter - sixtyStopWatch.Elapsed.Seconds).ToString();
                Timer = sCounter;
                //Timer = sixtyStopWatch.Elapsed.Seconds.ToString();
                return true;
            });

            
           



            Device.StartTimer(TimeSpan.FromSeconds(0), () =>
            {
                stopWatch.Start();
                StopWatchSeconds = stopWatch.Elapsed.Seconds.ToString();

                /*
                counter--;
                if (!(counter <= 0))
                    return true;
                return false;
                */
                return true;
            });




            // timer = new System.Timers.Timer(60);
            this.DateTime = DateTime.Now;
            Device.StartTimer(TimeSpan.FromSeconds(0), () =>
            {
                this.DateTime = DateTime.Now;
                return true;
            });


           
        }

        public event PropertyChangedEventHandler PropertyChanged;
        DateTime dateTime;

        public DateTime DateTime
        {
            get => dateTime;
            set
            {
                /*
                if(dateTime != value)
                {
                    dateTime = value;
                    if(PropertyChanged!=null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("DateTime"));
                    }
                }
                */


                dateTime = value;
                var args = new PropertyChangedEventArgs(nameof(DateTime)); //name of the method here.

                PropertyChanged?.Invoke(this, args);        //? is sugar to check if its null
                
            }

        }

        
        public string Timer
        {
           // get => timer;
           get { return sCounter; }
            set
            {
                timer = value;
                var args = new PropertyChangedEventArgs(nameof(Timer));
                PropertyChanged?.Invoke(this, args);
            }
        }

        public string stopWatchSeconds;
        public string StopWatchSeconds
        {
            get { return stopWatchSeconds;  }
            set
            {
                stopWatchSeconds = value;
                var args = new PropertyChangedEventArgs(nameof(StopWatchSeconds));
                PropertyChanged?.Invoke(this, args);
            }
        }
    }
}
