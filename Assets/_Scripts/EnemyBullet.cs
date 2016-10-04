using UnityEngine;
using System.Collections;
/* 
 *Author: Sheikh Kalam 
 * Student ID: 300 489 863  
 * 
 * Date last modified: October 2nd, 2016 
 * Description: This script contorls shooting enemy bullet based on the 
 *               player ship location   
   
 */

public class EnemyBullet : MonoBehaviour
{
    float speed;
    Vector2 _direction;
    bool isReady;

    void Awake ()
    {
        speed = 5f;
        isReady = false;
    }

	// Use this for initialization
	void Start ()
    {
	
	}
    public void SetDirection (Vector2 direction)
    {
        _direction = direction.normalized;
        isReady = true;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (isReady)
        {
            Vector2 position = transform.position;

            position += _direction * speed * Time.deltaTime;

            transform.position = position;

            Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
            Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

            if ((transform.position.x < min.x) || (transform.position.x > max.x) || 
                (transform.position.y < min.y) || (transform.position.y > max.y))

            {
                 Destroy(gameObject);
            }
        }
	}
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "PlayerShipTag")
        {
            Destroy(gameObject);
        }
    }
}
