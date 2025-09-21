using UnityEngine;
using UnityEngine.Events;

public class DoorInteraction : MonoBehaviour, IRaycastInteractable
{   
    public UnityEvent onDoorInteraction;
    public void OnRaycastHit()
    {
        onDoorInteraction.Invoke();
    }
}
