namespace Common;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class UtilityAttribute : Attribute
{
    public UtilityAttribute(string name) : this(name, true) { }

    public UtilityAttribute(string name, bool isEnabled)
    {
        Name = name;
        IsEnabled = isEnabled;
    }

    public string Name { get; set; }
    public bool IsEnabled { get; set; }
    public int MyProperty { get; set; }
}
