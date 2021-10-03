using Generic.MVVM;
using MemoryTrainer.Environment;
using MemoryTrainer.Misc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace MemoryTrainer.ViewModel
{
    public class NumberGameViewModel : PageViewModel
    {
        private readonly NumberGenerator numberGenerator;
        private NumberSet numberSet;

        public NumberGameViewModel()
        {
            //Set the complexity level
            ComplexityLevel = new ObservableCollection<NumberComplexityEnum>();
            ComplexityLevel.Add(NumberComplexityEnum.Simple);
            ComplexityLevel.Add(NumberComplexityEnum.Medium);
            ComplexityLevel.Add(NumberComplexityEnum.Complex);
            SelectedComplexityLevel = ComplexityLevel.First();
            CharacterEnabled = true;

            // Init the components
            numberGenerator = new NumberGenerator();
            numberSet = new NumberSet();

            // Bind the commands
            Close = new DefaultCommand(OnClose);
            GenerateCreditCard = new DefaultCommand(OnGenerateVisaCard);
            GenerateIban = new DefaultCommand(OnGenerateIban);
            GenerateNumber = new DefaultCommand(OnGenerateNumber);

            Start = new DefaultCommand(OnStart);
            Resolve = new DefaultCommand(OnResolve);

            RemoveNumber = new DefaultCommand(OnRemoveNumber);
        }

        public ObservableCollection<NumberComplexityEnum> ComplexityLevel { get; private set; }

        public NumberComplexityEnum SelectedComplexityLevel { get; set; }

        public Number SelectedNumber { get; set; }

        public bool CharacterEnabled { get; set; }

        public ObservableCollection<Number> NumberCollection { get; private set; }

        public IRefreshCommand Start { get; private set; }

        public IRefreshCommand Resolve { get; private set; }

        public IRefreshCommand Close { get; private set; }

        public IRefreshCommand GenerateCreditCard { get; private set; }

        public IRefreshCommand GenerateIban { get; private set; }

        public IRefreshCommand GenerateNumber { get; private set; }

        public IRefreshCommand RemoveNumber { get; private set; }

        private void OnStart()
        {
            //TODO: Set all number games to start
        }

        private void OnResolve()
        {
            //TODO: Resolve all of them
        }

        private void OnGenerateIban()
        {
            var number = numberGenerator.CreateIban();
            AddEntry(number);
        }

        private void OnGenerateNumber()
        {
            int length;
            switch (SelectedComplexityLevel)
            {
                case NumberComplexityEnum.Simple:
                    length = 5;
                    break;
                case NumberComplexityEnum.Medium:
                    length = 10;
                    break;
                case NumberComplexityEnum.Complex:
                    length = 15;
                    break;
                default:
                    length = 0;
                    break;
            }

            if (length != 0)
            {
                var areCharsIncluded = CharacterEnabled;
                var number = numberGenerator.CreateNumber(5, areCharsIncluded);
                AddEntry(number);
            }
        }

        private void OnGenerateVisaCard()
        {
            var creditCardNumber = numberGenerator.CreateCreditCard();
            AddEntry(creditCardNumber);
        }

        private void OnRemoveNumber()
        {
            var currentSelection = SelectedNumber;
            if (currentSelection != null)
            {
                numberSet.Remove(currentSelection);
            }

            PopulateView();
        }

        private void AddEntry(Number number)
        {
            numberSet.Add(number);

            //Get the entries based on the order property
            var numbers = numberSet.Numbers.OrderBy(n => n.Order);
            PopulateView();
        }



        private void PopulateView()
        {
            //Get the entries based on the order property
            var numbers = numberSet.Numbers.OrderBy(n => n.Order);

            NumberCollection = new ObservableCollection<Number>(numbers);
            RaisePropertyChange("NumberCollection");
        }

        private void OnClose()
        {
            InternalClose();
        }
    }
}
