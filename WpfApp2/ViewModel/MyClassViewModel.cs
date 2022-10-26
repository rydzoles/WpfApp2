using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApp2.ViewModel
{
  
    using System.Windows.Automation;
    using System.Windows.Input;

    public class MyClassViewModel: INotifyPropertyChanged
    {
     private   MyClass myClass = new MyClass();

        public event PropertyChangedEventHandler PropertyChanged;
       
        private ICommand addNewValueCommand = null;// { get; set; }
        public double Wartość
        {
            get { return  myClass.Wartosc; }
            set { myClass.Wartosc = value;
                onPropertyChanged(nameof(Wartość));
            }
        }
        public ICommand AddNewValueCommand
        {
            // Wartość =myClass.Wartosc;
            get
            {
              //  myClass.AddValue();
                addNewValueCommand = new RelayCommand(myClass.AddValue);
                onPropertyChanged(nameof(Wartość));

                return addNewValueCommand;
            }
        }
        public void Start()
        {
            addNewValueCommand = new RelayCommand(myClass.AddValue);
        }

       

        public void onPropertyChanged(string NazwaWlasnosci)
        {
          
            if (PropertyChanged != null) 
                PropertyChanged(this, new PropertyChangedEventArgs(NazwaWlasnosci));    

        }
    }
}
