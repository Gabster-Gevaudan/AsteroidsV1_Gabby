using UnityEngine;
using UnityEngine.Events;

public class IntEventListener : MonoBehaviour
{
    [SerializeField] private IntChannel _intChannel;
    [SerializeField] private UnityEvent<int> _onIntEvent;

    private void OnEnable()
    {
        _intChannel.OnEventRaised += _onIntEvent.Invoke;
    }

    private void OnDisable()
    {
        _intChannel.OnEventRaised -= _onIntEvent.Invoke;
    }
}
