using DialogueTrees.Instructions;
using GameAPI.Tasks;
using System.Collections.Generic;

public abstract class TextRenderingTask : GameTask<TextRenderer>
{
    protected IEnumerator<Instruction> instructions;

    public TextRenderingTask(IEnumerator<Instruction> instructions) =>
        this.instructions = instructions;

    public void QueueNext(bool next = true)
    {
        if (next && !instructions.MoveNext())
        {
            Target.Shown = false;
            return;
        }

        Instruction instruction = instructions.Current;

        if (this is RenderTextTask && !(instruction is OptionsInstruction))
        {
            Target.Queue(new WaitForConfirmationTask(instructions));
            return;
        }

        if (instruction is TextInstruction textInstruction)
            Target.Queue(new RenderTextTask(instructions, textInstruction.Text));

        if (instruction is ReturnInstruction returnInstruction)
        {
            Target.Container.SetActive(false);
            Target.CurrentReturnValue = returnInstruction.Value;
        }

        if (instruction is OptionsInstruction optionsInstruction)
            Target.Queue(new RenderOptionsTask(instructions, optionsInstruction));
    }
}