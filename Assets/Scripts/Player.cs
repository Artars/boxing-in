using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static Player instance;

    [System.Serializable]
    public class CameraSettings
    {
        public Transform center;
        public Transform min;
        public Transform max;
    }

    public GameParameters gameParameters;
    public Transform cameraTransform;
    public Camera cameraRef;
    public CharacterMovement characterMovement;
    public CameraSettings menuCamera;
    public CameraSettings gameCamera;
    public CameraSettings puzzleCamera;

    public SpawnSystem spawnSystem;

    public GameObject instructionScreen;

    public FinalScreen finalScreen;

    
    [Header("UI")]
    public GameObject gameplayUI;
    public GameObject togglePrefab;
    public Transform toggleParent;
    protected Toggle[] toggles = new Toggle[0];
    public TMPro.TMP_Text pointText;
    public TMPro.TMP_Text timeText;

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
        gameplayUI.SetActive(false);
        
        SetCamera(menuCamera);
    }

    public void StartGame()
    {
        trackTime = gameParameters.maxTime != float.PositiveInfinity;

        characterMovement.EnableMovement();
        characterMovement.SetPlayerModel(0);
        spawnSystem.StartGame();
        ChangeToGame();
        AudioManager.instance.SwitchMusicToGameplay();
        gamePlaying = true;

        gameplayUI.SetActive(true);
        CreateToggle();
    }

    public void SetCamera(CameraSettings setting)
    {
        cameraTransform.position = setting.center.position;
        cameraTransform.rotation = setting.center.rotation;

        Vector3 size = setting.max.position - setting.min.position;
        cameraRef.orthographicSize = Vector3.Dot(size, cameraTransform.up) * .6f;        
    }

    protected void CreateToggle()
    {
        if(gameParameters.maxTrucksFaults < 10)
        {
            toggles = new Toggle[gameParameters.maxTrucksFaults];

            for (int i = 0; i < gameParameters.maxTrucksFaults; i++)
            {
                GameObject newToggle = GameObject.Instantiate(togglePrefab, toggleParent);
                newToggle.SetActive(true);
                toggles[i] = newToggle.GetComponentInChildren<Toggle>();
                toggles[i].isOn = false;
            }
        }
    }

    public void ChangeToBoxing()
    {
        characterMovement.DisableMovement();
        SetCamera(puzzleCamera);
    }

    public void ChangeToGame()
    {
        characterMovement.EnableMovement();
        SetCamera(gameCamera);
    }

    void Update()
    {
        if(gamePlaying)
        {
            timeCounter += Time.deltaTime;

            if(trackTime)
            {
                timeText.text = (gameParameters.maxTime - timeCounter).ToString("F0");
                if(timeCounter > gameParameters.maxTime)
                {
                    GameOver(true);
                }
                else if(!playedCountdown && (gameParameters.maxTime - timeCounter) < 10 )
                {
                    playedCountdown = true;
                    AudioManager.instance.PlaySound("Countdown");
                }
            }
            else
            {
                timeText.text = timeCounter.ToString("F0");

            }

        }
    }

    public void AddFault()
    {
        if(gamePlaying)
        {
            faultsCounter++;
            totalPoints -= gameParameters.faultTruck;

            for (int i = 0; i < toggles.Length; i++)
            {
                toggles[i].isOn = i < faultsCounter;
            }

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

            pointText.text = totalPoints.ToString("F0");
        }
    }

    public void GameOver(bool win)
    {
        if(!gamePlaying) return;

        trackTime = false;
        gamePlaying = false;
        finalScreen.gameObject.SetActive(true);
        finalScreen.SetFinalScreen(win, totalPoints, timeCounter);
        characterMovement.DisableMovement();
        SetCamera(gameCamera);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
