using UnityEngine;

public class SnowBallPickUp : MonoBehaviour
{
    public GameObject prefab;
    private Vector2 minimumPosition = new Vector2(-8f, -4f);
    private Vector2 maxmimumPosition = new Vector2(8f, 4f);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < 5; i++) Spawn();
    }
    
    public void Spawn()
    {
        Vector2 position = new Vector2(Random.Range(minimumPosition.x, maxmimumPosition.x), Random.Range(minimumPosition.y, maxmimumPosition.y));
        Instantiate(prefab, position, Quaternion.identity);
    }
}
