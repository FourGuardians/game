using Fg.Console;
using System.Collections.Generic;

public class DestroyPlayerCommand : Command
{
    public override string Name { get; } = "destroyplayer";
    public override bool Debug { get; } = true;
    public override string Description { get; } = "Destroy a player"; 
    
    public override string[] Aliases { get; } = { "destroy", "kill", "die", "remove" };

    public override void Run(List<string> args, Console console)
    {
        if (Player.ActivePlayerType == PlayerType.None) {
            Log.Error("No player currently exists!");
            return;
        }

        PlayerType type = Player.ActivePlayerType;
        Player.ActivePlayer.Destroy();
        
        Log.Info($"{type} has been sucessfully destroyed");
    }
}