using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;

namespace DistributedSystems.LaboratoryWork.Nuget.Converters.Base
{
    public abstract class ValueConverterBase<TValueConverter> :
        MarkupExtension,
        IValueConverter
            where TValueConverter : new()
    {

        #region Fields

        private static readonly Lazy<TValueConverter> _instance;

        #endregion

        #region Constructors

        static ValueConverterBase()
        {
            _instance = new Lazy<TValueConverter>(() => new TValueConverter());
        }

        #endregion

        #region System.Windows.Markup.MarkupExtension overrides

        public override object ProvideValue(
            IServiceProvider serviceProvider)
        {
            return _instance.Value!;
        }

        #endregion

        #region System.Windows.Data.IValueConverter implementation
        public abstract object? Convert(
            object value, 
            Type targetType, 
            object parameter, 
            CultureInfo culture);

        public virtual object ConvertBack(
            object value,
            Type targetType,
            object parameter,
            CultureInfo culture)
        {
            throw new NotSupportedException("Reverse conversion is not supported");
        }

        #endregion

    }
}
