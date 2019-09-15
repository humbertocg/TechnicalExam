using System;
using System.Threading.Tasks;
using System.Windows.Input;
using TechnicalExam.Services.Local;
using Xamarin.Forms;

namespace TechnicalExam.ViewModels
{
    public class AlgorithmsVM : BaseViewModel
    {
        //Count Vowels
        private string _countVowelsText;
        public string CountVowelsText
        {
            get => _countVowelsText;
            set
            {
                SetProperty(ref _countVowelsText, value);
                OnPropertyChanged(nameof(IsEnabledCountVowels));
            }
        }
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
        public bool IsEnabledCountVowels => !string.IsNullOrEmpty(CountVowelsText);

        //Diff Dates
        private DateTime _startDate;
        public DateTime StartDate
        {
            get => _startDate;
            set
            {
                SetProperty(ref _startDate, value);
                OnPropertyChanged(nameof(IsEnabledDiffMinutes));
            }
        }
        private DateTime _endDate;
        public DateTime EndDate
        {
            get => _endDate;
            set
            {
                SetProperty(ref _endDate, value);
                OnPropertyChanged(nameof(IsEnabledDiffMinutes));
            }
        }
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
        public bool IsEnabledDiffMinutes => StartDate < EndDate;

        //Reverse string
        public string _reverseStringText;
        public string ReverseStringText
        {
            get => _reverseStringText;
            set
            {
                SetProperty(ref _reverseStringText, value);
                OnPropertyChanged(nameof(IsEnabledReverseString));
            }
        }
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
        public bool IsEnabledReverseString => !string.IsNullOrEmpty(ReverseStringText);

        //fizzbuzz List
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

        //characters repeated
        private string _stringA;
        public string StringA
        {
            get => _stringA;
            set
            {
                SetProperty(ref _stringA, value);
                OnPropertyChanged(nameof(IsEnabledCharRepeated));
            }
        }
        private string _stringB;
        public string StringB
        {
            get => _stringB;
            set
            {
                SetProperty(ref _stringB, value);
                OnPropertyChanged(nameof(IsEnabledCharRepeated));
            }
        }
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
        public bool IsEnabledCharRepeated => !string.IsNullOrEmpty(StringA) && !string.IsNullOrEmpty(StringB);

        //Compute PI value
        private string _pIResultText;
        public string PIResultText
        {
            get => _pIResultText;
            set
            {
                SetProperty(ref _pIResultText, value);
                OnPropertyChanged(nameof(PIResultText));
            }
        }
        public ICommand GetPIValueCommand { get; set; }

        //Compress String
        private string _compressStringText;
        public string CompressStringText
        {
            get => _compressStringText;
            set
            {
                SetProperty(ref _compressStringText, value);
                OnPropertyChanged(nameof(IsEnabledCompressString));
            }
        }
        private string _compressResultText;
        public string CompressResultText
        {
            get => _compressResultText;
            set
            {
                SetProperty(ref _compressResultText, value);
                OnPropertyChanged(nameof(CompressResultText));
            }
        }
        public ICommand GetCompressStringCommand { get; set; }
        public bool IsEnabledCompressString => !string.IsNullOrEmpty(CompressStringText);

        public AlgorithmsVM() : this(new LocalDependencyService()) { }

        public AlgorithmsVM(IDependecyService depencyService) : base(depencyService)
        {
            var dateInitial = DateTime.Now;
            StartDate = new DateTime(dateInitial.Year, dateInitial.Month, dateInitial.Day, 0, 0, 0);
            EndDate = StartDate.AddDays(1);
            GetCountVowelsCommand = new Command(async () => await GetCountVowelsAsyncAction());
            GetDiffMinutesCommand = new Command(async () => await GetDiffMinutesAsyncAction());
            GetReverseStringCommand = new Command(async () => await GetReverseStringAsyncAction());
            GetFizzbuzzListCommand = new Command(GetFizzbuzzListAsyncAction);
            GetCharRepeatedCommand = new Command(async () => await GetCharRepeatedAsyncAction());
            GetPIValueCommand = new Command(GetPIValueAsyncAction);
            GetCompressStringCommand = new Command(async () => await GetCompressStringAsyncAction());
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

        /// <summary>
        /// Compute PI
        /// </summary>
        private void GetPIValueAsyncAction()
        {
            PIResultText = "PI value: " + Algorithms.ComputePiValue().ToString();
        }

        /// <summary>
        /// Get a compressed version of a string
        /// </summary>
        /// <returns></returns>
        private async Task GetCompressStringAsyncAction()
        {
            if (!string.IsNullOrEmpty(CompressStringText))
            {
                CompressResultText = string.Format("String compressed: {0}", Algorithms.CompressString(CompressStringText));
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Warning", "Enter a text before to continue", "Ok");
            }
        }
    }
}

