using UnityEngine;

public class FirstHintPickup : MonoBehaviour, IRaycastInteractable
{
    private BooksPuzzleManager puzzleManager;
    public void Start()
    {
        puzzleManager = FindFirstObjectByType<BooksPuzzleManager>();
    }   
    public void OnRaycastHit()
    {
        puzzleManager.enableBooks();
        EventBus.Publish(new NextQuestStepEvent("Books hint"));
        Destroy(gameObject);
    }
}
