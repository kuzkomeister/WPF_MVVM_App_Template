using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;
using System.Windows.Markup;

namespace MyWPF.Converters
{
    class ObjectsEqualConverter<T> : MarkupExtension, IMultiValueConverter
    {
        public T EqualValue { get; set; }
        public T NotEqualValue { get; set; }
        public object Convert(object[] values, Type tt, object p, CultureInfo ci)
            => values[0].Equals(values[1]) ? EqualValue : NotEqualValue;
        public object[] ConvertBack(object value, Type[] tt, object p, CultureInfo ci)
            => throw new NotImplementedException();
        public override object ProvideValue(IServiceProvider serviceProvider)
            => this;
    }
}
