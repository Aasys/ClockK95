using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClockK95.utils;
using CUE.NET;
using CUE.NET.Devices.Generic;
using CUE.NET.Devices.Keyboard;
using CUE.NET.Devices.Mouse;

namespace ClockK95
{
    class CorsairRgb
    {
        private readonly CorsairKeyboard _keyboard;
        private readonly CorsairMouse _mouse;
        private readonly Dictionary<String, CorsairLed> _keyboardLedMap; 

        public CorsairRgb()
        {
            CueSDK.Initialize();
            _keyboard = CueSDK.KeyboardSDK;
            _mouse = CueSDK.MouseSDK;
            _keyboardLedMap = CorsairRgbUtil.GetCorsairLeds(_keyboard);
        }

        public CorsairKeyboard GetCorsairKeyboard()
        {
            return _keyboard;
        }

        public CorsairMouse GerCorsairMouse()
        {
            return _mouse;
        }

        public Dictionary<String, CorsairLed> GetKeyboardLedMap()
        {
            return _keyboardLedMap;
        }
    }
}
