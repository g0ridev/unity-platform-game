using UnityEngine;

public class DeathZone : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player fell into death zone!");
            GameManager.TriggerLoss();
            Destroy(other.gameObject); //Now we trigger an event for the manager to handle
        }
    }
}