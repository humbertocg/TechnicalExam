using System;
using System.Collections.Generic;
using TechnicalExam.ViewModels;
using Xamarin.Forms;

namespace TechnicalExam.Views
{
    public partial class AlgorithmsView : BaseContentPage
    {
        private AlgorithmsVM _vm;
        public AlgorithmsView()
        {
            InitializeComponent();
            _vm = new AlgorithmsVM()
            {
                Navigation = Navigation
            };
            BindingContext = _vm;
        }
    }
}
