using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace WpfApplication1.model
{
    public class ErrorManager
    {
        public class Errors
        {
            public const uint ERROR_NONE = 0x0;

            public const uint ERROR_PRINTER_OFFLINE = 0x1;
            public const uint ERROR_PRINTER_PAPER_JAM = 0x2;
            public const uint ERROR_PRINTER_NO_PAPER = 0x4;
            public const uint ERROR_PRINTER_DOOR_OPEN = 0x8;
            public const uint ERROR_PRINTER_OTHER = 0x10;


            public const uint ERROR_THERMAL_NO_PAPER = 0x20;
            public const uint ERROR_THERMAL_OTHER = 0x40;

            public const uint ERROR_BATTERY_POWER = 0x80;

            public const uint ERROR_PRINTER_NO_TONER = 0x100;
        }

        public string[] DecodeErrors(uint errors)
        {
            LinkedList<string> ret = new LinkedList<string>();
            Type errorTypes = typeof(Errors);
            FieldInfo[] fields = errorTypes.GetFields();
            foreach (FieldInfo fi in fields)
            {
                string name = fi.Name;
                uint value = (uint)fi.GetValue(null);
                if ((errors & value) != 0)
                {
                    ret.AddLast(name);
                    errors ^= value;
                }
            }
            if (errors != 0) ret.AddLast("Інші помилки");
            return ret.ToArray();
        }


        public uint DetectErrors()
        {
            uint errors = (App.Current as App).printerWrapper.DetectErrors();

            //TODO Add wrappers
            //errors |= (App.Current as App).thermalWrapper.DetectErrors();
            //if (PowerSource.IsOnBattery()) errors |= Errors.ERROR_BATTERY_POWER;

            return errors;

        }
    }
}
