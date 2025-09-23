using UnityEngine;

public class ThirdHintInteract : MonoBehaviour, IRaycastInteractable
{
    [SerializeField] private GameObject[] toEnable;

    public void OnRaycastHit()
    {
        foreach (var obj in toEnable)
        {
            obj.AddComponent<BoxCollider>();
        }
        EventBus.Publish(new NextQuestStepEvent("Third hint picked"));
        Destroy(gameObject);
    }
}
