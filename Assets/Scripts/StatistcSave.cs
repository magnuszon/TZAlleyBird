using System.Collections;
using TMPro;
using UnityEngine;
using System.IO;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class StatistcSave : MonoBehaviour
{
    private TextMeshProUGUI currentScoreText;
    private TextMeshProUGUI deadScoreText;
    private TextMeshProUGUI recordScoretext;
    private float currentScore;
    private bool scoreCounted = true;
    private string fileName = "/sav.sav";
    private float maxScores;
    private string deadScoreTextPart = " scores";
    private string recordScoreTextPart = "record: ";
    private string heightText = "height: ";
    private string savFilePath;
    public UnityAction deadAction;
    void Start()
    {
        savFilePath = Application.persistentDataPath +fileName ;
      //  deadAction += DeadAction;
        SetCurrentScore();
        StartCoroutine(CreateSav());
        
    }

    private void SetCurrentScore()
    {
        recordScoretext.text = recordScoreTextPart + 0;
        currentScoreText.text = heightText + 0;
    }

    public void AddScore()
    {
        if (scoreCounted)
        {
            currentScore += 1;
        }
        currentScoreText.text = heightText + Mathf.Round(currentScore);
        UpdateScore();
    }

    private void UpdateScore()
    {
        if (maxScores > currentScore)
        {
            recordScoretext.text = recordScoreTextPart + maxScores;
            deadScoreText.text = maxScores + deadScoreTextPart ;
        }
        else
        {
            recordScoretext.text = recordScoreTextPart + currentScore;
            deadScoreText.text = currentScore +deadScoreTextPart;
        }
    }
    public void StopGame()
    {
        scoreCounted = false;
        if (maxScores < currentScore)
        {
            WriteCurrentScores();
        }
       
        deadScoreText.text = Mathf.Round(currentScore) + deadScoreTextPart;
    }

    private void OnApplicationQuit()
    {
        StopGame();
    }

    public void DI(TextMeshProUGUI currentScoreText, TextMeshProUGUI deadScoreText, TextMeshProUGUI recordScoretext)
    {
        this.currentScoreText = currentScoreText;
        this.deadScoreText = deadScoreText;
        this.recordScoretext = recordScoretext;
    }

    private IEnumerator CreateSav()
    {
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
       
        StreamWriter sw = new StreamWriter(savFilePath);
        sw.WriteLine(currentScore);
        sw.Close();
    }

    public void DeadAction()
    {
        UpdateScore();
        WriteCurrentScores();
    }
}
