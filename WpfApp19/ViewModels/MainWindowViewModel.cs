using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApp19.ViewModels
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string PropertyName=null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        // свойство, соответствующее полю ввода в окне
        private double inputRadius;

        public double InputRadius
        {
            get => inputRadius;
            set
            {
                inputRadius = value;
                OnPropertyChanged();
            }
        }


        // свойство, соответствующее полю вывода в окне
        private double outputCircumference;

        public double OutputCircumference
        {
            get => outputCircumference;
            set
            {
                outputCircumference = value;
                OnPropertyChanged();
            }
        }


        // Создание команды
        public ICommand GetCircumference { get; }

        // Вычисление площади с помощью стат. метода
        private void OnGetCircumferenceCommandExecute(object p)
        {
            OutputCircumference = Geometry.GetCircumference(inputRadius);                       
        }

        //Проверка активности выполнеия команды
        private bool CanOnGetCircumferenceCommandExecute(object p)
        {
            if (InputRadius > 0) return true;
            else return false;
        }

        //Добавляем команду
        public MainWindowViewModel()
        {
            GetCircumference = new RelayCommand(OnGetCircumferenceCommandExecute, CanOnGetCircumferenceCommandExecute);
        }
    }
}
