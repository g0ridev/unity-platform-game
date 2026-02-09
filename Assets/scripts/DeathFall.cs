using UnityEngine;

public class DeathZone : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player fell into death zone!");
            GameManager.instance.ShowLoss();
            Destroy(other.gameObject); // Destroy player
        }
    }
}