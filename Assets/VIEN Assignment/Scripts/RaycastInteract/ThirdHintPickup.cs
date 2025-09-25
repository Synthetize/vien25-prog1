using UnityEngine;

public class ThirdHintInteract : MonoBehaviour, IRaycastInteractable
{
    [SerializeField] private GameObject[] toEnable;

    public void OnRaycastHit()
    {
        foreach (var obj in toEnable)
        {
            if (obj.GetComponent<BoxCollider>())
            {
                obj.GetComponent<BoxCollider>().enabled = true;
            }
            else
            {
                obj.AddComponent<BoxCollider>();
            }
        }
        EventBus.Publish(new DialogueEvent("Not all light is meant to guide the way. Some rays unveil what the eye cannot see."));
        EventBus.Publish(new DialogueEvent("And when the surface resists, only a sharp edge can set the secret free."));
        EventBus.Publish(new NextQuestStepEvent("Explore the kitchen and find what will help you reveal the hidden mark upon the painting frame."));
        Destroy(gameObject);
    }
}
