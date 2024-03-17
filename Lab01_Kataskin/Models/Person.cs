using System;
using System.Net.Mail;

namespace Lab01_Kataskin.Models
{
    public class Person
    {
        private string _name;
        private string _surname;
        private MailAddress _email;
        private DateTime _birthdate;

        public string Name
        {
            get => _name;
            set => _name = value;
        }
        
        public string Surname
        {
            get => _surname;
            set => _surname = value;
        }
        
        public MailAddress Email
        {
            get => _email;
            set => _email = value;
        }

        public DateTime Birthdate
        {
            get => _birthdate;
            set
            {
                _birthdate = value;
                UpdateCalculatedValues();
            }
        }
        
        
        public bool IsAdult { get; private set; }
        public WesternSigns SunSign { get; private set; }
        public ChineseSigns ChineseSign { get; private set; }
        public bool IsBirthday { get; private set; }

        
        public Person(string name, string surname, MailAddress email, DateTime birthdate)
        {
            _name = name;
            _surname = surname;
            _email = email;
            _birthdate = birthdate;

            UpdateCalculatedValues();
        }

        public Person(string name, string surname, MailAddress email) :
            this(name, surname, email, new DateTime(0, 0, 2000))
        {
            
        }

        public Person(string name, string surname, DateTime birthdate) : this(name, surname, null, birthdate)
        {
            
        }
        
        private void UpdateCalculatedValues()
        {
            IsAdult = GetAge(_birthdate) >= 18;
            SunSign = GetWesternSignByDate(_birthdate);
            ChineseSign = GetChineseSignByDate(_birthdate);
            IsBirthday = _birthdate.Day == DateTime.Today.Day && _birthdate.Month == DateTime.Today.Month;
        }
        
        public static int GetAge(DateTime birthdate)
        {
            int years = DateTime.Today.Year - birthdate.Year;
            int months = DateTime.Today.Month - birthdate.Month;
            int days = DateTime.Today.Day - birthdate.Day;
            if (months < 0) return years - 1;
            if (months != 0) return years;
            if (days < 0) return years - 1;
            return years;
        }
        public enum WesternSigns
        {
            Aries, Taurus, Gemini, 
            Cancer, Leo, Virgo, 
            Libra, Scorpius, Sagittarius, 
            Capricornus, Aquarius, Pisces
        }

        public enum ChineseSigns
        {
            Rat, Ox, Tiger,
            Rabbit, Dragon, Snake,
            Horse, Goat, Monkey, 
            Rooster, Dog, Pig
        }
        
        private WesternSigns GetWesternSignByDate(DateTime date) 
        {
            switch (date.Month)
            {
                case 1:
                {
                    if (date.Day <= 19) return WesternSigns.Capricornus;
                    return WesternSigns.Aquarius;
                }
                case 2:
                {
                    if (date.Day <= 18) return WesternSigns.Aquarius;
                    return WesternSigns.Pisces;
                }
                case 3:
                {
                    if (date.Day <= 20) return WesternSigns.Pisces;
                    return WesternSigns.Aries;
                }
                case 4:
                {
                    if (date.Day <= 19) return WesternSigns.Aries;
                    return WesternSigns.Taurus;
                }
                case 5:
                {
                    if (date.Day <= 20) return WesternSigns.Taurus;
                    return WesternSigns.Gemini;
                }
                case 6:
                {
                    if (date.Day <= 21) return WesternSigns.Gemini;
                    return WesternSigns.Cancer;
                }
                case 7:
                {
                    if (date.Day <= 22) return WesternSigns.Cancer;
                    return WesternSigns.Leo;
                }
                case 8:
                {
                    if (date.Day <= 22) return WesternSigns.Leo;
                    return WesternSigns.Virgo;
                }
                case 9:
                {
                    if (date.Day <= 22) return WesternSigns.Virgo;
                    return WesternSigns.Libra;
                }
                case 10:
                {
                    if (date.Day <= 23) return WesternSigns.Libra;
                    return WesternSigns.Scorpius;
                }
                case 11:
                {
                    if (date.Day <= 21) return WesternSigns.Scorpius;
                    return WesternSigns.Sagittarius;
                }
                case 12:
                {
                    if (date.Day <= 21) return WesternSigns.Sagittarius;
                    return WesternSigns.Capricornus;
                }
            }

            throw new Exception("Month number is incorrect");

        }

        private ChineseSigns GetChineseSignByDate(DateTime date)
        {
            switch (date.Year % 12)
            {
                case 0: return ChineseSigns.Monkey;
                case 1: return ChineseSigns.Rooster;
                case 2: return ChineseSigns.Dog;
                case 3: return ChineseSigns.Pig;
                case 4: return ChineseSigns.Rat;
                case 5: return ChineseSigns.Ox;
                case 6: return ChineseSigns.Tiger;
                case 7: return ChineseSigns.Rabbit;
                case 8: return ChineseSigns.Dragon;
                case 9: return ChineseSigns.Snake;
                case 10: return ChineseSigns.Horse;
                case 11: return ChineseSigns.Goat;
            }

            throw new Exception("Year number in incorrect");
        }
    }
}