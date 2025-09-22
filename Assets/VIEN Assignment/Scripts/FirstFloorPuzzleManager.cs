using UnityEngine;

public class FirstFloorPuzzleManager : MonoBehaviour
{
    private PlayerInventory _playerInventory;

    [SerializeField] private GameObject painting;
    [SerializeField] private GameObject uvProjector;
    [SerializeField] private GameObject piano;
    private PaintingBehaviour _paintingBehaviour;
    
    private void Awake()
    {
        _playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<PlayerInventory>();
        if (!_playerInventory)
        {
            Debug.LogError("PlayerInventory component not found");
        }
        if (!painting)
        {
            Debug.LogError("Painting GameObject not assigned in the inspector.");
        }
        if (!uvProjector)
        {
            Debug.LogError("UV Projector not assigned in the inspector.");
        }
        if (!piano)
        {
            Debug.LogError("Piano GameObject not assigned in the inspector.");
        }
        _paintingBehaviour = painting.GetComponent<PaintingBehaviour>();
    }

    private void OnEnable()
    {
        _playerInventory.OnItemAdded += OnItemAdded;
        _paintingBehaviour.OnDestroyed += EnablePianoSolution;
    }
    
    private void OnDisable()
    {
        _playerInventory.OnItemAdded -= OnItemAdded;
        _paintingBehaviour.OnDestroyed -= EnablePianoSolution;
    }

    private void EnablePianoSolution()
    {
        var pianoBehaviour = piano.GetComponent<PianoBehaviour>();
        if (!pianoBehaviour) return;
        Debug.Log("Piano solution enabled");
        pianoBehaviour.EnableSolution();
    }
    
    
    private void OnItemAdded(string item)
    {
        switch (item)
        {
            case "Scissors":
                var paintingBehaviour = painting.GetComponent<PaintingBehaviour>();
                paintingBehaviour.enabled = true;
                painting.AddComponent<ObjectHitReg>();
                break;
            case "Flashlight":
                Debug.Log("Enabling UV Projector");
                uvProjector.SetActive(true);
                break;
        }
    }
}
