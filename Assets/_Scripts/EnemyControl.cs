using UnityEngine;
using System.Collections;
/* 
 *Author: Sheikh Kalam 
 * Student ID: 300 489 863  
 * 
 * Date last modified: October 2nd, 2016 
 * Description: This script controls the enemy and updates score by 100 
 *              if enemies have been destroyed. 
 */

public class EnemyControl : MonoBehaviour
{
    GameObject scoreUITextGO;
    public GameObject ExplosionGO;
    float speed;

	// Use this for initialization
	void Start ()
    {
        speed = 2f;

        scoreUITextGO = GameObject.FindGameObjectWithTag("ScoreTextTag");
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector2 position = transform.position;

        position = new Vector2(position.x, position.y - speed * Time.deltaTime);

        transform.position = position;

        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        if (transform.position.y < min.y)
        {
            Destroy(gameObject);
        }

      }
    void OnTriggerEnter2D(Collider2D col)
    {
        if ((col.tag == "PlayerShipTag") || (col.tag == "PlayerBulletTag"))
        {
            PlayExplosion();
            scoreUITextGO.GetComponent<GameScore>().Score += 100;
            Destroy(gameObject);
        }
    }

    void PlayExplosion ()
    {
        GameObject explosion = (GameObject)Instantiate(ExplosionGO);
        explosion.transform.position = transform.position;
    }

}
