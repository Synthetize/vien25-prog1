using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueSystem : MonoBehaviour
{
    [SerializeField] private CanvasGroup dialogueCanvasGroup;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private float typingSpeed = 0.05f;
    [SerializeField] private float holdTime = 2f;
    [SerializeField] private float fadeDuration = 0.5f;

    private Queue<string> dialogueQueue = new Queue<string>();
    private bool isPlaying = false;

    private void Start()
    {
        dialogueCanvasGroup.alpha = 0;
        dialogueText.text = "";
    }

    private void OnEnable()
    {
        EventBus.Subscribe<DialogueEvent>(OnDialogueEvent);
    }

    private void OnDisable()
    {
        EventBus.Unsubscribe<DialogueEvent>(OnDialogueEvent);
    }

    private void OnDialogueEvent(DialogueEvent e)
    {
        dialogueQueue.Enqueue(e.Dialogue);

        if (!isPlaying)
        {
            StartCoroutine(ProcessQueue());
        }
    }

    private IEnumerator ProcessQueue()
    {
        isPlaying = true;

        // Fade in
        yield return StartCoroutine(FadeCanvasGroup(dialogueCanvasGroup, 0f, 1f, fadeDuration));

        while (dialogueQueue.Count > 0)
        {
            string message = dialogueQueue.Dequeue();
            yield return StartCoroutine(PlayDialogue(message));
            yield return new WaitForSeconds(holdTime);
        }

        // Fade out
        yield return StartCoroutine(FadeCanvasGroup(dialogueCanvasGroup, 1f, 0f, fadeDuration));

        dialogueText.text = "";
        isPlaying = false;
    }

    private IEnumerator PlayDialogue(string message)
    {
        dialogueText.text = "";
        Debug.Log("Writing dialogue: " + message);

        foreach (var c in message)
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }

        Debug.Log("Finished writing dialogue");
    }

    private IEnumerator FadeCanvasGroup(CanvasGroup canvasGroup, float start, float end, float duration)
    {
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(start, end, elapsed / duration);
            yield return null;
        }

        canvasGroup.alpha = end;
    }
}
