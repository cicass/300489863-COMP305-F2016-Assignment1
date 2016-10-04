using UnityEngine;
using System.Collections;
/* 
 *Author: Sheikh Kalam 
 * Student ID: 300 489 863  
 * 
 * Date last modified: October 2nd, 2016 
 * Description: This script control the player bullet behavior  
 *  
 */

public class PlayerBuller : MonoBehaviour
{
    float speed;
	// Use this for initialization
	void Start ()
    {
        speed = 8f;
	}
	
	// Update is called once per frame
	void Update ()
    {

        Vector2 position = transform.position;

        position = new Vector2(position.x, position.y + speed * Time.deltaTime);

        transform.position = position;

        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        if (transform.position.y > max.y)
        {
            Destroy(gameObject);
        }
	}
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "EnemyShipTag") 
        {
            Destroy(gameObject);
        }
    }
}
