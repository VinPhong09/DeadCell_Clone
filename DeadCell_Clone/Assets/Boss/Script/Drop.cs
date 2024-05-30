using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    Collider2D col;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();

        Vector2 initialVelocity = new Vector2(1, -1);

        // Chu?n h�a vector v?n t?c
        initialVelocity.Normalize();

        // Thi?t l?p gi� tr? v?n t?c t�y ?
        float speed = 8f;
        initialVelocity *= speed;

        // Thi?t l?p v?n t?c ban �?u c?a v?t th?
        rb.velocity = initialVelocity;
        // Thi?t l?p gravity scale �? cho ph�p v?t r�i theo tr?ng l?c
        rb.gravityScale = 1;

        // Thi?t l?p collider cho v?t th?
        col.isTrigger = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // X? l? khi v?t r�i ch?m s�n
        if (other.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Object has touched the floor.");
        }
    }
}
