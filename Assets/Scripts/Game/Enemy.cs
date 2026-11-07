using System.Runtime.CompilerServices;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 1.5f;
    public GameObject snowBallPrefab;
    private Player player;

    public float throwInterval = 2f;
    private float throwTimer;

    private int health = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        throwTimer = throwInterval;
        player = FindFirstObjectByType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMovement();
    }

    void EnemyMovement()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);
        throwTimer -= Time.deltaTime;

        if(distance < 10 && distance > 3)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
        if(throwTimer <= 0)
        {
            Vector2 dir = player.transform.position - transform.position;
            GameObject ball = Instantiate(snowBallPrefab, transform.position, Quaternion.identity);
            ball.GetComponent<SnowBall>().Launch(dir, false);
            throwTimer = throwInterval;
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Debug.Log("Az enemy legyőzve");
            Destroy(gameObject);
        }
    }
}
