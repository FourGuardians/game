using DialogueTrees.Instructions;
using GameAPI.Async.Generic;
using System.Collections.Generic;
using System.Threading.Tasks;

public class WaitForConfirmationTask : TextRenderingTask
{
    public WaitForConfirmationTask(IEnumerator<Instruction> instructions) : base(instructions)
    {
    }

    protected override async Task Run()
    {
        Target.OkayButton.gameObject.SetActive(true);

        bool next = false;
        Target.OkayButton.onClick.AddListener(() => next = true);

        await new Until(() => next);

        Target.OkayButton.gameObject.SetActive(false);
        QueueNext(false);
    }
}