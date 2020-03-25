using Fg.Console;
using System.Collections.Generic;
using TMPro;

public class ClearCommand : Command
{
    public override string Name { get; } = "clear";
    public override string Description { get; } = "Clear the console"; 
    
    public override string[] Aliases { get; } = { "empty" };

    public override void Run(List<string> args, Console console)
    {
        console
            .GetComponent<ConsoleManager>()
            .ConsoleUI
            .GetComponentInChildren<TMP_Text>()
            .text = "";

        Log.Info("Console has been sucessfully cleared.");
    }
}