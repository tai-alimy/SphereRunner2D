using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    Color[] colors;
    public bool colored;
    int currColorInd;

    int frames;

   
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        frames = 0;
        currColorInd = 0;
        colored = false;
        colors = new Color[3] { Color.green, Color.red, Color.yellow };

        int i = Random.Range(0, colors.Length + 1);
        if (i < colors.Length)
        {
            gameObject.GetComponent<SpriteRenderer>().color = colors[i];
        }

        else
        {
            colored = true;
        }


        UpOrDown();

       
    }

    // Update is called once per frame
    void Update()
    {
        frames += 1;
        if (frames % 10 == 0 && colored)
        {
            SwitchColor();
        }

        if (player.transform.position.x - transform.position.x > 2)
        {
            Destroy(gameObject);
        }
    }

    void UpOrDown()
    {
        int r = Random.Range(0, 2);

        if (r != 1)
        {
            transform.position = new Vector2(transform.position.x, -1 * transform.position.y);
            transform.localScale = new Vector2(transform.localScale.x, -1 * transform.localScale.y);
        }

        
    }

    void SwitchColor()
    {
        if (currColorInd < colors.Length - 1)
        {
            currColorInd++;
            gameObject.GetComponent<SpriteRenderer>().color = colors[currColorInd];
        }
        else
        {
            currColorInd = 0;
            gameObject.GetComponent<SpriteRenderer>().color = colors[currColorInd];
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
    }
}
