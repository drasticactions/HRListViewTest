using System;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ListIssue
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new TabNavPage();

            Xamarin.Forms.Xaml.Diagnostics.VisualDiagnostics.VisualTreeChanged += VisualDiagnostics_VisualTreeChanged;
        }

        private void VisualDiagnostics_VisualTreeChanged(object sender, Xamarin.Forms.Xaml.Diagnostics.VisualTreeChangeEventArgs e)
        {
            var parentSourInfo = Xamarin.Forms.Xaml.Diagnostics.VisualDiagnostics.GetXamlSourceInfo(e.Parent);
            var childSourInfo = Xamarin.Forms.Xaml.Diagnostics.VisualDiagnostics.GetXamlSourceInfo(e.Child);
            Debug.WriteLine($"VisualTreeChangeEventArgs {e.ChangeType}:" +
                $"{e.Parent}:{parentSourInfo?.SourceUri}:{parentSourInfo?.LineNumber}:{parentSourInfo?.LinePosition}-->" +
                $" {e.Child}:{childSourInfo?.SourceUri}:{childSourInfo?.LineNumber}:{childSourInfo?.LinePosition}");
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
