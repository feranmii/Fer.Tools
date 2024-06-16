using UnityEngine;
using UnityEngine.Events;

public abstract class FVariable<T> : ScriptableObject
{
	[SerializeField] private T value;
	public UnityEvent OnValueChanged;

	private void RaiseEvent()
	{
		OnValueChanged?.Invoke();
	}

	public T Value
	{
		get => value;
		set
		{
			this.value = value;
			OnValueChanged?.Invoke();
		}
	}
}