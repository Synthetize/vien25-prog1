using UnityEngine;

public class SecondHintPickup : MonoBehaviour, IRaycastInteractable
{

    public GameObject paintFrame;
    public void OnRaycastHit()
    {
        Destroy(gameObject);
        paintFrame.AddComponent<ObjectHitReg>();
        paintFrame.AddComponent<DestroyPainting>();
        EventBus.Publish(new DialogueEvent("To reveal what is hidden, you must first tell time. The clock on the bathroom holds your next clue."));
        EventBus.Publish(new DialogueEvent("Use the numbers it shows, then return here. You'll find what you're looking for behind the art."));
        EventBus.Publish(new NextQuestStepEvent("Use the numbers on the bathroom clock to unlock the safe behind the painting."));
    }

}
