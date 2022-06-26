//using System;
using System.Collections;
using System.Collections.Generic;
//using System.Security.Cryptography;
//using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This entire class is poorly named, but I do not have time to rename this
/// Right now it manages all text and date interactions
/// </summary>

public class D3
{
    public string playerTxt;
    public string loverTxt;
    public string friendTxt;
    public string daughterTxt;

    public D3(string playerTxt, string loverTxt, string daughterTxt, string friendTxt)
    {
        this.playerTxt = playerTxt;
        this.loverTxt = loverTxt;
        this.daughterTxt = daughterTxt;
        this.friendTxt = friendTxt;
    }
}

public class DM3 : MonoBehaviour
{
    private GameObject playerChat;
    private Text playerText;
    private GameObject daughterChat;
    private Text daughterText;
    private GameObject friendChat;
    private Text friendText;
    private GameObject loverChat;
    private Text loverText;
    private Text dateText;

    private Date date;
    
    // indexed by number of clicks
    public List<D3> dialogues = new List<D3>();
    public int currentStep;
    public List<Sprite> newspapers = new List<Sprite>();
    public SpriteRenderer bg;
    public SpriteRenderer bbg;
    
    // singleton
    private static DM3 _instance;

    public static DM3 Instance()
    {
        if (_instance == null)
        {
            GameObject dd = new GameObject();
            dd.AddComponent<DM3>();
            _instance = dd.GetComponent<DM3>();
        }
        return _instance;
    }

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        playerChat = GameObject.Find("hero").transform.Find("Dialogue").gameObject;
        playerText = playerChat.transform.Find("Panel/Text").GetComponent<Text>();
        daughterChat = GameObject.Find("daughter").transform.Find("Dialogue").gameObject;
        daughterText = daughterChat.transform.Find("Panel/Text").GetComponent<Text>();
        loverChat = GameObject.Find("lover").transform.Find("Dialogue").gameObject;
        loverText = loverChat.transform.Find("Panel/Text").GetComponent<Text>();
        friendChat = GameObject.Find("friend").transform.Find("Dialogue").gameObject;
        friendText = friendChat.transform.Find("Panel/Text").GetComponent<Text>();
        dateText = GameObject.Find("DateText").GetComponent<Text>();
        currentStep = 0;
        playerChat.SetActive(false);
        daughterChat.SetActive(false);
        friendChat.SetActive(false);
        loverChat.SetActive(false);
        dialogues.Add(new D3("我到底该往哪里走？前进？后退？", null, null, null));
        dialogues.Add(new D3(null, "亲爱的，你能不能回家看看？", "爸爸，我会弹吉他啦。", null));
        dialogues.Add(new D3(null, "我们都四十多了，没有东西去挥霍了......", "我不当太空人啦，我要做音乐家！", "好久没有联系你了，我欠的钱太多了......"));
        dialogues.Add(new D3("......", "我不是在指责你！我也不想和你吵架！", "爸爸惹妈妈生气啦！大坏蛋！", null));
        dialogues.Add(new D3(null, "我最近总想起二十年前，我们用BP机的时候......", "不理你！", "房子、车子，能卖的都卖了，幸好当初没生孩子。"));
        dialogues.Add(new D3(null, null, "最近妈妈不开心......", "能不能再借我点儿？"));
        dialogues.Add(new D3("我已经在努力往回走了，可我好像不顾一切地走得太远了。", "或许，当初我也应该外出闯荡闯荡，你会在我背后支持我吗？", null, null));
        dialogues.Add(new D3("我在努力往回走，可一切好像还是在前进......", null, "爸爸，我想要把新吉他，考好了能给我买吗？", null));
        dialogues.Add(new D3(null, "最近有些疲惫，可能是课上得多了吧。", null, null));
        dialogues.Add(new D3("你们等等我......", "医生说我一直以来都太累了。我可能要住院一段时间......", "爸，初中的第一次家长会，你能回来吗？", "最近催债的催得紧，我得去国外避避风头。再见了......"));
        dialogues.Add(new D3(null, null, "爸，你真烦，别管我，我已经不再是小孩子了！", null));
        dialogues.Add(new D3("......", "我恍然觉得，这些年来，我过得并不幸福。", null, null));
        dialogues.Add(new D3(null, "我不想再因为这些小事吵架了，我们离婚吧......", "我当然是跟着我妈啦。", null));
        dialogues.Add(new D3("等等我！", null, null, null));
        dialogues.Add(new D3(null, null, null, null));
        dialogues.Add(new D3("为什么会这样？", null, null, null));
        dialogues.Add(new D3(null, null, null, null));
        dialogues.Add(new D3("要如何才能回到过去，回到一切选择的开头？", null, null, null));
        dialogues.Add(new D3(null, null, "爸，我这辈子不会像你一样碌碌无为。我要去追寻我的价值。", null));
        dialogues.Add(new D3("如果有一个神的话......", null, null, null));
        date = new Date(2010, 6);
        dateText.text = date.getDate(currentStep);
        bg.sprite = newspapers[currentStep];
    }

    void Update()
    {
        
    }

    public void NextStep()
    {
        currentStep++;
        if (currentStep >= dialogues.Count)
        {
            //TODO
            Debug.Log("end of scene");
        }
        dateText.text = date.getDate(currentStep);
        StartCoroutine(ChangeBackground());
    }
    
    private IEnumerator ChangeBackground ()
    {
        float seconds = 0.8f;
        float elapsedTime = 0;
        bbg.sprite = bg.sprite;
        bg.sprite = newspapers[currentStep];
        while (elapsedTime < seconds)
        {
            float a = Mathf.Lerp(0, 1, (elapsedTime / seconds));
            bg.color = new Color(1, 1, 1, a);
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        bg.color = new Color(1, 1, 1, 1);
    }

    public void UpdateDialogue()
    {
        Display(dialogues[currentStep]);
    }

    public void Display(D3 dialogue)
    {
        playerChat.SetActive(false);
        if (dialogue.playerTxt != null)
        {
            playerChat.SetActive(true);
            playerText.text = dialogue.playerTxt;
        }
        daughterChat.SetActive(false);
        if (dialogue.daughterTxt != null)
        {
            daughterChat.SetActive(true);
            daughterText.text = dialogue.daughterTxt;
        }
        friendChat.SetActive(false);
        if (dialogue.friendTxt != null)
        {
            friendChat.SetActive(true);
            friendText.text = dialogue.friendTxt;
        }
        loverChat.SetActive(false);
        if (dialogue.loverTxt != null)
        {
            loverChat.SetActive(true);
            loverText.text = dialogue.loverTxt;
        }
    }
}
