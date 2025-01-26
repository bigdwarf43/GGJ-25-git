using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector2 dir;
    public float speed;
    private bool hasEnteredScreen = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get the current position
        Vector3 currentPosition = transform.position;

        // Update the x and y components
        currentPosition.x += dir.x * speed * Time.deltaTime;
        currentPosition.y += dir.y * speed * Time.deltaTime;

        // Assign the new position back
        transform.position = currentPosition;

        if (IsOutOfScreen())
        {
            // Destroy the object only if it has entered the screen before
            if (hasEnteredScreen)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            // Mark the object as having entered the screen
            hasEnteredScreen = true;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Bubble"))
        {
            Destroy(gameObject);

            collision.transform.GetComponent<BubbleMonitor>().BurstBubble();
         
            
        }
    }

    private bool IsOutOfScreen()
    {
        // Get the screen bounds from the main camera
        Vector3 screenPosition = Camera.main.WorldToViewportPoint(transform.position);

        // Check if the object is out of bounds
        return screenPosition.x < 0 || screenPosition.x > 1 || screenPosition.y < 0 || screenPosition.y > 1;
    }
}
