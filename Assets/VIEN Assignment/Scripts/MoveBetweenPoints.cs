using UnityEngine;

public class MoveBetweenPointsFunction : MonoBehaviour
{
    // Punti di partenza e di arrivo.
    public Transform startPoint;
    public Transform endPoint;

    // Velocità del movimento.
    public float speed = 1.0f;

    // Variabili private per il calcolo del movimento.
    private float journeyLength;
    private float startTime;
    private bool isMoving = false;

    /// <summary>
    /// Attiva il movimento dell'oggetto.
    /// </summary>
    public void StartMovement()
    {
        if (startPoint == null || endPoint == null)
        {
            Debug.LogError("Assegna i punti di partenza e di arrivo dall'Inspector!");
            return;
        }

        // Resetta le variabili e inizia il movimento.
        startTime = Time.time;
        journeyLength = Vector3.Distance(startPoint.position, endPoint.position);
        isMoving = true;
    }

    void Update()
    {
        // Se non è in movimento, non fare nulla.
        if (!isMoving)
        {
            return;
        }

        // Calcola la frazione del percorso completato.
        float distCovered = (Time.time - startTime) * speed;
        float fractionOfJourney = distCovered / journeyLength;

        // Sposta l'oggetto.
        transform.position = Vector3.Lerp(startPoint.position, endPoint.position, fractionOfJourney);

        // Se il movimento è completo, disattivalo.
        if (fractionOfJourney >= 1.0f)
        {
            isMoving = false;
        }
    }
}