using Generic.MVVM;
using MemoryTrainer.Environment;
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
            numberGenerator = new NumberGenerator();
            numberSet = new NumberSet();

            // Bind the commands
            Close = new DefaultCommand(OnClose);
            GenerateCreditCard = new DefaultCommand(OnGenerateVisaCard);
        }

        public ObservableCollection<Number> NumberCollection { get; private set; }

        public IRefreshCommand Close { get; private set; }

        public IRefreshCommand GenerateCreditCard { get; private set; }

        private void OnGenerateVisaCard()
        {
            var creditCardNumber = numberGenerator.CreateCreditCard();
            numberSet.Add(creditCardNumber);

            Refresh();
        }

        private void OnGenerateNumber()
        {

        }

        private void Refresh()
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
