using UnityEngine;
using UnityEngine.UI;

public class FillBar : MonoBehaviour 
{
    [Header("Preferences")]
    public float Step = 0.0025f;
    public float Target = 1f;

    [Header("Input Range")]
    public float MinValue = 0f;
    public float MaxValue = 1f;

    [Header("Output Range")]
    [Range(0f, 1f)]
    public float MinResult = 0f;

    [Range(0f, 1f)]
    public float MaxResult = 1f;

    private float TargetValue => Target.Map(MinValue, MaxValue, MinResult, MaxResult);
    private Material material;

    public void Start()
    {
        material = gameObject.GetComponent<Image>().material;
    }

    public void Update()
    {
        if (TargetValue < MinResult || TargetValue > MaxResult)
            return;

        float amount = material.GetFloat("_Amount");

        if (amount < TargetValue)
            if (amount + Step >= TargetValue)
                material.SetFloat("_Amount", TargetValue);
            else
                material.SetFloat("_Amount", amount + Step);

        if (amount > TargetValue)
            if (amount - Step <= TargetValue)
                material.SetFloat("_Amount", TargetValue);
            else
                material.SetFloat("_Amount", amount - Step);
    }
}