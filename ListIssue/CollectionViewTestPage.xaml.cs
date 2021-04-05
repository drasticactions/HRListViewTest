using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ListIssue
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CollectionViewTestPage : ContentPage
    {
        public CollectionViewTestPage()
        {
            InitializeComponent();
            this.BindingContext = new TestingViewModel();
        }
    }
}