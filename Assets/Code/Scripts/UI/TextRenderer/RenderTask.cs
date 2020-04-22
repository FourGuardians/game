using DialogueTrees.Instructions;
using System.Collections.Generic;
using System.Threading.Tasks;

public class RenderTask : TextRenderingTask
{
    public RenderTask(IEnumerator<Instruction> instructions) : base(instructions)
    {}

    protected override Task Run()
    {
        Target.Shown = true;

        QueueNext();
        return Task.CompletedTask;
    }
}