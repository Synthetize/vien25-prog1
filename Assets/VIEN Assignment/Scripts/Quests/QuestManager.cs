using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    private readonly Queue<string> _steps = new ();
    private QuestDisplayer _displayer;
    
    private void Awake()
    {
        _displayer = FindFirstObjectByType<QuestDisplayer>();
        if(!_displayer) Debug.LogError("No QuestDisplayer found in the scene.");
    }
    
    private void OnEnable()
    {
        EventBus.Subscribe<NextQuestStepEvent>(OnNextQuestStep);
    }
    
    private void OnDisable()
    {
        EventBus.Unsubscribe<NextQuestStepEvent>(OnNextQuestStep);
    }

    private void OnNextQuestStep(NextQuestStepEvent e)
    {
        _steps.Enqueue(e.Step);
        TryShowNext();
    }

    private void TryShowNext()
    {
        if (_displayer.IsBusy || _steps.Count == 0) return;
        string step = _steps.Dequeue();
        _displayer.ShowStep(step, TryShowNext);
    }
}
