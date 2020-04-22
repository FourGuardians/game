using DialogueTrees.Dialogues;
using DialogueTrees.Instructions;
using GameAPI.Async.Generic;
using System.Collections.Generic;
using System.Threading.Tasks;

public class RenderTextTask : TextRenderingTask
{
    private readonly DialogueText text;

    public RenderTextTask(IEnumerator<Instruction> instructions, DialogueText text) : base(instructions) =>
        this.text = text;

    protected override async Task Run()
    {
        Target.Speaker.text = text.Participant;
        Target.Content.Content = text.Content;

        Target.Content.Start();
        Target.Content.Trigger();

        await new Until(() => Target.Content.Complete);

        QueueNext();
    }
}