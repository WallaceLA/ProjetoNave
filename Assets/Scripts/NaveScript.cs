using UnityEngine;
using System.Collections;

public class NaveScript : MonoBehaviour
{
    public float speed = 1.0f;
    private Rigidbody rb;
    public float acceleration = (float)0.1;
    public Vector2 screenBounds;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        rb.velocity = new Vector2(-speed, 0);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }

    
    private void OnEnable()
    {
        Invoke("Destruir", 2f);
    }


    private void OnDisable()
    {
        CancelInvoke();
    }
    
    private void Destruir()
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {
        if (transform.position.x < -screenBounds.x)
        {
            Destruir();
        }
        speed += acceleration * Time.deltaTime;
        rb.velocity = new Vector2(-speed, 0);
    }
}
