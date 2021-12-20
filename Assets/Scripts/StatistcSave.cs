using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using System.IO;
using System.Text;

public class StatistcSave : MonoBehaviour
{
    private TextMeshProUGUI scoretext;
    private TextMeshProUGUI maxScoreDeadtext;
    private TextMeshProUGUI recordScoretext;
    private float currentScore;
    private bool scoreCounted = true;
    private string fileName = "/sav.sav";
    private float maxScores;
    private string deadScoreTextPart = " scores";
    private string recordScoreTextPart = "record: ";
    private string heightText = "height: ";
    void Start()
    {
        SetCurrentScore();
        StartCoroutine(CreateSav());
        
    }

    private void SetCurrentScore()
    {
        recordScoretext.text = recordScoreTextPart + 0;
        scoretext.text = heightText + 0;
    }

    public void AddScore()
    {
        if (scoreCounted)
        {
            currentScore += 1;
        }
        scoretext.text = heightText + Mathf.Round(currentScore);
        UpdateScore();
    }

    private void UpdateScore()
    {
        if (maxScores > currentScore)
        {
            recordScoretext.text = recordScoreTextPart + maxScores;
        }
        else
        {
            recordScoretext.text = recordScoreTextPart + currentScore;
        }
    }
    public void StopGame()
    {
        scoreCounted = false;
        string savFilePath = Application.persistentDataPath +fileName ;
        if (maxScores < currentScore)
        {
            WriteCurrentScores();
        }
       
        maxScoreDeadtext.text = Mathf.Round(currentScore) + deadScoreTextPart;
    }

    private void OnApplicationQuit()
    {
        StopGame();
    }

    public void DI(TextMeshProUGUI scoretext, TextMeshProUGUI maxScoreDeadtext, TextMeshProUGUI recordScoretext)
    {
        this.scoretext = scoretext;
        this.maxScoreDeadtext = maxScoreDeadtext;
        this.recordScoretext = recordScoretext;
    }

    private IEnumerator CreateSav()
    {
        string savFilePath = Application.persistentDataPath +fileName ;
        if (!File.Exists(savFilePath))
        {
            File.Create(savFilePath);
            yield return new WaitForSeconds(.1f);
            StreamWriter sw = new StreamWriter(savFilePath);
            sw.WriteLine("0");
            sw.Close();
        }
        yield return new WaitForSeconds(.1f);
        ReadScoresFromFile();
    }

    private void ReadScoresFromFile()
    {
        string savFilePath = Application.persistentDataPath +fileName ;
        StreamReader sr;
        if (File.Exists(savFilePath))
        {
            sr = new StreamReader(savFilePath);
            string stroke = sr.ReadLine();
            sr.Close();
            maxScores =int.Parse(stroke);
            UpdateScore();
        }
    }

    private void WriteCurrentScores()
    {
        string savFilePath = Application.persistentDataPath +fileName ;
        StreamWriter sw = new StreamWriter(savFilePath);
        sw.WriteLine(currentScore);
        sw.Close();
    }
}
