using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ListIssue
{
    public class TestingViewModel : INotifyPropertyChanged
    {
        public TestingViewModel()
        {
            this.Init();
        }

        private int totalNum = 20000;

        public List<string> ListTest { get; set; } = new List<string>();

        public ObservableCollection<string> CollectionTest { get; set; } = new ObservableCollection<string>();

        public void Init()
        {
            for (var i = 0; i < totalNum; i++)
            {
                ListTest.Add($"List {i}");
                CollectionTest.Add($"Collection {i}");
            }
        }

        /// <inheritdoc/>
        public event PropertyChangedEventHandler PropertyChanged;

#pragma warning disable SA1600 // Elements should be documented
        protected bool SetProperty<T>(ref T backingStore, T value, [CallerMemberName] string propertyName = "", Action onChanged = null)
#pragma warning restore SA1600 // Elements should be documented
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
            {
                return false;
            }

            backingStore = value;
            onChanged?.Invoke();
            this.OnPropertyChanged(propertyName);
            return true;
        }

        /// <summary>
        /// On Property Changed.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                var changed = this.PropertyChanged;
                if (changed == null)
                {
                    return;
                }

                changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
            });
        }
    }
}
