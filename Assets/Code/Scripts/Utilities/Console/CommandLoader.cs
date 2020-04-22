using Fg.Console;
using UnityEngine;

public class CommandLoader : MonoBehaviour
{
    public void Start()
    {
        Console console = GetComponent<Console>();

        console.RegisterCommand(new HelpCommand());
        console.RegisterCommand(new ClearCommand());
        console.RegisterCommand(new DebugCommand());
        console.RegisterCommand(new SummonPlayerCommand());
        console.RegisterCommand(new DestroyPlayerCommand());
        console.RegisterCommand(new TestXmlCommand());
    }
}