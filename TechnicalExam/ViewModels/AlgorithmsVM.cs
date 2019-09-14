using System;
using System.Threading.Tasks;
using System.Windows.Input;
using TechnicalExam.Services.Local;
using Xamarin.Forms;

namespace TechnicalExam.ViewModels
{
    public class AlgorithmsVM : BaseViewModel
    {
        public string CountVowelsText { get; set; }
        private string _countResultText;
        public string CountResultText
        {
            get => _countResultText;
            set
            {
                SetProperty(ref _countResultText, value);
                OnPropertyChanged(nameof(CountResultText));
            }
        }
        public ICommand GetCountVowelsCommand { get; set; }

        public AlgorithmsVM() : this(new LocalDependencyService()) { }

        public AlgorithmsVM(IDependecyService depencyService) : base(depencyService)
        {
            GetCountVowelsCommand = new Command(async () => await GetCountVowelsAsyncAction());
        }

        /// <summary>
        /// Perform Count of Vowels in CountVowelsText, output in CountResultText
        /// </summary>
        private async Task GetCountVowelsAsyncAction()
        {
            if (!string.IsNullOrEmpty(CountVowelsText))
            {
                CountResultText = string.Format("Total Vowels: {0}", Algorithms.GetVowelsCount(CountVowelsText).ToString());
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Warning", "Enter a text before to continue", "Ok");
            }
        }
    }
}

