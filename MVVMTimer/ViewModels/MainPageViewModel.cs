using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace MVVMTimer.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public MainPageViewModel()
        {
            this.DateTime = DateTime.Now;
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
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
                if(dateTime != value)
                {
                    dateTime = value;
                    if(PropertyChanged!=null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("DateTime"));
                    }
                }

                /*
                appDateTime = value;
                var args = new PropertyChangedEventArgs(nameof(DateTime)); //name of the method here.

                PropertyChanged?.Invoke(this, args);        //? is sugar to check if its null
                */
            }

        }
    }
}
