using UnityEngine;

[CreateAssetMenu(fileName = "FloatVariable", menuName = "Variables/FloatVariable")]
public class FloatVariable : FVariable<float>
{
    [SerializeField] private float minValue = 0;
    [SerializeField] private float maxValue = float.MaxValue;

    public new float Value
    {
        get => base.Value;
        set
        {
            base.Value = Mathf.Clamp(value, minValue, maxValue);
        }
    }
}