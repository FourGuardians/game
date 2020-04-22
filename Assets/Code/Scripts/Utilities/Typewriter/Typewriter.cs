using GameAPI.Tasks;
using TMPro;

public class Typewriter : TaskedBehaviour
{
    public bool GetContentFromText = true;
    public string Content;
    public float Speed = 2f;

    private TextMeshProUGUI text;

    public bool Complete => text.text == Content;

    public void Start()
    {
        text = gameObject.GetComponent<TextMeshProUGUI>();

        if (GetContentFromText)
            Content = text.text;

        text.text = "";
    }

    public void Trigger()
    {
        foreach (char c in Content)
            Queue(new TypeTask(text, c.ToString(), 1f / Speed));
    }

    public void Skip()
    {
        Stop();
        text.text = Content;
    }

    public void Stop() =>
        ClearTasks();

    public void Reset()
    {
        Stop();
        text.text = "";
    }
}