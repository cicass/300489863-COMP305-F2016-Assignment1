using UnityEngine;
using UnityEngine.UI;
using System.Collections;
/* 
 *Author: Sheikh Kalam 
 * Student ID: 300 489 863  
 * 
 * Date last modified: October 2nd, 2016 
 * Description: This script controls the player ship behavior  
 *  
 */
public class PlayerControl : MonoBehaviour
{

    public GameManager GameManagerGO;

    public GameObject PlayerBulletGO;
    public GameObject BulletPosition01;
    public GameObject BulletPosition02;
    public GameObject ExplosionGO;

    //reference to lives ui text
    public Text LivesUIText;

    const int MaxLives = 5;
    int lives; // currnet player lives

    public float speed; // Speed of the player ship

    public void Init ()
    {
        lives = MaxLives;

        LivesUIText.text = lives.ToString(); // update the live ui text
        //reset the position of the player
        transform.position = new Vector2(0,0);

        gameObject.SetActive(true); // active game object
    }

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown("space"))
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();

            GameObject bullet01 = (GameObject)Instantiate(PlayerBulletGO);
            bullet01.transform.position = BulletPosition01.transform.position;
            GameObject bullet02 = (GameObject)Instantiate(PlayerBulletGO);
            bullet02.transform.position = BulletPosition02.transform.position;

        }

        float x = Input.GetAxisRaw("Horizontal"); // the value will be -1, 0 or 1 (for left, no input and right)
        float y = Input.GetAxisRaw("Vertical"); // the value will be -1, 0 or 1 (for down, no input and up)

        //coumputing direction vector
        Vector2 direction = new Vector2(x, y).normalized;

        //set the players position
        Move(direction);

    }

    void Move (Vector2 direction)
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0,0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1,1));

        max.x = max.x - 0.225f;
        min.x = min.x + 0.225f;

        max.y = max.y - 0.285f;
        min.y = min.y + 0.285f;

        Vector2 pos = transform.position;

        pos += direction * speed * Time.deltaTime;

        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);

        transform.position = pos;
    }
    void OnTriggerEnter2D (Collider2D col)
    {
        if ((col.tag == "EnemyShipTag") || (col.tag =="EnemyBulletTag"))
        {
            PlayExplosion();
            lives--;
            LivesUIText.text = lives.ToString();
            // Testing purpose commenting out the line below +++

            if (lives ==0)
            {
                GameManagerGO.GetComponent<GameManager>().SetGameManagerState(GameManager.GameManagerState.GameOver);
                gameObject.SetActive(false);
            }

        }
    
    }
    void PlayExplosion ()
    {
        GameObject explosion = (GameObject)Instantiate(ExplosionGO);
        explosion.transform.position = transform.position;
    }
}
