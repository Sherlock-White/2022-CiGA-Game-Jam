//using System;
//using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;
//using UnityEngine.LowLevel;
using UnityEngine.UI;

public enum phase{NONE, MOVING, BACKGROUND, DATE}

public class OrderManager : MonoBehaviour
{
    public Hero hero;

    private float elapsedTime;
    public float moveTime;
    public float bgTime;
    public float dateTime;
    private phase currentPhase;

    private Button bl;
    private Button br;
    private Button tl;
    private Button tr;

    public GameObject buttons;
    public GameObject startScene;
    public List<GameObject> scene;

    private GameObject playerChat;
    private Text playerText;
    private GameObject motherChat;
    private Text motherText;
    private GameObject loverChat;
    private Text loverText;
    private GameObject friendChat;
    private Text friendText;
    private Hero hhh;
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
        currentPhase = phase.MOVING;
        hero.Move(dir);
        elapsedTime = 0;
        DisableButtons();
    }

    void Start()
    {
        currentPhase = phase.NONE;
        elapsedTime = 0;
        tl = GameObject.Find("hero/Buttons/leftUp").GetComponent<Button>();
        bl = GameObject.Find("hero/Buttons/leftDown").GetComponent<Button>();
        tr = GameObject.Find("hero/Buttons/rightUp").GetComponent<Button>();
        br = GameObject.Find("hero/Buttons/rightDown").GetComponent<Button>();
        buttons.SetActive(false);
        startScene.SetActive(true);     //自执行NEXT()，是一个透明的按钮
        foreach (var s in scene)
        {
            s.SetActive(false);
        }
        playerChat = GameObject.Find("hero").transform.Find("Dialogue").gameObject;
        playerText = playerChat.transform.Find("Panel/Text").GetComponent<Text>();
        motherChat = GameObject.Find("mother").transform.Find("Dialogue").gameObject;
        motherText = motherChat.transform.Find("Panel/Text").GetComponent<Text>();
        loverChat = GameObject.Find("lover").transform.Find("Dialogue").gameObject;
        loverText = loverChat.transform.Find("Panel/Text").GetComponent<Text>();
        friendChat = GameObject.Find("friend").transform.Find("Dialogue").gameObject;
        friendText = friendChat.transform.Find("Panel/Text").GetComponent<Text>();
        playerChat.SetActive(false);
        motherChat.SetActive(false);
        loverChat.SetActive(false);
        friendChat.SetActive(false);
        motherChat.transform.parent.gameObject.SetActive(false);
        loverChat.transform.parent.gameObject.SetActive(false);
        friendChat.transform.parent.gameObject.SetActive(false);
        steps = 0;
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
                    EnableButtons();
                }
                break;
        }

    }

    private void EnableButtons()
    {
        tl.interactable = true;
        tr.interactable = true;
        bl.interactable = true;
        br.interactable = true;
    }

    private void DisableButtons()
    {
        tl.interactable = false;
        tr.interactable = false;
        bl.interactable = false;
        br.interactable = false;
    }

    public void Next()
    {
        switch (steps)
        {
            case 0:
                playerChat.SetActive(true);
                playerText.text = "我这一生，要找到我的价值！";
                break;
            case 1:
                playerChat.SetActive(false);
                break;
            case 2:
                friendChat.transform.parent.gameObject.SetActive(true);
                break;
            case 3:
                friendChat.SetActive(true);
                friendText.text = "我们毕业了，你怎么打算？";
                break;
            case 4:
                playerChat.SetActive(true);
                playerText.text = "我要去寻找我发光的价值。";
                break;
            case 5:
                friendChat.SetActive(false);
                playerChat.SetActive(false);
                loverChat.transform.parent.gameObject.SetActive(true);
                break;
            case 6:
                loverChat.SetActive(true);
                loverText.text = "我们什么时候能有个家？";
                break;
            case 7:
                playerChat.SetActive(true);
                playerText.text = "亲爱的，再等等我，等我离它再近一点。";
                break;
            case 8:
                loverChat.SetActive(false);
                playerChat.SetActive(false);
                motherChat.transform.parent.gameObject.SetActive(true);
                break;
            case 9:
                motherChat.SetActive(true);
                motherText.text = "你去吧，我们都在你背后支持着你。";
                break;
            case 10:
                motherText.text = "但是要小心，你的岁月是无比珍贵的东西。";
                break;
            case 11:
                playerChat.SetActive(true);
                playerText.text = "我还年轻，妈。我有潜力！";
                //场景音乐淡入
                GameObject.FindWithTag("MainCamera").GetComponent<AudioSource>().Play();
                GameObject.FindWithTag("MainCamera").GetComponent<MusicFade>().FadeIn();
                break;
            default:
                playerChat.SetActive(false);
                buttons.SetActive(true);
                startScene.SetActive(false);
                foreach (var s in scene)
                {
                    s.SetActive(true);
                }

                hhh = playerChat.transform.parent.gameObject.GetComponent<Hero>();
                hhh.Instantiate();
                hhh.UpdateDirBtn();
                break;
        }

        steps++;
    }
}
