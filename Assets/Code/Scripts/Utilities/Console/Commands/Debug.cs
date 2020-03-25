using Fg.Console;
using System.Collections.Generic;

public class DebugCommand : Command
{
    public override string Name { get; } = "debugmode";
    public override string Description { get; } = "Toggle debug mode"; 
    
    public override string[] Aliases { get; } = { "debug", "dbg" };

    public override void Run(List<string> args, Console console)
    {
        console.DebugMode = !console.DebugMode;
        Log.Info($"Debug mode has been {(console.DebugMode ? "enabled" : "disabled")}");
    }
}