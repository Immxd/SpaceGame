using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rb;
    private int score;
    private int Life = 3;

    [SerializeField] private float speed = 4.0f;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text LifeText;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        LifeText.text = "Life : " + Life.ToString();

    }

    // Update is called once per frame
    void Update()
    {

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        rb.velocity = new Vector2(horizontal, vertical)*speed;

        //print(vertical)
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Coin")
        {
            score = score + 5;
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Ukkabath")
        {
            score = score - 5;
            Life = Life - 1;
            Destroy(collision.gameObject);
            LifeText.text = "Life : " + Life.ToString();
            if (Life == 0)
            {
                LifeText.text = "GameOver";
            }

        }

        //print(score);
        scoreText.text = "Score : "+score.ToString();

    }
}
