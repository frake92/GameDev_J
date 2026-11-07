using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    SpriteRenderer sr;

    Rigidbody2D rb;

    public float speed = 0f;

    public Vector2 direction;

    private Vector2 dashDirection;
    private float dashTimer = 0f;
    public float dashspeed = 8f;
    public float dashTime = 0.15f;

    public float dashCooldown = 1f;

    public float nextdashtime = 0f;

    public GameObject snowballPrefab;

    private bool hasSnowball = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();

        Vector2 mozgás = direction * speed;
        if(dashTimer > 0)
        {
            mozgás = dashDirection * dashspeed;
            dashTimer -= Time.deltaTime;
        }

        if(rb != null)
        {
            rb.linearVelocity =  mozgás;
        }
        else
        {
            transform.position += (Vector3)mozgás * Time.deltaTime;
        }
    }

    void PlayerMovement()
    {
        float h = 0f;
        float v = 0f;
        if (Keyboard.current.dKey.isPressed)
        {
            h = 1f;
            sr.flipX = false;
        }
        if (Keyboard.current.aKey.isPressed)
        {
            h = -1f;
            sr.flipX = true;
        }
        if (Keyboard.current.wKey.isPressed)
        {
            v += 1f;
        }
        else if (Keyboard.current.sKey.isPressed)
        {
            v -= 1f;
        }
        if (h != 0f || v != 0f)
        {
            speed = 2f;
            direction = new Vector2(h, v).normalized;
        }
        else
        {
            speed = 0f;
            direction = Vector2.zero;
        }

        if(Keyboard.current.spaceKey.wasPressedThisFrame && direction != Vector2.zero && nextdashtime <= Time.time)
        {
            dashDirection = direction;
            dashTimer = dashTime;
            nextdashtime = Time.time + dashCooldown;
        }

        if (Mouse.current.leftButton.wasPressedThisFrame && hasSnowball)
        {
            Vector2 mouse = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            Vector2 mouseDirection = mouse - (Vector2)transform.position;

            GameObject snowBall = Instantiate(snowballPrefab, transform.position, Quaternion.identity);
            snowBall.GetComponent<SnowBall>().Launch(mouseDirection, true);
            hasSnowball = false;
        }
        //házi: ugrást a platformerhez

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (hasSnowball || !collision.CompareTag("snowpile")) return;

        hasSnowball = true;
        Destroy(collision.gameObject);

        /*
        if (collision.CompareTag("Hóember"))
        {
            Debug.Log("Összetört a hóember");
            Destroy(collision.gameObject);
        }
        else if(collision.CompareTag("Fa"))
        {
            Debug.LogWarning("Nem hóemberrel ütköztél");
            collision.gameObject.GetComponent<SpriteRenderer>().flipY = true;
        }
        else if (collision.CompareTag("Level2"))
        {
            SceneManager.LoadScene("Level2");
        }
        */
    }
}
