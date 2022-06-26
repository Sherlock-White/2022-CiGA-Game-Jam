//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;
//using UnityEngine.LowLevel;
using UnityEngine.UI;

public class OM4 : MonoBehaviour
{
    public Hero hero;

    private Button bl;
    private Button br;
    private Button tl;
    private Button tr;

    public GameObject hhh;
    [SerializeField] private int steps;
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
        hero.Move(dir);
    }

    void Start()
    {
        tl = GameObject.Find("hero/Buttons/leftUp").GetComponent<Button>();
        bl = GameObject.Find("hero/Buttons/leftDown").GetComponent<Button>();
        tr = GameObject.Find("hero/Buttons/rightUp").GetComponent<Button>();
        br = GameObject.Find("hero/Buttons/rightDown").GetComponent<Button>();
        Hero hero = hhh.GetComponent<Hero>();
        hero.Instantiate();
        hero.UpdateDirBtn();
    }

    void Update()
    {

    }
}
