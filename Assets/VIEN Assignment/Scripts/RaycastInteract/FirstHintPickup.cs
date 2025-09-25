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
        gameObject.SetActive(false);
        puzzleManager.enableBooks();
        EventBus.Publish(new DialogueEvent("To unlock the next secret, you must follow the numbers."));
        EventBus.Publish(new DialogueEvent("The path to the truth is hidden in a simple combination: 4, 2, 3, 1. Start from the bottom shelf and work your way up.\n"));
        EventBus.Publish(new NextQuestStepEvent("Interact with the books from shelves 4, 2, 3, 1, starting from the bottom."));
    }
}
