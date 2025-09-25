using UnityEngine;

public class RainEnabler1 : MonoBehaviour
{
    private bool isPlayerRainActive = false; // Flag to track if the player's rain effect is active
    public GameObject playerRainEffect; // Reference to the rain effect GameObject
    public GameObject[] rainEffectObjects; // Array of other rain effect GameObjects

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Collision with Player detected");
            if (!isPlayerRainActive)
            {
                playerRainEffect.SetActive(true);
                foreach (GameObject rainEffect in rainEffectObjects)
                {
                    rainEffect.SetActive(false);
                }
                isPlayerRainActive = true;
            }
            else
            {
                playerRainEffect.SetActive(false);
                foreach (GameObject rainEffect in rainEffectObjects)
                {
                    rainEffect.SetActive(true);
                }
                isPlayerRainActive = false;
            }
        }
    }
}
