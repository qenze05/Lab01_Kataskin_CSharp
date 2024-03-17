using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using System.Windows;
using Lab01_Kataskin.Models;

namespace Lab01_Kataskin.ViewModels
{
    public class PersonInfoWindowViewModel: INotifyPropertyChanged
    {
        private Person _user;

        public string Name
        {
            get => _user.Name;
            set
            {
                _user.Name = value;
                OnPropertyChanged("Name");
            }
        }
        
        public string Surname
        {
            get => _user.Surname;
            set
            {
                _user.Surname = value;
                OnPropertyChanged("Surname");
            } 
        }
        
        public MailAddress Email
        {
            get => _user.Email;
            set
            {
                _user.Email = value;
                OnPropertyChanged("Email");
            } 
        }
        
        public DateTime Birthdate
        {
            get => _user.Birthdate.Date;
            set
            {
                _user.Birthdate = value;
                OnPropertyChanged("Birthdate");
            } 
        }
        
        public string IsAdult => _user.IsAdult ? "Yes" : "No";
        public Person.WesternSigns SunSign => _user.SunSign;
        public Person.ChineseSigns ChineseSign => _user.ChineseSign;
        public string IsBirthday
        {
            get
            {
                if (!_user.IsBirthday) return "No :(";
                MessageBox.Show("Happy Birthday!");
                return "Yes!";

            }
        }

        public PersonInfoWindowViewModel(Person user)
        {
            _user = user;
            
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}