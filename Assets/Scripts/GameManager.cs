using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager> {
    [SerializeField] GameObject titleUI;
    [SerializeField] TMP_Text livesUI;
    [SerializeField] TMP_Text timerUI;
    [SerializeField] Slider sliderUI;
    [SerializeField] FloatVariable health;
    [Header("Events")]
    [SerializeField] IntEvent scoreEvent;
    [SerializeField] VoidEvent gameStartEvent;

    public enum State
    {
        TITLE,
        START_GAME,
        PLAY_GAME,
        GAME_OVER
    }

    public State state = State.TITLE;
    public float timer = 0;
    public int lives = 0;

    public int Lives {  get { return lives; } set { lives = value; livesUI.text = "Lives: " + lives.ToString(); } }
    public float Timer { get { return timer; } set { timer = value; timerUI.text = string.Format("{0:f1}", timer); } }

    // Start is called before the first frame update
    void Start()
    {
        scoreEvent.onEventRaised += OnAddPoints;
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case State.TITLE:
                titleUI.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                break;
            case State.START_GAME:
                gameStartEvent.RaiseEvent();
                titleUI.SetActive(false);
                Timer = 60;
                Lives = 3;
                state = State.PLAY_GAME;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                break;
            case State.PLAY_GAME:
                Timer -= Time.deltaTime;
                break;
            case State.GAME_OVER:
                break;
            default:
                break;
        }
        sliderUI.value = health.Value / 100.0f;
    }



    public void OnStartGame()
    {
        print("START GAME");
        state = State.START_GAME;
    }



    public void OnAddPoints(int points)
    {
        print(points.ToString());
    }
}
