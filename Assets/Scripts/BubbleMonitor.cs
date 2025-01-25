using UnityEngine;

public class BubbleMonitor : MonoBehaviour
{

    private GameObject target;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        target = GameManager.Instance.target;
    }

    // Update is called once per frame
    void Update()
    {
        bool isBubbleInsideCirlce = target.GetComponent<CircleCenterTarget>().IsObjectInsideCircle(transform.position);
        if (!isBubbleInsideCirlce)
        {
            Debug.Log("Bubble went outside bounds!");
            Destroy(transform.gameObject);
            GameManager.Instance.GameOver();
        }
    }
}
