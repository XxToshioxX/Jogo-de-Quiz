using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizUI : MonoBehaviour
{
    [SerializeField] private QuizManager quizManager;
    [SerializeField] private Text questionText, scoreText;
    [SerializeField] private Image questionImage;
    [SerializeField] private UnityEngine.Video.VideoPlayer questionVideo;
    [SerializeField] private AudioSource questionAudio;
    [SerializeField] private List<Button> options;
    [SerializeField] private Color correctCOL, wrongCOL, normaCOL;

    private Question question;
    private bool answered;
    private float audioLength;


    // Start is called before the first frame update
    void Awake()
    {
        for( int i = 0; i < options.Count; i++)
        {
            Button localBtn = options[i];
            localBtn.onClick.AddListener(() => OnClick(localBtn));
        }
    }

    public void SetQuestion(Question question)
    {
        this.question = question;

        switch(question.questionType)
        {

            case QuestionType.TEXT:

            questionImage.transform.parent.gameObject.SetActive(false);

            break;

             case QuestionType.IMAGE:
             ImageHolder();
             questionImage.transform.parent.gameObject.SetActive(true);

             questionImage.sprite = question.qustionImg;
            break;

             case QuestionType.VIDEO:
             ImageHolder();
             questionVideo.transform.parent.gameObject.SetActive(true);

             questionVideo.clip = question.qustionVideo;
            break;

             case QuestionType.AUDIO:
             ImageHolder();
             questionAudio.transform.parent.gameObject.SetActive(true);

             audioLength = question.qustionClip.length;

             StartCoroutine(PlayAudio());
            break;

        }

        questionText.text = question.questionInfo;

        List<string> answerList = ShuffleList.ShuffleListItems<string>(question.options);

        for (int i=0; i<options.Count; i++)
        {
            options[i].GetComponentInChildren<Text>().text=answerList[i];
            options[i].name = answerList[i];
            options[i].image.color= normaCOL;
        }

        answered = false;

    }
    IEnumerator PlayAudio()
    {
        if(question.questionType == QuestionType.AUDIO)
        {
            questionAudio.PlayOneShot(question.qustionClip);
            yield return new WaitForSeconds(audioLength + 0.5f);

            StartCoroutine(PlayAudio());
        }
        else
        {
            StopCoroutine(PlayAudio());
            yield return null;
        }
    }

    void ImageHolder()
    {
        questionImage.transform.parent.gameObject.SetActive(true);
        questionImage.transform.parent.gameObject.SetActive(false);
        questionAudio.transform.parent.gameObject.SetActive(false);
        questionVideo.transform.parent.gameObject.SetActive(false);

    }

    private void OnClick(Button btn)
    {
        if(!answered)
        {
            answered = true;
            bool val = quizManager.Answer(btn.name);

            if(val)
            {
                btn.image.color = correctCOL;
            }
            else
            {
                btn.image.color = wrongCOL;
            }
        }
    }


    
}
