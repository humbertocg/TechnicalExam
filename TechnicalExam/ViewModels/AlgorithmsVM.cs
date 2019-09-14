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

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        private string _diffMinutesResultText;
        public string DiffMinutesResultText
        {
            get => _diffMinutesResultText;
            set
            {
                SetProperty(ref _diffMinutesResultText, value);
                OnPropertyChanged(nameof(DiffMinutesResultText));
            }
        }
        public ICommand GetDiffMinutesCommand { get; set; }

        public AlgorithmsVM() : this(new LocalDependencyService()) { }

        public AlgorithmsVM(IDependecyService depencyService) : base(depencyService)
        {
            StartDate = DateTime.Now;
            EndDate = DateTime.Now.AddDays(1);
            GetCountVowelsCommand = new Command(async () => await GetCountVowelsAsyncAction());
            GetDiffMinutesCommand = new Command(async () => await GetDiffMinutesAsyncAction());
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

        /// <summary>
        /// Perform a substraction between 2 dates and get an output in DiffMinutesResultText
        /// </summary>
        /// <returns></returns>
        private async Task GetDiffMinutesAsyncAction()
        {
            if(StartDate < EndDate)
            {
                DiffMinutesResultText = string.Format("Total minutes: {0}", Algorithms.GetDiffMinutes(StartDate,EndDate));
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Warning", "End date should be bigger than start date.", "Ok");
            }
        }

    }
}

