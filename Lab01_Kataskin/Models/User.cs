using System;

namespace Lab01_Kataskin.Models
{
    public class User
    {
        private DateTime _birthDate;
        private WesternSigns _westernSign;
        private ChineseSigns _chineseSigns;
        public DateTime BirthDate
        {
            get => _birthDate;
            set => _birthDate = value;
        }
        public WesternSigns WesternSign
        {
            get => _westernSign;
            private set => _westernSign = value;
        }
        public ChineseSigns ChineseSign
        {
            get => _chineseSigns;
            private set => _chineseSigns = value;
        }

        public User()
        {
            BirthDate = DateTime.Today.Subtract(TimeSpan.FromDays(1));
            WesternSign = GetWesternSignByDate(BirthDate);
            ChineseSign = GetChineseSignByDate(BirthDate);
        }
        public User(DateTime birthDate)
        {
            BirthDate = birthDate;
            WesternSign = GetWesternSignByDate(BirthDate);
            ChineseSign = GetChineseSignByDate(BirthDate);

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
        
        
        
        
    }
}