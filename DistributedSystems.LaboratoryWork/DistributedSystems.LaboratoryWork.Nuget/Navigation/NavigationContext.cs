namespace DistributedSystems.LaboratoryWork.Nuget.Navigation;

/// <summary>
/// 
/// </summary>
public sealed class NavigationContext
{

    #region Nested

    public sealed class Builder
    {

        #region Fields

        private Type? _from;

        private Type? _to;

        private readonly Dictionary<string, object?> _parameters;

        #endregion

        #region Constructors

        private Builder()
        {
            _parameters = new Dictionary<string, object?>();
        }

        #endregion

        #region Methods

        public static Builder Create()
        {
            return new Builder();
        }

        public Builder From(
            Type fromType)
        {
            if (!fromType.GetInterfaces().Contains(typeof(INavigatable)))
            {
                throw new InvalidOperationException("Can't navigate from instance, which type not implement INavigatable");
            }

            _from = fromType;

            return this;
        }

        public Builder From<TNavigationSource>()
            where TNavigationSource : INavigatable
        {
            _from = typeof(TNavigationSource);

            return this;
        }

        public Builder To<TNavigationTarget>()
            where TNavigationTarget : INavigatable
        {
            _to = typeof(TNavigationTarget);

            return this;
        }

        public Builder WithParameter(
            string parameterName,
            object? parameterValue)
        {
            _parameters.Add(parameterName, parameterValue);

            return this;
        }

        public NavigationContext Build()
        {
            return new NavigationContext(
                _from ?? throw new ArgumentNullException(nameof(_from), "Navigation source not set"),
                _to ?? throw new ArgumentNullException(nameof(_to), "Navigation target not set"),
                _parameters);
        }

        #endregion

    }

    #endregion

    #region Constructors

    private NavigationContext(
        Type from,
        Type to,
        Dictionary<string, object?> parameters)
    {
        From = from;
        To = to;
        Parameters = parameters;
    }

    #endregion

    #region Properties

    public Type From
    {
        get;
    }

    public Type To
    {
        get;
    }

    private Dictionary<string, object?> Parameters
    {
        get;
    }

    public bool Cancelled
    {
        get;

        private set;
    }

    public object? this[
        string parameterName] =>
            GetParameter(parameterName);

    #endregion

    #region Methods

    public object? GetParameter(
        string parameterName)
    {
        return Parameters[parameterName];
    }

    public bool TryGetParameter(
        string parameterName,
        out object? parameterValue)
    {
        return Parameters.TryGetValue(parameterName, out parameterValue);
    }

    public void Cancel()
    {
        Cancelled = true;
    }

    #endregion

}