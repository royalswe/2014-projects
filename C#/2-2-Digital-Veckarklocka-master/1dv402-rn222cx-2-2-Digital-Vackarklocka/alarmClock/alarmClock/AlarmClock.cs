using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alarmClock
{
    public class AlarmClock
    {
        //Deklarera variabler
        int _alarmHour, _alarmMinute,_hour, _minute;
        //konstanta värden för att snabbt kunna ändra tidsformat    
        const int _constMinute = 59;
        const int _constHour = 23;

        public int AlarmHour
        {
            get { return _alarmHour; }

            set
            {
                if (value < 0 || value > _constHour)
                {
                    throw new ArgumentException("Alarmtimmen är inte i intervallet 0-23");
                }

                _alarmHour = value;
            }
        }

        public int AlarmMinute
        {
            get { return _alarmMinute; }

            set
            {
                if (value < 0 || value > _constMinute)
                {
                    throw new ArgumentException("Alarmminuten är inte i intervallet 0-59");
                }

                _alarmMinute = value;
            }
        }
        public int Hour
        {
            get { return _hour; }

            set
            {
                if (value < 0 || value > _constHour)
                {
                    throw new ArgumentException("Timmen är inte i intervallet 0-23");
                }

                _hour = value;
            }
        }
        public int Minute
        {
            get { return _minute; }

            set
            {
                if (value < 0 || value > _constMinute)
                {
                    throw new ArgumentException("Minuten är inte i intervallet 0-59");
                }

                _minute = value;
            }
        }
        public AlarmClock():this(0 ,0) 
        {
            //Tom, Ärver från den nedre konstruktorn
        }
        public AlarmClock(int hour, int minute):this(hour, minute, 0, 0)
        {
            //Tom, Ärver från den nedre konstruktorn
        }
        public AlarmClock(int hour, int minute, int alarmHour, int alarmMinute) 
        {
            Hour = hour;
            Minute = minute;
            AlarmHour = alarmHour;
            AlarmMinute = alarmMinute;
        }
        public bool TickTock() //Ger _minute ökande tal som därefter ger _hour ökande tal. 
        {
            if (_minute < MaxMinute)
            {
                _minute++;
            }
            else
            {
                _minute = 0;
                if (_hour < MaxtHour)
                {
                    _hour++;
                }
                else
                {
                    _hour = 0;
                }
            }

            //_minute++;

            //if (_minute == MaxMinute + 1)
            //{
            //    _minute = 0;
            //    _hour++;
            //    if (_hour == MaxtHour + 1)
            //    {
            //        _hour = 0;
            //    }
            //}

            return _alarmMinute == _minute && _alarmHour == _hour;
        }
        public string ToString() // returnera tiden i text
        {
            return String.Format("{0,5}:{1:00} <{2}:{3:00}>", _hour, _minute, _alarmHour, _alarmMinute);
        }
    }
}
