using System;
using System.Net.Mail;
using Lab01_Kataskin.Models;

namespace Lab01_Kataskin.Services
{
    public static class AuthService
    {
        public static Person AuthenticateUser(string name, string surname, string email, DateTime birthdate)
        {
            var emailVal = ValidateEmail(email);
            var dateVal = ValidateDate(birthdate);

            if (!emailVal && !dateVal)
            {
                return null;
            }
            
            if (!emailVal)
            {
                return new Person(name, surname, birthdate);
            }

            if (!dateVal)
            {
                return new Person(name, surname, new MailAddress(email));
            }

            return new Person(name, surname, new MailAddress(email), birthdate);
        }
        
        public static bool ValidateEmail(string emailString)
        {
            try
            {
                _ = new MailAddress(emailString);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
        public static bool ValidateDate(DateTime date)
        {
            return date <= DateTime.Today && Person.GetAge(date) <= 135;
        }
    }
}