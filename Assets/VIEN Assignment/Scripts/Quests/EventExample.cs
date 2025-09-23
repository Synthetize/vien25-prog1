using UnityEngine;

public class EventExample : MonoBehaviour, IRaycastInteractable
{
    private int _counter;
    
    public void OnRaycastHit()
    {
        EventBus.Publish(new NextQuestStepEvent("Step " + _counter));
        _counter++;
    }
}