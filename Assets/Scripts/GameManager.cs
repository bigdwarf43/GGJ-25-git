using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public LineRenderer circleRenderer;
    public static GameManager Instance { get; private set; }
    public float bubblePushForce = 0.7f;
    public float maxBubbleVelocity = 3f;
    public GameObject target;

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void BubbleHit()
    {
        Debug.Log("Bubble Damaged");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
