using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using CUE.NET.Devices.Generic;
using CUE.NET.Devices.Keyboard;
using CUE.NET.Devices.Keyboard.Keys;

namespace ClockK95.utils
{
    static class CorsairRgbUtil
    {
        public static Dictionary<string, CorsairLed> GetCorsairLeds(CorsairKeyboard keyboard)
        {
            return keyboard.Keys.ToDictionary(key => key.KeyId.ToString(), key => key.Led);
        }

        public static CorsairLed[] GetGKeys(Dictionary<string, CorsairLed> ledMap)
        {
            var maxG = 18;
            var gLeds = new CorsairLed[18];

            for (var i = 1; i <= 18 ; i++)
            {
                gLeds[i-1] = ledMap["G" + i];
            }
            return gLeds;
        }

        public static void ColorAll(CorsairLed[] leds, Color color)
        {
            foreach (var corsairLed in leds)
            {
                corsairLed.Color = color;
            }
        }
    }
}
