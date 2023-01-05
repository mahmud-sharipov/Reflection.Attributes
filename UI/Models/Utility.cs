using Common;
using System;
using System.Reflection;

namespace UI.Models;

internal class Utility
{
    readonly Type _utilityClassType;
    public readonly IUtility _utility;
    public string Name { get; set; }
    public bool IsEnabled { get; set; }

    public Utility(Type type)
    {
        _utilityClassType = type;
        var attribute = type.GetCustomAttribute<UtilityAttribute>();
        Name = attribute.Name;
        IsEnabled = attribute.IsEnabled;

        _utility = Activator.CreateInstance(type) as IUtility;
    }

    public string Execute()
    {
        try
        {
            if (_utility is null)
                return "Can't detect 'Run' method of the utility";

            return _utility.Run();
        }
        catch (Exception ex)
        {
            return ex.Message.ToString();
        }
    }
}
