using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    [SerializeField] private QuizUI quizUI;
    [SerializeField] private QuizDataScriptable quizData;
    public string CenaResposta;
    
    private List<Question> questions;

    private Question selectedQuestion;
    private int ScoreCount = 0;
    private int Count = 0;

    void Start()
    {
        PlayerPrefs.SetInt("Score", 0);
        ScoreCount = 0;
        questions = quizData.questions;
        SelectQuestion();
    }

    private void Update()
    {
        if(Count == 4)
        {
            SceneManager.LoadScene(CenaResposta);
        }
      
    }

    void SelectQuestion()
   {
    int val = Random.Range(0,questions.Count);
    selectedQuestion= questions[val];

    quizUI.SetQuestion(selectedQuestion);

    questions.RemoveAt(val);
   }
   public bool Answer(string answered)
   {
    bool correctAns = false;

    if(answered == selectedQuestion.correctAns)
    {
        //Yes
        correctAns =true;
            Count++;
            ScoreCount++;
            PlayerPrefs.SetInt("Score", ScoreCount);
        }
    else
    {
            //No
            Count++;
    }

    Invoke("SelectQuestion",0.4f);
    return correctAns;

   }

}

[System.Serializable]
public class Question
{
    public string questionInfo;
    public QuestionType questionType;
    public Sprite qustionImg;
    public AudioClip qustionClip;
    public UnityEngine.Video.VideoClip qustionVideo;
    public List<string> options;
    public string correctAns;
}
[System.Serializable]
public enum QuestionType
{
    TEXT,
    IMAGE,
    VIDEO,
    AUDIO
}