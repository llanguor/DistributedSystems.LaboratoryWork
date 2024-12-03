using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace DistributedSystems.LaboratoryWork.Nuget.Converters.Base;

public abstract class MultiValueConverterBase<TMultiValueConverter> :
    MarkupExtension,
    IMultiValueConverter
        where TMultiValueConverter : new()
{

    #region Fields

    private static readonly Lazy<TMultiValueConverter> _instance;

    #endregion

    #region Constructors

    static MultiValueConverterBase()
    {
        _instance = new Lazy<TMultiValueConverter>(() => new TMultiValueConverter());
    }

    #endregion

    #region System.Windows.Markup.MarkupExtension overrides

    public override object ProvideValue(
        IServiceProvider serviceProvider)
    {
        return _instance.Value;
    }

    #endregion

    #region System.Windows.Data.IMultiValueConverter implementation

    public abstract object? Convert(
        object[] values,
        Type targetType,
        object? parameter,
        CultureInfo culture);

    public virtual object[] ConvertBack(
        object? value,
        Type[] targetTypes,
        object? parameter,
        CultureInfo culture)
    {
        throw new NotSupportedException("Reverse conversion is not supported");
    }

    #endregion

}