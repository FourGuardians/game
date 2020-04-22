using DialogueTrees;
using DialogueTrees.Builder;
using Fg.Console;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class TestXmlCommand : Command
{
    public override string Name { get; } = "xmlt";
    public override string Description { get; } = "quck"; 
    
    public override string[] Aliases { get; } = {};

    public TextAsset asset;

    public TestXmlCommand()
    {
        Addressables.LoadAssetAsync<TextAsset>("@Dialogue/Tests/dialogue-options.xml").Completed +=
            obj => asset = obj.Result; 
    }

    public override void Run(List<string> args, Console console)
    {
        DialogueTree tree = DialogueTreeBuilder.FromText(asset);

        Scene.System
            .GetComponentInChildren<TextRenderer>()
            .Render(tree.Start());
    }
}