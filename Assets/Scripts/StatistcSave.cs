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
   [SerializeField] private float maxScores;
    private string deadScoreTextPart = " очков";
    private string recordScoreTextPart = "рекорд: ";
    private string heightText = "Height: ";
    void Start()
    {
        /*
        string savFilePath = Application.persistentDataPath +fileName ;
        if (File.Exists(savFilePath))
        {
            StringReader stringReader = new StringReader(savFilePath);
            string maxScore =stringReader.ReadLine();
            maxScores = float.Parse(maxScore);

        }*/
    }

    public void AddScore()
    {
        if (scoreCounted)
        {
            currentScore += 1;
        }
        scoretext.text = heightText + Mathf.Round(currentScore);
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
      /*  if (!File.Exists(savFilePath))
        {
            fs = File.Create(savFilePath);
        }
        else
        {
            fs = File.Open(savFilePath,FileMode.Open);
        }

        if (fs.re == null)
        {
            Debug.LogError("emptyFile");
        }
        byte[] data = new UTF8Encoding(true).GetBytes(currentScore.ToString());
        fs.Write(data, 0, data.Length);*/
       
        maxScoreDeadtext.text = Mathf.Round(currentScore) + deadScoreTextPart;
    } 

    public void DI(TextMeshProUGUI scoretext, TextMeshProUGUI maxScoreDeadtext, TextMeshProUGUI recordScoretext)
    {
        this.scoretext = scoretext;
        this.maxScoreDeadtext = maxScoreDeadtext;
        this.recordScoretext = recordScoretext;
    }
}
