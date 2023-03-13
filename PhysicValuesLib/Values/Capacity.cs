using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicValuesLib.Values
{
    internal class Capacity : IValue
    {
        private double Value { get; set; }
        private string? From { get; set; }
        private string? To { get; set; }

        private string _valueName = "Электрическая емкость";

        public double GetConvertedValue(double value, string from, string to)
        {
            Value = value;
            From = from;
            To = to;
            ToSi();
            ToRequired();
            return Value;
        }
        public List<string> GetMeasureList()
        {
            List<string> list = new List<string>();
            foreach (var str in _coeff)
            {
                list.Add(str.Key);
            }
            return list;
        }

        public void ToRequired()
        {
            Value /= _coeff[To];
        }

        public void ToSi()
        {
            Value *= _coeff[From];
        }

        public string GetValueName()
        {
            return _valueName;
        }

        private Dictionary<string, double> _coeff = new Dictionary<string, double>()
    {
        { "Килофарад", 100},
        { "Фарад", 0.1},
        { "Миллифарад", 0.0001},
        { "Микрофарад", 0.0000001},
    };
    }
}

