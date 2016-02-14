using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using ClockK95.utils;
using CUE.NET.Devices.Generic;
using CUE.NET.Devices.Keyboard;

namespace ClockK95
{
    class Clock
    {
        private readonly CorsairKeyboard _keyboard;
        private readonly CorsairLed[] _gKeys;
        private Timer _timer;
        private bool _running = false;

        public bool Hour12or24 { get; set; } = false;
        public bool AmPmIndicatior { get; set; } = true;

        public Clock(CorsairKeyboard keyboard)
        {
            _keyboard = keyboard;
            _gKeys = CorsairRgbUtil.GetGKeys(CorsairRgbUtil.GetCorsairLeds(keyboard));
        }

        public void Start()
        {
            if (_timer == null)
            {
                _timer = new Timer(1000);
                _timer.Elapsed += new ElapsedEventHandler(Update);
            }
            _timer.Start();
            _running = true;
        }

        public void Stop()
        {
            _timer.Stop();
            _running = false;
        }

        public bool isRunning()
        {
            return _running;
        }

        private void Update(object sender, EventArgs e)
        {
            var hour24 = DateTime.Now.Hour;
            var isAm = hour24 == 0 || hour24 < 12;
            var hour12 = hour24;
            if (hour24 > 12)
                hour12 = 24 - hour12;
            else if (hour12 == 0)
                hour12 = 12; 

            var hour = Convert.ToString( (Hour12or24) ? hour24 : hour12, 2);
            var minute = Convert.ToString(DateTime.Now.Minute, 2);
            var second = Convert.ToString(DateTime.Now.Second, 2);
            
            CorsairRgbUtil.ColorAll(_gKeys, System.Drawing.Color.Black);

            if (AmPmIndicatior)
                Color(1, '1', (isAm) ? System.Drawing.Color.Yellow : System.Drawing.Color.Blue);
            


            //hour
            for (var i = hour.Length; i > 0; i--)
            {
                Color(6 + i - hour.Length, hour[i-1], System.Drawing.Color.Red);
            }

            //minute
            for (var i = minute.Length; i > 0; i--)
            {
                Color(12 + i - minute.Length, minute[i - 1], System.Drawing.Color.GreenYellow);
            }

            //second
            for (var i = second.Length; i > 0; i--)
            {
                Color(18 + i - second.Length, second[i - 1], System.Drawing.Color.Cyan);
            }

            _keyboard.Update();
        }

        private void Color(int gKey, char bit, Color color)
        {
            _gKeys[gKey-1].Color = bit.Equals('1') ? color : System.Drawing.Color.Black;
        }


    }
}
