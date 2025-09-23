using UnityEngine;

public class UiTextEvent : MonoBehaviour
{
    void Start()
    {
        Invoke(nameof(ShowWelcomeMessage), 2f);
    }
    
    private void ShowWelcomeMessage()
    {
        EventBus.Publish(new DialogueEvent("Welcome to the game!"));
        EventBus.Publish(new DialogueEvent("First sentence."));
        EventBus.Publish(new DialogueEvent("Second sentence."));
        EventBus.Publish(new DialogueEvent("Third sentence."));
        Invoke(nameof(SecondMessage), 20f);
    }
    
    private void SecondMessage()
    {
        EventBus.Publish(new DialogueEvent("This is the second message."));
        EventBus.Publish(new DialogueEvent("Again, first sentence."));
        EventBus.Publish(new DialogueEvent("Again, second sentence."));
        EventBus.Publish(new DialogueEvent("Again, third sentence."));
    }
}
