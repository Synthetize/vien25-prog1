using UnityEngine;
using TMPro;
using System;
using System.Collections;

public class QuestDisplayer : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private TextMeshProUGUI textUI;
    [SerializeField] private float fadeDuration = 0.25f;

    public bool IsBusy { get; private set; }
    private bool hasShownFirstStep;

    private Action _onComplete;

    private void Awake()
    {
        canvasGroup.alpha = 0;
        textUI.text = "";
    }

    public void ShowStep(string step, Action onComplete)
    {
        if (IsBusy) return;

        IsBusy = true;
        _onComplete = onComplete;

        if (!hasShownFirstStep)
        {
            hasShownFirstStep = true;
            StartCoroutine(FirstStepAnimation(step));
        }
        else
        {
            StartCoroutine(ChangeStepAnimation(step));
        }
    }

    private IEnumerator FirstStepAnimation(string step)
    {
        yield return FadeValue(0, 1, fadeDuration, v => canvasGroup.alpha = v);
        canvasGroup.alpha = 1;
        textUI.text = step;
        IsBusy = false;
        _onComplete?.Invoke();
    }

    private IEnumerator ChangeStepAnimation(string step)
    {
        yield return FadeValue(1, 0, fadeDuration, v => textUI.alpha = v);
        textUI.alpha = 0;
        textUI.text = step;
        yield return FadeValue(0, 1, fadeDuration, v => textUI.alpha = v);
        textUI.alpha = 1;
        IsBusy = false;
        _onComplete?.Invoke();
    }

    private IEnumerator FadeValue(float from, float to, float duration, Action<float> setter)
    {
        float t = 0f;
        while (t < duration)
        {
            t += Time.deltaTime;
            setter(Mathf.Lerp(from, to, t / duration));
            yield return null;
        }
        setter(to);
    }
}