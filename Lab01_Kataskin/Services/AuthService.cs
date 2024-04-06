using System;
using System.Net.Mail;
using System.Text.RegularExpressions;
using Lab01_Kataskin.Exceptions;
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
                ValidateEmailRegex(emailString);
                _ = new MailAddress(emailString);
            }
            catch (WrongEmailException)
            {
                return false;
            }
            catch (Exception)
            {
                return false;
            }
            

            return true;
        }

        private static void ValidateEmailRegex(string email)
        {
            if (!new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$").IsMatch(email))
            {
                throw new WrongEmailException();
            }
        }
        public static bool ValidateDate(DateTime date)
        {
            try
            {
                ValidateAge(date);
            }
            catch (TooOldException)
            {
                Console.Out.WriteLine("Too old");
                return false;
            }
            catch (NegativeAgeException)
            {
                Console.Out.WriteLine("Negative age");

                return false;
            }

            return true;
        }

        public static void ValidateAge(DateTime date)
        {
            if (date > DateTime.Today)
            {
                throw new NegativeAgeException("Negative age");
            }  
            if (Person.GetAge(date) > 135)
            {
                throw new TooOldException("Age is too high");
            }
        }
    }
}