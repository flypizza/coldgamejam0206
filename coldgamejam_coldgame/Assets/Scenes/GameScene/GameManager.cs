﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
public enum GAME_STATE
{
    READY,
    START,
    END,
    PAUSE
}
public class GameManager : MonoBehaviour
{
    GAME_STATE state = GAME_STATE.READY;

    public Text txt_game_state;
    public Button btn_replay;
    public Text btn_text_replay;
    public GAME_STATE STATE
    {
        get
        {
            return state;
        }
    }
    private void Awake()
    {
        Application.targetFrameRate = 60;

        btn_replay.gameObject.SetActive(false);
        btn_replay.onClick.AddListener(GameRestart);
        btn_text_replay = btn_replay.GetComponentInChildren<Text>();
    }
    public void Start_RaceCount()
    {
        Sequence seq = DOTween.Sequence();
        seq.Append(txt_game_state.DOText("1..2..3", 3.0f));
        seq.Insert(0.0f, txt_game_state.rectTransform.DOShakePosition(3.0f, 10));
        seq.AppendCallback(GameStart);
        seq.Append(txt_game_state.DOText("Go", 0.3f));
        
        
    }

    public void UpdateBestScore(double score)
    {
        float bestScore = PlayerPrefs.GetFloat("bestScore");
        if(bestScore < score)
        {
            PlayerPrefs.SetFloat("bestScore", (float)score);
            bestScore = (float)score;
        }
        btn_text_replay.text = "";
        string print_sen = "bestScore : " + bestScore.ToString("F0") + "\n Score : " + score.ToString("F0") + "\n RETRY";
        btn_text_replay.DOText(print_sen, 0.5f);
    }

    public void YouLoose()
    {
        btn_text_replay.text = "";
        string print_sen = "You Dead...\nRetry";
        btn_text_replay.DOText(print_sen, 0.5f);
    }
    public void GameStart()
    {
        state = GAME_STATE.START;

        Enemy[] enemies = FindObjectsOfType<Enemy>();
        foreach(Enemy _enemy in enemies)
        {
            _enemy.RaceStart();
        }
    }
    public void GameRestart()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void GameEnd()
    {
        state = GAME_STATE.END;
        btn_replay.gameObject.SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {
        Start_RaceCount();
    }
}
