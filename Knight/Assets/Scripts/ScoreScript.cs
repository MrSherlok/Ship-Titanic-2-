﻿using UnityEngine;
using System.Collections;

public class ScoreScript : MonoBehaviour
{
    public int score;
    public int record;
    private float scoregametime;
    void Update()
    {
        scoregametime += Time.deltaTime;

        if (scoregametime >= 2)
        {
            score += 1;
            scoregametime = 0;
        }
        if (score > record)
        {
            PlayerPrefs.SetInt("savescore", score);
            PlayerPrefs.Save();
            Debug.Log("Save");
        }
        record = PlayerPrefs.GetInt("savescore");
    }

    void OnGUI()
    {
        GUIStyle style = new GUIStyle();
        style.richText = true;
        GUI.Label(new Rect(Screen.width / 2, 20, 400, 50), "<size=30><color=#000000ff>Score : " + score + "</color></size>");
        GUI.Label(new Rect(Screen.width / 2, 45, 400, 50), "<size=30><color=#000000ff>Record : " + record + "</color></size>");
    }
}
