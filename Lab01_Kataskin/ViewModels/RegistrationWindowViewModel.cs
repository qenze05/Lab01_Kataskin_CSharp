using System;
using System.ComponentModel;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Windows;
using Lab01_Kataskin.Exceptions;
using Lab01_Kataskin.Models;
using Lab01_Kataskin.Services;
using Lab01_Kataskin.Tools;

namespace Lab01_Kataskin.ViewModels
{
    public class RegistrationWindowViewModel: INotifyPropertyChanged
    {
        private string _userName, _userSurname, _userEmail;
        private DateTime _userBirthdate;
        private RelayCommand _proceedCommand;
        private RelayCommand _cancelCommand;
        private readonly Action _proceedAction;
        private bool _isEnabled = true;        
        public RelayCommand ProceedCommand => _proceedCommand ?? (_proceedCommand = new RelayCommand(Proceed, CanExecute));
        public RelayCommand CancelCommand => _cancelCommand ?? (_cancelCommand = new RelayCommand(Cancel));

        private void Cancel()
        {
            System.Windows.Application.Current.Shutdown();        
        }
        
        private async void Proceed()
        {
            Person? user = null;
            try
            {
                IsEnabled = false;
                user = await Task.Run(() =>
                    AuthService.AuthenticateUser(UserName, UserSurname, UserEmail, UserBirthdate));


            }
            catch (Exception)
            {
                MessageBox.Show("Unable to create User");
                return;
            }
            finally
            {
                IsEnabled = true;
            }

            if (user == null)
            {
                MessageBox.Show("Unable to create User");
                return;
            }

            try
            {
                AuthService.ValidateAge(user.Birthdate);
            }
            catch (TooOldException)
            {
                MessageBox.Show("Unable to create User: Too Old");
                return;
            }
            catch (NegativeAgeException)
            {
                MessageBox.Show("Unable to create User: Negative Age");
                return;
            }
            
            
            User = user;
            _proceedAction.Invoke();
        }
        
        private bool CanExecute()
        { 
            
            return !string.IsNullOrWhiteSpace(UserName) 
                && !string.IsNullOrWhiteSpace(UserSurname) 
                && (AuthService.ValidateEmail(UserEmail) 
                    && AuthService.ValidateDate(UserBirthdate));
        }

        

        public Person User { get; private set; }

        public bool IsEnabled
        {
            get => _isEnabled;
            set
            {
                _isEnabled = value;
                OnPropertyChanged("IsEnabled");
            } 
        }
        public string UserName
        {
            get => _userName;
            set
            {
                _userName = value;
                OnPropertyChanged("UserName");
            }
        } 
        public string UserSurname
        {
            get => _userSurname;
            set
            {
                _userSurname = value;
                OnPropertyChanged("UserSurname");
            }
        } 
        public string UserEmail
        {
            get => _userEmail;
            set
            {
                _userEmail = value;
                OnPropertyChanged("UserEmail");
            }
        } 
        public DateTime UserBirthdate
        {
            get => _userBirthdate;
            set
            {
                _userBirthdate = value;
                OnPropertyChanged("UserBirthdate");
            }
        } 
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        
        public RegistrationWindowViewModel(Action proceedAction)
        {
            UserBirthdate = DateTime.Today;
            _proceedAction = proceedAction;
        }
    }
}