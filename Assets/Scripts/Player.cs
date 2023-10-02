using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static Player instance;

    public GameParameters gameParameters;
    public Transform cameraTransform;
    public CharacterMovement characterMovement;
    public Transform cameraPosPlaying;
    public Transform cameraPosBoxing;
    public Transform cameraPosMenu;

    public SpawnSystem spawnSystem;

    public GameObject instructionScreen;

    public FinalScreen finalScreen;

    protected bool trackTime = false;
    protected float timeCounter;
    protected int faultsCounter;
    protected float totalPoints = 0;

    protected bool gamePlaying = false;

    protected bool playedCountdown;

    void Start()
    {
        instance = this;
        finalScreen.gameObject.SetActive(false);
        
        cameraTransform.position = cameraPosMenu.position;
        cameraTransform.rotation = cameraPosMenu.rotation;
    }

    public void StartGame()
    {
        characterMovement.EnableMovement();
        spawnSystem.StartGame();
        ChangeToGame();
        AudioManager.instance.SwitchMusicToGameplay();
    }

    public void ChangeToBoxing()
    {
        characterMovement.DisableMovement();
        cameraTransform.position = cameraPosBoxing.position;
        cameraTransform.rotation = cameraPosBoxing.rotation;
    }

    public void ChangeToGame()
    {
        characterMovement.EnableMovement();
        cameraTransform.position = cameraPosPlaying.position;
        cameraTransform.rotation = cameraPosPlaying.rotation;
    }

    void Update()
    {
        if(gamePlaying)
        {
            timeCounter += Time.deltaTime;

            if(trackTime && timeCounter > gameParameters.maxTime)
            {
                GameOver(true);
            }
            else if(!playedCountdown && trackTime && (gameParameters.maxTime - timeCounter) < 10 )
            {
                playedCountdown = true;
                AudioManager.instance.PlaySound("Countdown");
            }
        }
    }

    public void AddFault()
    {
        if(gamePlaying)
        {
            faultsCounter++;
            totalPoints -= gameParameters.faultTruck;

            if(faultsCounter >= gameParameters.maxTrucksFaults)
            {
                GameOver(false);
            }
        }
    }

    public void AddPoints(float points)
    {
        if(gamePlaying)
        {
            totalPoints += points;
        }
    }

    public void GameOver(bool win)
    {
        finalScreen.SetFinalScreen(win, totalPoints, timeCounter);
        characterMovement.DisableMovement();
        cameraTransform.position = cameraPosPlaying.position;
        cameraTransform.rotation = cameraPosPlaying.rotation;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
