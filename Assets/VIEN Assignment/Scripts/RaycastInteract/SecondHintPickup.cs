using UnityEngine;

public class SecondHintPickup : MonoBehaviour, IRaycastInteractable
{

    public GameObject paintFrame;
    public void OnRaycastHit()
    {
        Destroy(gameObject);
        paintFrame.AddComponent<ObjectHitReg>();
        paintFrame.AddComponent<DestroyPainting>();
        EventBus.Publish(new NextQuestStepEvent("Le palle le palle le palle le palle le palle le palle le palle"));
    }

}
