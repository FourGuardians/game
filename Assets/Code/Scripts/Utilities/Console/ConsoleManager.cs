using Fg.Console;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ConsoleManager : MonoBehaviour
{
    public GameObject ConsoleUI;

    private TMP_InputField input;
    private Button submit;
    private TMP_Text output;
    private ScrollRect scroll;

    private Console console;

    public void Start()
    {
        console = GetComponent<Console>();

        output = ConsoleUI.GetComponentInChildren<TMP_Text>();
        input = ConsoleUI.GetComponentInChildren<TMP_InputField>();
        submit = ConsoleUI.GetComponentInChildren<Button>();
        scroll = ConsoleUI.GetComponentInChildren<ScrollRect>();

        ConsoleUI.GetComponentInChildren<Scrollbar>().interactable = false;

        submit.onClick.AddListener(() => OnSubmit());
    }

    public void OnActivate()
    {
        if (ConsoleUI.activeSelf)
        {
            OnSubmit();
            return;
        }

        ConsoleUI.SetActive(true);
        
        scroll.verticalNormalizedPosition = 0f;
        submit.Select();

        input.Select();
        input.ActivateInputField();
    }

    public void OnSubmit()
    {
        string result = console.Execute(input.text);
        output.text += result;

        input.text = "";

        StartCoroutine(fn());

        input.Select();
        input.ActivateInputField();

        IEnumerator fn() {
            yield return null;
            scroll.verticalNormalizedPosition = 0f;
        }
    }

    public void OnDeactivate()
    {
        input.text = "";
        ConsoleUI.SetActive(false);
    }
}