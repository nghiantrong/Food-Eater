using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    public float moveSpeed;
    public float rotateAmount;
    float rotateValue;
    int score;
    public GameObject winText;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (mousePos.x < 0)
            {
                rotateValue = rotateAmount;
            }
            else
            {
                rotateValue = -rotateAmount;
            }
            transform.Rotate(0, 0, rotateValue);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = transform.up * moveSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Food")
        {
            Destroy(collision.gameObject);
            score++;

            if (score >= 6)
            {
                Debug.Log("Complete");
                winText.SetActive(true);
            }
        }
        else if (collision.gameObject.tag == "Danger")
        {
            SceneManager.LoadScene("Game");
        }
    }
}
