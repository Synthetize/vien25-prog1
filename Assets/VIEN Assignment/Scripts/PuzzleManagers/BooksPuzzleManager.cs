using System;
using Seagull.Interior_01;
using UnityEngine;
using UnityEngine.Events;

public class BooksPuzzleManager : MonoBehaviour
{
    public GameObject[] books; // Array to hold references to book GameObjects
    private bool isPuzzleCompleted = false;
    public AudioClip correctPickup;
    public AudioClip puzzleCompleteSound;
    public AudioClip wrongPickup;
    private int interactionIndex = 0; 
    public UnityEvent onBookSolved;

    void Start()
    {

    }

    void Update()
    {

    }
    
    public void enableBooks()
    {
        foreach (GameObject book in books)
        {
            book.AddComponent<BoxCollider>();
        }
    }


    public void BookInteraction(GameObject book)
    {
        if (isPuzzleCompleted) { Debug.Log("Puzzle already completed!"); return; }
        if (book.name == books[interactionIndex].name)
        {
            book.SetActive(false);

            if (interactionIndex >= books.Length - 1)
            {
                isPuzzleCompleted = true;
                AudioSource.PlayClipAtPoint(correctPickup, Camera.main.transform.position);
                onBookSolved.Invoke();
            }
            else
            {
                AudioSource.PlayClipAtPoint(correctPickup, Camera.main.transform.position);
                interactionIndex++;
            }

        }
        else
        {
            interactionIndex = 0;
            AudioSource.PlayClipAtPoint(wrongPickup, Camera.main.transform.position);
            foreach (GameObject bookObj in books)
            {
                bookObj.SetActive(true);
            }
        }
    }
}
