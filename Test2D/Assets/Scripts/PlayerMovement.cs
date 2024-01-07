using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public Color[] colors;
    int currColorIndex;
    public GameObject bluePS;
    public GameObject brownPS;
    public GameObject redPS;

    public float prevXPos;

    [SerializeField] TextMeshProUGUI playerColorText;

    public float speed;
    Rigidbody2D rb;
    bool isOnSurface;
    
    // Start is called before the first frame update
    void Start()
    {
        prevXPos = transform.position.x;
        colors = new Color[3] { Color.green, Color.red, Color.yellow };
        currColorIndex = 0;
        speed = 0.01f;
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            if (currColorIndex < 2)
            {
                currColorIndex++;
            }


        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            if (currColorIndex > 0)
            {
                currColorIndex--;
            }

        }

        gameObject.GetComponent<SpriteRenderer>().color = colors[currColorIndex];



        if (currColorIndex == 0)
        {
            playerColorText.text = "Green";
        }
        else if (currColorIndex == 1)
        {
            playerColorText.text = "Red";
        }
        else if (currColorIndex == 2)
        {
            playerColorText.text = "Yellow";
        } 


        transform.Translate(speed, 0, 0);
        if (transform.position.x - prevXPos >= 1)
        {
            speed += speed * 0.001f;
            PlayerManager.score += 1;
            prevXPos = transform.position.x;
        }
        
       
        
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (rb.gravityScale > -1)
            {
                rb.gravityScale = -1;
                
            }
            else if (rb.gravityScale < 1)
            {
                rb.gravityScale = 1;
            }
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            StartCoroutine(DecreaseSpeed());
            if (collision.gameObject.GetComponent<ObstacleManager>().colored)                             
            {
                Destroy(collision.gameObject);
                PlayerManager.lives--;
                GameObject tmp = Instantiate(redPS, collision.gameObject.transform.position, redPS.transform.rotation);
                Destroy(tmp, 2);
            }

            else if (collision.gameObject.GetComponent<SpriteRenderer>().color == gameObject.GetComponent<SpriteRenderer>().color)
            {

                Destroy(collision.gameObject);
                GameObject tmp = Instantiate(bluePS, collision.gameObject.transform.position, bluePS.transform.rotation);
                Destroy(tmp, 2);
            }

           
            else if(collision.gameObject.GetComponent<SpriteRenderer>().color != gameObject.GetComponent<SpriteRenderer>().color)
            {
                PlayerManager.lives--;
                Destroy(collision.gameObject);
                GameObject tmp = Instantiate(brownPS, collision.gameObject.transform.position, brownPS.transform.rotation);
                Destroy(tmp, 2);
            }

        }
       
    }

   
    void IncreaseSpeed(float xPos)
    {
        
    }
    IEnumerator DecreaseSpeed()
    {
        speed = speed / 2;
        yield return new WaitForSeconds(2);
        speed *= 2;
    }
}
