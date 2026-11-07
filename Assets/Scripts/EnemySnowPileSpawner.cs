using UnityEngine;

public class EnemySnowPileSpawner : MonoBehaviour
{
    public float minimum = 2f;
    public float maximum = 5f;

    private float timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = Random.Range(minimum, maximum);
        foreach (Transform pile in transform) pile.gameObject.SetActive(false);

    }


    //Ne legyen SetActive, hanem random a pályán


    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer > 0f) return;
        timer = Random.Range(minimum, maximum);

        transform.GetChild(Random.Range(0, transform.childCount)).gameObject.SetActive(true);
            
    }
}
