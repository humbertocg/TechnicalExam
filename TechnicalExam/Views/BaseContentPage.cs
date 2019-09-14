using System;
using TechnicalExam.ViewModels;
using Xamarin.Forms;

namespace TechnicalExam
{
    public class BaseContentPage : ContentPage
    {
        public BaseContentPage()
        {
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            var vm = BindingContext as BaseViewModel;
            vm?.OnViewAppering();
        }

        protected override void OnDisappearing()
        {
            var vm = BindingContext as BaseViewModel;
            vm?.OnViewDisappering();
            base.OnDisappearing();
        }
    }
}
