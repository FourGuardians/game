using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class TextHighlightButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Color Color;
    public Color HoverColor;

    private Button button;
    private TextMeshProUGUI text;

    public void Awake()
    {
        button = GetComponent<Button>();
        text = button.GetComponentInChildren<TextMeshProUGUI>();
    }

    public void OnPointerEnter(PointerEventData eventData) =>
        text.color = HoverColor;
 
    public void OnPointerExit(PointerEventData eventData) =>
        text.color = Color;
}