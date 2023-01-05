using Common;

namespace Misc.Utility;

[Utility("Open notepad1354354654", true)]
public class OpenNotePadUtility : IUtility
{
    public string Run()
    {
        System.Diagnostics.Process.Start("Notepad.exe");
        return "Notepad is opened!";
    }
}

[Utility("Open Calculator")]
public class OpenCalculatorUtility : IUtility
{
    public string Run()
    {
        System.Diagnostics.Process.Start("Calc");
        return "Calculator is opened!";
    }
}