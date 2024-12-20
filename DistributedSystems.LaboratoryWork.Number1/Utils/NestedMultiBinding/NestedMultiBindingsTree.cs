﻿using System.Globalization;
using System.Windows.Data;

namespace DistributedSystems.LaboratoryWork.Number1.Utils.NestedMultiBinding;

/// <summary>
/// 
/// </summary>
public sealed class NestedMultiBindingsTree:
    NestedMultiBindingNode
{
    
    #region Constructors
    
    /// <summary>
    /// 
    /// </summary>
    public NestedMultiBindingsTree()
        : base(-1)
    {
        Nodes = new List<NestedMultiBindingNode>();
    }
    
    #endregion
    
    #region Properties
    
    /// <summary>
    /// 
    /// </summary>
    public IMultiValueConverter Converter
    {
        get;
        
        set;
    }
    
    /// <summary>
    /// 
    /// </summary>
    public object ConverterParameter
    {
        get;
        
        set;
    }
    
    /// <summary>
    /// 
    /// </summary>
    public CultureInfo ConverterCulture
    {
        get;
        
        set;
    }
    
    /// <summary>
    /// 
    /// </summary>
    public List<NestedMultiBindingNode> Nodes
    {
        get;
    }
    
    #endregion

}