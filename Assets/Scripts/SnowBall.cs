using System.Collections;
using System.Data.Common;
using UnityEngine;

public class SnowBall : MonoBehaviour
{

    public float speed = 6f;
    public int damage = 2;
    private Vector2 direction;

    private bool fromPlayer;
    

    public void Launch(Vector2 dir, bool fromPlayer)
    {
        direction = dir.normalized;
        this.fromPlayer = fromPlayer; 
        //StartCoroutine(WaitForSnowball());
        //Destroy(gameObject);
        Destroy(gameObject, 3f);
    }

    /*
    IEnumerator WaitForSnowball()
    {
        yield return new WaitForSeconds(3f);
    }
    */

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3)direction * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(fromPlayer && collision.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(damage);
            Debug.LogWarning("A játékos eltalálta a hóembert.");
            Destroy(gameObject);
        }
        else if(!fromPlayer && collision.TryGetComponent(out Player player))
        {
            Debug.LogError("A hóember eltalálta a játékost.");
            player.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
