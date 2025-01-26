using System.Collections;
using UnityEngine;

public class BubbleMonitor : MonoBehaviour
{

    private GameObject target;

    [SerializeField]
    private ParticleSystem Explosion;

    private bool bubbleBursted = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        target = GameManager.Instance.target;
    }

    // Update is called once per frame
    void Update()
    {
        bool isBubbleInsideCircle = target.GetComponent<CircleCenterTarget>().IsObjectInsideCircle(transform.position);
        if (!isBubbleInsideCircle && !bubbleBursted)
        {
            Debug.Log("Bubble went outside bounds!");
            BurstBubble();
        }
    }

    public void BurstBubble()
    {
        bubbleBursted = true;
        Explosion.Play();
        transform.GetComponent<SpriteRenderer>().enabled = false;
        transform.GetComponent<Collider2D>().enabled = false;

        float timeToWait = Explosion.totalTime;
        GameManager.Instance.shake_screen();
        StartCoroutine(burstBubbleWithExplosion(timeToWait));
    }

    IEnumerator burstBubbleWithExplosion(float waitTime)
    {
        yield return new WaitForSeconds(waitTime + 5f);
        Destroy(transform.gameObject);
        GameManager.Instance.GameOver();
    }
}
