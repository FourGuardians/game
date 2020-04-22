using DialogueTrees.Instructions;
using GameAPI.Tasks;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(OptionsManager))]
public class TextRenderer : TaskedBehaviour
{
    public GameObject Container;
    public TMP_Text Speaker;
    public Typewriter Content;
    public Button OkayButton;
    public GameObject Options;

    public bool Complete => CurrentTask == null;
    public string ReturnValue => Complete ? CurrentReturnValue : null;

    internal string CurrentReturnValue;

    public bool Shown
    {
        get
        {
            return Container.activeSelf;
        }

        set
        {
            Container.SetActive(value);
        }
    }

    public new void Update()
    {
        base.Update();
    }

    public void Render(IEnumerable<Instruction> instructions) =>
        Assign(new RenderTask(instructions.GetEnumerator()));
}