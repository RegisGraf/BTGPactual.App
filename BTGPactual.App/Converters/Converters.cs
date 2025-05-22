using System.Globalization;
using System.Text.RegularExpressions;

namespace BTGPactual.App.Converters
{
    public class IdadeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string valor = value.ToString();
            if (valor is null || string.IsNullOrEmpty(valor))
                valor = "0";

            string padrao = @"[^\d]";
            valor = Regex.Replace(valor, padrao, "");

            return valor;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            string valor = value.ToString();
            if (valor is null || string.IsNullOrEmpty(valor))
                valor = "0";

            string padrao = @"[^\d]";
            valor = Regex.Replace(valor, padrao, "");

            return valor;
        }
    }
}
