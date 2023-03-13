using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using TMPro;
using System.Threading;

public class GameStartContoller : MonoBehaviour
{
    public static GameStartContoller Instance { get;private set; }

    [SerializeField]
    [Range(0, 10)]
    private float _startGameTimer = 3;
    [SerializeField]
    private TextMeshProUGUI _timerTxt;

    public Action onGameStart;
    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        if(_startGameTimer <= 0)
        {
            onGameStart?.Invoke();
            gameObject.SetActive(false);
        }
        else
        {
            _startGameTimer -= Time.deltaTime;
            _timerTxt.text = ((int)_startGameTimer).ToString();
        }
    }
}
