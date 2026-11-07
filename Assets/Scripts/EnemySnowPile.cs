using UnityEngine;

public class EnemySnowPile : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float timer;

    private float visszaszamlas = 3f;

    private void OnEnable()
    {
        timer = visszaszamlas;
    }
    
    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() != null) gameObject.SetActive(false);
    }
}
