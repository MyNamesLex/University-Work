using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PureQuestions : MonoBehaviour
{
    [Header("Questions")]
    public List<string> Questions;
    public int QuestionCount;

    [Header("Answers")]
    public List<string> LeftAnswers;
    public List<string> MidAnswers;
    public List<string> RightAnswers;
    public List<string> CorrectAnswers;

    [Header("UI")]
    public TextMeshProUGUI QuestionTitle;
    public Button LeftButton;
    public Button MidButton;
    public Button RightButton;
    public TextMeshProUGUI InfoToPlayer;
    public float InfoToPlayerTimer;

    [Header("Scene Manager")]
    public string NextScene;
    // Start is called before the first frame update
    void Start()
    {
        Stagger();
    }

    public void Stagger()
    {
        if (QuestionCount == Questions.Count)
        {
            LoadNextScene();
        }
        else
        {
            QuestionTitle.text = Questions[QuestionCount];
            LeftButton.GetComponentInChildren<TextMeshProUGUI>().text = LeftAnswers[QuestionCount];
            MidButton.GetComponentInChildren<TextMeshProUGUI>().text = MidAnswers[QuestionCount];
            RightButton.GetComponentInChildren<TextMeshProUGUI>().text = RightAnswers[QuestionCount];
        }
    }

    public void CorrectAnswer(TextMeshProUGUI text)
    {
        if(text.text == CorrectAnswers[QuestionCount])
        {
            StartCoroutine(InfoToPlayerStagger("Correct"));
            QuestionCount++;
            Stagger();
        }
        else
        {
            StartCoroutine(InfoToPlayerStagger("Incorrect, try again"));
        }
    }

    IEnumerator InfoToPlayerStagger(string text)
    {
        while(true)
        {
            InfoToPlayer.text = text;
            yield return new WaitForSeconds(InfoToPlayerTimer);
            InfoToPlayer.text = string.Empty;
            break;
        }
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(NextScene);
    }
}
