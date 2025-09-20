using UnityEngine;

public class BookInteraction : MonoBehaviour, IRaycastInteractable
{

    private BooksPuzzleManager puzzleManager;
    public void Start()
    {
        puzzleManager = FindFirstObjectByType<BooksPuzzleManager>();
    }
    public void OnRaycastHit()
    {
        puzzleManager.BookInteraction(gameObject);
    }
}
