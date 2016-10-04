using UnityEngine;
using System.Collections;
/* 
 *Author: Sheikh Kalam 
 * Student ID: 300 489 863  
 * 
 * Date last modified: October 2nd, 2016 
 * Description: This script is generating different color of random stars for 
 *              the backgroud game play  
   
 */

public class StarGenerator : MonoBehaviour
{

    public GameObject StarGO;
    public int MaxStars;

    Color[] starColors = {
        new Color (0.5f, 0.5f, 1f),
        new Color (0, 1f, 1f),
        new Color (1f, 1f, 0),
        new Color (1f, 0, 0),
        };
	// Use this for initialization
	void Start ()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        for (int i = 0; i < MaxStars; i++)
        {
            GameObject star = (GameObject)Instantiate(StarGO);

            star.GetComponent<SpriteRenderer>().color = starColors[i % starColors.Length];

            star.transform.position = new Vector2(Random.Range(min.x, max.x), Random.Range(min.y, max.y));

            star.GetComponent<Star>().speed = -(1f * Random.value + 0.5f);

            star.transform.parent = transform;

        }

	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
