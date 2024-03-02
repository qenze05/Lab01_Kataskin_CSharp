using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using Lab01_Kataskin.Models;

namespace Lab01_Kataskin.ViewModels
{
    internal class DatePickerViewModel: INotifyPropertyChanged
    {
        
        
        private User _user = new User();
        private int _age;
        private User.WesternSigns _westernSign;
        private User.ChineseSigns _chineseSign;
        
        public event PropertyChangedEventHandler PropertyChanged;

        public DatePickerViewModel()
        {
            SelectedDate = _user.BirthDate;
        }
        public DateTime SelectedDate
        {
            get => _user.BirthDate;
            set
            {
                if(ValidateDate(value)) _user = new User(value);
                WesternSign = _user.WesternSign;
                ChineseSign = _user.ChineseSign;
                Age = (int)((DateTime.Now - _user.BirthDate).TotalDays / 365.2425);
            }
        }
        
        public int Age
        {
            get => _age;
            set
            {
                _age = value;
                OnPropertyChanged("Age");
            }
        }

        public User.WesternSigns WesternSign
        {
            get => _westernSign;
            set
            {
                _westernSign = value;
                OnPropertyChanged("WesternSign");
            }
        }
        
        public User.ChineseSigns ChineseSign
        {
            get => _chineseSign;
            set
            {
                _chineseSign = value;
                OnPropertyChanged("ChineseSign");
            }
        }
        
        private void OnPropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        
        private static bool ValidateDate(DateTime date)
        {
            //135 years = 49307.6968 days
            if (date < DateTime.Now - TimeSpan.FromDays(49307.6968))
            {
                ShowMessage("Неправильні дані: вказаний вік більше 135 років.");
                return false;
            }  
            
            if (date > DateTime.Now)
            {
                ShowMessage("Неправильні дані: вказаний вік негативний.");
                return false;
            }

            if (date.Day == DateTime.Now.Day && date.Month == DateTime.Now.Month)
            {
                ShowMessage("З днем народження =)");
            }
            return true;
        }
        private static void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }
    }
}