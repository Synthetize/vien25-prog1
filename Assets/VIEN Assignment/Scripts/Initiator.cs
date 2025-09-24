using System.Collections;
using UnityEngine;

public class Initiator : MonoBehaviour
{
    
    [SerializeField] private CanvasGroup blackScreen;
    [SerializeField] private float fadeDuration = 2f;
    
    private void Start()
    {
        StartCoroutine(FadeBlackOut());
    }

    private IEnumerator FadeBlackOut()
    {
        var timer = 0f;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            blackScreen.alpha = 1 - (timer / fadeDuration);
            yield return null;
        }
        blackScreen.alpha = 0;
        PublishDialogues();
    }

    private static void PublishDialogues()
    {
        EventBus.Publish(new DialogueEvent("Looks like yesterday's night I drank a bit too much..."));
        EventBus.Publish(new DialogueEvent("Something feels off..."));
        EventBus.Publish(new DialogueEvent("What is that note on the wall? I should check it out."));
    }
}
