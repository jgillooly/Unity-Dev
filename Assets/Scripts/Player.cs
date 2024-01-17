using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    [SerializeField] FloatVariable health;
    [SerializeField] PhysicsCharacterController characterController;
    [SerializeField] OrbitCamera orbitCamera;
    [Header("Events")]
    [SerializeField] IntEvent scoreEvent = default;
    [SerializeField] VoidEvent startEvent = default;
    private int score = 0;
    //private float health = 100;

    public int Score {  
        get { return score; } 
        set { score = value; scoreText.text = score.ToString(); scoreEvent.RaiseEvent(score); } 
    }

    public void AddPoints(int points)
    {
        Score += points;
    }

    private void OnEnable()
    {
        startEvent.Subscribe(OnStartGame);
    }

    public void Start()
    {
        health.Value = 55f;
        characterController.enabled = false;
        orbitCamera.enabled = false;
    }

    public void OnStartGame()
    {
        characterController.enabled = true;
        orbitCamera.enabled = true;
    }
}
