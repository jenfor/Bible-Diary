using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bible_Diary.ViewModels;
using Xamarin.Forms;

namespace Bible_Diary
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private MainPageViewModel _vm;
        public MainPage()
        {
            InitializeComponent();
            BindingContext = _vm = new MainPageViewModel();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            _vm.SaveDiary();
        }

    }
}