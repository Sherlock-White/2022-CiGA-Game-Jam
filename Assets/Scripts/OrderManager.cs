using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public enum phase{NONE, MOVING, BACKGROUND, DATE}

public class OrderManager : MonoBehaviour
{
    public Hero hero;

    private float elapsedTime;
    public float moveTime;
    public float bgTime;
    public float dateTime;
    private phase currentPhase;
    
    public void ToLeftUp()
    {
        OnButtonClick(DIRECTION.LEFT_UP);
    }
    public void ToLeftDown()
    {
        OnButtonClick(DIRECTION.LEFT_DOWN);
    }
    public void ToRightUp()
    {
        OnButtonClick(DIRECTION.RIGHT_UP);
    }

    public void ToRightDown()
    {
        OnButtonClick(DIRECTION.RIGHT_DOWN);
    }
    
    public void OnButtonClick(DIRECTION dir)
    {
        currentPhase = phase.MOVING;
        hero.Move(dir);
        elapsedTime = 0;
    }

    void Start()
    {
        currentPhase = phase.NONE;
        elapsedTime = 0;
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;
        switch (currentPhase)
        {
            case phase.NONE:
                break;
            case phase.MOVING:
                if (elapsedTime > moveTime)
                {
                    currentPhase = phase.BACKGROUND;
                    DialogueDisplay.Instance().NextStep();
                    elapsedTime = 0;
                }
                break;
            case phase.BACKGROUND:
                if (elapsedTime > bgTime)
                {
                    currentPhase = phase.DATE;
                    DialogueDisplay.Instance().UpdateDialogue();
                    elapsedTime = 0;
                }
                break;
            case phase.DATE:
                if (elapsedTime > dateTime)
                {
                    currentPhase = phase.NONE;
                }
                break;
        }
        
    }
}
