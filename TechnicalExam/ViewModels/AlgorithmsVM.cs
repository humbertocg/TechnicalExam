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

        public string ReverseStringText { get; set; }
        private string _reverseResultText;
        public string ReverseResultText
        {
            get => _reverseResultText;
            set
            {
                SetProperty(ref _reverseResultText, value);
                OnPropertyChanged(nameof(ReverseResultText));
            }
        }
        public ICommand GetReverseStringCommand { get; set; }

        public string _fizzbuzzText;
        public string FizzbuzzText
        {
            get => _fizzbuzzText;
            set
            {
                SetProperty(ref _fizzbuzzText, value);
                OnPropertyChanged(nameof(FizzbuzzText));
            }
        }
        public ICommand GetFizzbuzzListCommand { get; set; }

        public string StringA { get; set; }
        public string StringB { get; set; }
        private string _charRepeatedText;
        public string CharRepeatedText
        {
            get => _charRepeatedText;
            set
            {
                SetProperty(ref _charRepeatedText, value);
                OnPropertyChanged(nameof(CharRepeatedText));
            }
        }
        public ICommand GetCharRepeatedCommand { get; set; }

        public AlgorithmsVM() : this(new LocalDependencyService()) { }

        public AlgorithmsVM(IDependecyService depencyService) : base(depencyService)
        {
            StartDate = DateTime.Now;
            EndDate = DateTime.Now.AddDays(1);
            GetCountVowelsCommand = new Command(async () => await GetCountVowelsAsyncAction());
            GetDiffMinutesCommand = new Command(async () => await GetDiffMinutesAsyncAction());
            GetReverseStringCommand = new Command(async () => await GetReverseStringAsyncAction());
            GetFizzbuzzListCommand = new Command(GetFizzbuzzListAsyncAction);
            GetCharRepeatedCommand = new Command(async () => await GetCharRepeatedAsyncAction());
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

        /// <summary>
        /// Perform a reverse for given a string 
        /// </summary>
        /// <returns></returns>
        private async Task GetReverseStringAsyncAction()
        {
            if (!string.IsNullOrEmpty(ReverseStringText))
            {
                ReverseResultText = string.Format("Reverse string: {0}", Algorithms.GetReverseString(ReverseStringText));
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Warning", "Enter a text before to continue", "Ok");
            }
        }

        /// <summary>
        /// Get fizzbuzz List
        /// </summary>
        /// <returns></returns>
        private void GetFizzbuzzListAsyncAction()
        {
            var fizzbuzzList = Algorithms.GetFizzBuzzList();
            string listToString = "";
            int index = 0;
            foreach(var item in fizzbuzzList)
            {
                listToString += item;
                if(index<fizzbuzzList.Count-1)
                {
                    listToString += ", ";
                }
                index++;
            }
            FizzbuzzText = listToString;
        }

        /// <summary>
        /// Get characters repeated between 2 strings
        /// </summary>
        /// <returns></returns>
        private async Task GetCharRepeatedAsyncAction()
        {
            if(string.IsNullOrEmpty(StringA))
            {
                await Application.Current.MainPage.DisplayAlert("Warning", "Enter a text in String A before to continue", "Ok");
                return;
            }
            if(string.IsNullOrEmpty(StringB))
            {
                await Application.Current.MainPage.DisplayAlert("Warning", "Enter a text in String B before to continue", "Ok");
                return;
            }
            if(StringA != StringB)
            {
                CharRepeatedText = "Characters repeated: " + string.Concat(Algorithms.GetCharacterArrayRepeated(StringA, StringB));
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Warning", "String A and String B should be distinct", "Ok");
            }
        }
    }
}

