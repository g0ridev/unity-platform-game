using UnityEngine;

public class Portal : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Something touched the portal!"); // Test message
        
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player touched portal - showing win screen!");
            GameManager.TriggerWin(); //Now we trigger an event for the manager to handle
    }
    }
}