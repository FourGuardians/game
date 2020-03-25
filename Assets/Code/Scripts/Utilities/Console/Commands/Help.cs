using Fg.Console;
using System.Collections.Generic;

public class HelpCommand : Command
{
    public override string Name { get; } = "help";
    public override string Description { get; } = "Help information"; 

    public override string[] Aliases { get; } = { "?" };

    public override void Run(List<string> args, Console console)
    {
        Log.Info("Listing all available commands.\n");

        foreach (Command command in console.Commands)
        {
            if (command.Debug && !console.DebugMode)
                continue;

            Log.Line($"Command /{command.Name}");
            Log.Line($"    Description: {command.Name}");
            Log.Line($"    Aliases: {System.String.Join(", ", command.Aliases)}");
        }
    }
}