using System;
using UnityEngine;

public class BooksPuzzleManager : MonoBehaviour
{
    public GameObject[] books; // Array to hold references to book GameObjects
    private bool isPuzzleCompleted = false;
    public AudioClip correctSound;
    public AudioClip wrongSound;
    private int interactionIndex = 0; 
    void Start()
    {

    }

    void Update()
    {

    }
    
    public void BookInteraction(GameObject book)
    {
        if (isPuzzleCompleted) { Debug.Log("Puzzle already completed!"); return; }
        if (book.name == books[interactionIndex].name)
        {
            book.SetActive(false);
            
            if (interactionIndex >= books.Length - 1)
            {
                if (correctSound != null)
                {
                    AudioSource.PlayClipAtPoint(correctSound, transform.position);
                }
                isPuzzleCompleted = true;
            }
            else
            {
                interactionIndex++;
            }

        }
        else
        {
            interactionIndex = 0;
            Debug.Log("Wrong Book! Start Over.");
            AudioSource.PlayClipAtPoint(wrongSound, transform.position);
            foreach (GameObject bookObj in books)
            {
                bookObj.SetActive(true);
            }
        }
    }
}
