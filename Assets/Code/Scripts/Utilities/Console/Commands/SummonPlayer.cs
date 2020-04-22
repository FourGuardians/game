using Fg.Console;
using System.Collections.Generic;
using UnityEngine;

public class SummonPlayerCommand : Command
{
    public override string Name { get; } = "summonplayer";
    public override bool Debug { get; } = true;
    public override string Description { get; } = "Summon a player"; 

    public override string[] Aliases { get; } = { "summon", "new", "create" };

    public override void Run(List<string> args, Console console)
    {
        PlayerType type = FromString(args[0]);
        if (type == PlayerType.None)
        {
            Log.Error("PlayerType must be a player type!");
            return;
        }

        if (Player.ActivePlayerType != PlayerType.None)
        {
            Log.Warn("A player has already been summoned!");
            return;
        }

        Player player = Player.Summon(type);

        if (args.Count > 2) {
            float x = float.Parse(args[1]);
            float y = float.Parse(args[2]);

            player.transform.position = new Vector3(x, y, player.transform.position.z);
        }

        Log.Info($"{type} has been sucessfully summoned");
    }

    private PlayerType FromString(string input)
    {
        if (input.ToLower() == "kierth")
            return PlayerType.Kierth;

        if (input.ToLower() == "konara")
            return PlayerType.Konara;

        if (input.ToLower() == "naratir")
            return PlayerType.Naratir;

        if (input.ToLower() == "natar")
            return PlayerType.Natar;

        return PlayerType.None;
    }
}