using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ListIssue
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TestListViewPage : ContentPage
    {
        public TestListViewPage()
        {
            InitializeComponent();
            this.BindingContext = new TestingViewModel();
        }
    }
}
