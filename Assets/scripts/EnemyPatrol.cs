using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed = 2f;
    public float distance = 3f; // How far to move
    public bool moveHorizontal = true; // true = left/right, false = up/down
    
    private Vector3 startPos;
    private bool movingForward = true;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float movement;
        
        if (moveHorizontal)
        {
            // Move left/right
            movement = transform.position.x - startPos.x;
        }
        else
        {
            // Move up/down
            movement = transform.position.y - startPos.y;
        }

        // Check if reached the end, then reverse
        if (movement >= distance)
            movingForward = false;
        else if (movement <= -distance)
            movingForward = true;

        // Move the enemy
        float direction = movingForward ? 1 : -1;
        
        if (moveHorizontal)
            transform.position += new Vector3(speed * direction * Time.deltaTime, 0, 0);
        else
            transform.position += new Vector3(0, speed * direction * Time.deltaTime, 0);
    }
}