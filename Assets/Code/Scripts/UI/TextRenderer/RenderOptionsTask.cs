using DialogueTrees.Instructions;
using GameAPI.Async.Generic;
using System.Collections.Generic;
using System.Threading.Tasks;

public class RenderOptionsTask : TextRenderingTask
{
    private readonly OptionsInstruction instruction;

    public RenderOptionsTask(IEnumerator<Instruction> instructions, OptionsInstruction instruction) : base(instructions) =>
        this.instruction = instruction;

    protected override async Task Run() 
    {
        OptionsManager options = Target.GetComponent<OptionsManager>();

        options.ShowOptions(instruction.Options.Options);

        await new Until(() => options.Clicked != null);
        instruction.Result = options.Clicked;

        options.HideOptions();
        QueueNext();
    }
}