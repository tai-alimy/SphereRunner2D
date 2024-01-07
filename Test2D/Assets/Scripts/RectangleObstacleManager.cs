using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectangleObstacleManager : MonoBehaviour
{
    Color[] colors;
    // Start is called before the first frame update
    void Start()
    {
        colors = new Color[4] { Color.green, Color.red, Color.yellow, Color.magenta };

        int i = Random.Range(0, colors.Length);

        gameObject.GetComponent<SpriteRenderer>().color = colors[i];

        UpOrDown();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpOrDown()
    {
        int r = Random.Range(0, 2);

        if (r == 0)//down
        {
            transform.position = new Vector2(transform.position.x, -3);
        }

        else
        {
            transform.position = new Vector2(transform.position.x, 3);
            
        }
        print(r);
    }
}
