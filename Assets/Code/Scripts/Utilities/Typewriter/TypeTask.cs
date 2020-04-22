using GameAPI.Async.Generic;
using GameAPI.Tasks;
using System.Threading.Tasks;
using TMPro;

public class TypeTask : GameTask<Typewriter>
{
    private readonly TextMeshProUGUI component;
    private readonly string content;
    private readonly float delay;

    public TypeTask(TextMeshProUGUI component, string content, float delay)
    {
        this.component = component;
        this.content = content;
        this.delay = delay;
    }

    protected override async Task Run()
    {
        component.text += content;
        await new Delay(delay);
    }
}