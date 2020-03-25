using UnityEngine;

[ExecuteInEditMode]
class UIScaling : MonoBehaviour
{
    [Header("Preferences")]
    public float Scale = 1f;
    public float Multiplier = 1f;

    [Header("Scaling")]
    public bool EnableScaling = true;

    [Header("Positioning")]
    public bool EnablePositioning = true;
    public bool Invert = false;
    public float PositionX = 0f;
    public float PositionY = 0f;

    private float ScaleAmount => Screen.height * 0.0001f * Scale * Multiplier;

    public void Awake()
    {
        UpdateScale();
        UpdatePositioning();
    }

    public void Update()
    {
#if UNITY_EDITOR
        UpdateScale();
        UpdatePositioning();
#endif
    }

    private void UpdateScale()
    {
        if (!EnableScaling)
            return;

        gameObject.transform.localScale = new Vector3(ScaleAmount, ScaleAmount, 1f);
    }

    private void UpdatePositioning()
    {
        if (!EnablePositioning)
            return;

        gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3
        (
            (Invert ? -1 : 1) * PositionX * ScaleAmount,
            (Invert ? -1 : 1) * PositionY * ScaleAmount,
            1f
        );
    }
}