using DialogueTrees.Actions;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{
    public Button[] Buttons;

    public Option Clicked { get; private set; } = null;

    public void ShowOptions(List<Option> Options)
    {
        Clicked = null;

        for (int i = 0; i < Buttons.Length; i++)
        {
            if (i >= Options.Count)
            {
                Buttons[i].gameObject.SetActive(false);
                continue;
            }

            Buttons[i].gameObject.SetActive(true);

            var saved_index = i;

            Buttons[i].GetComponentInChildren<TextMeshProUGUI>().text = Options[i].Name;
            Buttons[i].onClick.AddListener(() => Clicked = Options[saved_index]);
        }
    }

    public void HideOptions()
    {
        Clicked = null;

        foreach (Button button in Buttons)
            button.gameObject.SetActive(false);
    }
}