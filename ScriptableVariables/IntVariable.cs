using UnityEngine;

[CreateAssetMenu(fileName = "IntVariable", menuName = "Variables/IntVariable")]
public class IntVariable : FVariable<int>
{
    [SerializeField] private int minValue = 0;
    [SerializeField] private int maxValue = int.MaxValue;

    public new int Value
    {
        get => base.Value;
        set => base.Value = Mathf.Clamp(value, minValue, maxValue);
    }
}