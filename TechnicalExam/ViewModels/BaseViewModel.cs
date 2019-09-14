using System;
using System.Threading.Tasks;
using Algorithms;
using TechnicalExam.Services.Local;
using Xamarin.Forms;

namespace TechnicalExam.ViewModels
{
    public class BaseViewModel : MvvmHelpers.BaseViewModel
    {
        public IDependecyService DependencyService { get; set; }
        public IAlgorithms Algorithms { get; set; }
        public INavigation Navigation { get; set; }

        public BaseViewModel(): this (new LocalDependencyService())
        {
            
        }

        public BaseViewModel(IDependecyService dependecyService)
        {
            DependencyService = dependecyService;
            Algorithms = dependecyService.Get<IAlgorithms>();
        }

        public virtual async Task OnViewAppering()
        {

        }

        public virtual async Task OnViewDisappering()
        {

        }
    }
}

