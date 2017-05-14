using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace ZeBoneGame.MyWpf
{

    public abstract class ToBoolConverter<T> : IValueConverter
    {
        private readonly T _trueValue;
        private readonly T _falseValue;
        private Func<T, T, bool> _equalityFunc;
        private SolidColorBrush green;
        private System.Drawing.Color red;

        protected ToBoolConverter(T valueIfTrue, T valueIfFalse)
            : this(valueIfTrue, valueIfFalse, (a, b) => a.Equals(b))
        {

        }

        public ToBoolConverter(T trueValue,
            T falseValue,
            Func<T, T, bool> comparisonFonction)
        {
            _trueValue = trueValue;
            _falseValue = falseValue;
            this._equalityFunc = comparisonFonction;
        }

        

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool)
                return (bool)value ? _trueValue : _falseValue;

            return _falseValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is T)
            {
                return _equalityFunc((T)value, _trueValue);

            }

            return false;
        }
    }


}
