using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleEngine : MonoBehaviour
{
    public GameObject player;
    public GameObject triangleObstacle;
    public GameObject rectangleObstacle;
    float randomTime;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");

        StartCoroutine(InstantiateObstacle());
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    IEnumerator InstantiateObstacle()
    {
        while (PlayerManager.lives > 0)
        {
            float seconds = Random.Range(0.5f, 2.6f);
            int shape = Random.Range(0, 2);

            yield return new WaitForSeconds(seconds);

            if (shape == 0)
            {
                Instantiate(triangleObstacle, new Vector2(player.transform.position.x + 20, triangleObstacle.transform.position.y
                                                                                ), triangleObstacle.transform.rotation);
            }
            else
            {
                Instantiate(rectangleObstacle, new Vector2(player.transform.position.x + 20, rectangleObstacle.transform.position.y
                                                                               ), rectangleObstacle.transform.rotation);
            }
        }
            
        
       
    }
}
