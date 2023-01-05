using Common;

namespace HeloWorld.Utility;

[Utility("Hello world")]
internal class HelloWorldUtility : IUtility
{
    public string Run()
    {
        return "Hello world";
    }
}
