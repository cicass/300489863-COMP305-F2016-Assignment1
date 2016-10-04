using UnityEngine;
using System.Collections;
/* 
 *Author: Sheikh Kalam 
 * Student ID: 300 489 863  
 * 
 * Date last modified: October 2nd, 2016 
 * Description: This script controls the game menu screen  
 *  
 */

public class GameManager : MonoBehaviour
{

    public GameObject playButton;
    public GameObject playerShip;
    public GameObject enemySpawner;
    public GameObject gameOver;
    public GameObject scoreUITextGO;

    public enum GameManagerState
    {
        Opening,
        Gameplay,
        GameOver,
    }

    GameManagerState GMState;

	// Use this for initialization
	void Start ()
    {
        GMState = GameManagerState.Opening;
	}
	
	// Update is called once per frame
	void UpdateGameManagerState ()
    {
        switch (GMState)
        {
            case GameManagerState.Opening:
                // hide game over
                gameOver.SetActive(false);
                //play button visible 
                playButton.SetActive(true);
                break;
            case GameManagerState.Gameplay:

                scoreUITextGO.GetComponent<GameScore>().Score = 0;
                // hide the play button on game play state
                playButton.SetActive(false);
                // set the player visible and init the player lives
                playerShip.GetComponent<PlayerControl>().Init();

                //start enemy spawner
                enemySpawner.GetComponent<EnemySpawnerGO>().StartEnemySpawner();

                break;
            case GameManagerState.GameOver:
                // stop the spawner
                enemySpawner.GetComponent<EnemySpawnerGO>().StopEnemySpawner();
                //display geme over
                gameOver.SetActive(true);

                Invoke("ChangeToOpeningState", 3f);
                break;
        }
    }
    public void SetGameManagerState(GameManagerState state)
    {
        GMState = state;
        UpdateGameManagerState();
    }
    // play button call this upon clicking
    public void StartGamePlay()
    {
        GMState = GameManagerState.Gameplay;
        UpdateGameManagerState();
    }

    public void ChangeToOpeningState ()
    {
        SetGameManagerState(GameManagerState.Opening);
    }

}
