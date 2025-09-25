using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueSystem : MonoBehaviour
{
    [SerializeField] private CanvasGroup dialogueCanvasGroup;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private float timeBetweenLettersTyping = 0.05f;
    [SerializeField] private float holdTime = 2f;
    [SerializeField] private float fadeDuration = 0.5f;

    private readonly Queue<string> dialogueQueue = new ();
    private bool isPlaying;

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

        yield return StartCoroutine(FadeCanvasGroup(dialogueCanvasGroup, 0f, 1f, fadeDuration));

        while (dialogueQueue.Count > 0)
        {
            var message = dialogueQueue.Dequeue();
            yield return StartCoroutine(PlayDialogue(message));
            yield return new WaitForSeconds(holdTime);
        }

        yield return StartCoroutine(FadeCanvasGroup(dialogueCanvasGroup, 1f, 0f, fadeDuration));

        dialogueText.text = "";
        isPlaying = false;
    }

    private IEnumerator PlayDialogue(string message)
    {
        dialogueText.text = "";
        foreach (var c in message)
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(timeBetweenLettersTyping);
        }
    }

    private IEnumerator FadeCanvasGroup(CanvasGroup canvasGroup, float start, float end, float duration)
    {
        var elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(start, end, elapsed / duration);
            yield return null;
        }

        canvasGroup.alpha = end;
    }
}
