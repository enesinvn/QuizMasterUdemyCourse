using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float timeToCompleteQuestion = 30f;
    [SerializeField] float timeToShowCorrectAnswer = 10f;

    public bool loadNextQuestion;
    public bool isAnswerİnQuestion = false;
    public float fillFraction;
    
    float timerValue;
    void Update()
    {
        updateTimer();
    }

    public void CancelTimer()
    {
        timerValue = 0;
    }

    // ReSharper disable Unity.PerformanceAnalysis
    void updateTimer()
    {
        timerValue -= Time.deltaTime;

        if (isAnswerİnQuestion)
        {
            if (timerValue > 0)
            {
                fillFraction = timerValue / timeToCompleteQuestion;
            }
            else
            {
                isAnswerİnQuestion = false;
                timerValue = timeToShowCorrectAnswer;
            }
            
        }
        else
        {
            if (timerValue > 0)
            {
                fillFraction = timerValue / timeToShowCorrectAnswer;
            }
            else
            {
                isAnswerİnQuestion = true;
                timerValue = timeToCompleteQuestion;
                loadNextQuestion = true;
            }
        }
        
        Debug.Log(isAnswerİnQuestion + ": " + timerValue + " = " + fillFraction);
    }
}
