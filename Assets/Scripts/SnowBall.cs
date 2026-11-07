using System.Collections;
using System.Data.Common;
using UnityEngine;

public class SnowBall : MonoBehaviour
{

    public float speed = 6f;
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
        if(fromPlayer && collision.CompareTag("Enemy"))
        {
            Debug.LogWarning("A játékos eltalálta a hóembert.");
            Destroy(gameObject);
        }
        else if(!fromPlayer && collision.CompareTag("Player"))
        {
            Debug.LogError("A hóember eltalálta a játékost.");
            Destroy(gameObject);
        }
    }
}
