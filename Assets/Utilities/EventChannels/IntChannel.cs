using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "IntChannel", menuName = "Scriptable Objects/IntChannel")]
public class IntChannel : ScriptableObject
{
    public UnityAction<int> OnEventRaised;
    public void RaisedEvent(int value)
    {
        OnEventRaised?.Invoke(value);
    }
}
