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

public class D2
{
    public string playerTxt;
    public string motherTxt;
    public string friendTxt;
    public string loverTxt;
    public string daughterTxt;

    public D2(string playerTxt, string motherTxt, string friendTxt, string loverTxt, string daughterTxt)
    {
        this.playerTxt = playerTxt;
        this.motherTxt = motherTxt;
        this.friendTxt = friendTxt;
        this.motherTxt = motherTxt;
        this.daughterTxt = daughterTxt;
    }
}

public class DM2 : MonoBehaviour
{
    private GameObject playerChat;
    private Text playerText;
    private GameObject motherChat;
    private Text motherText;
    private GameObject friendChat;
    private Text friendText;
    private GameObject loverChat;
    private Text loverText;
    private GameObject daugnterChat;
    private Text dauchterText;
    private Text dateText;

    private Date date;
    
    // indexed by number of clicks
    public List<D2> dialogues = new List<D2>();
    public int currentStep;
    public List<Sprite> newspapers = new List<Sprite>();
    public SpriteRenderer bg;
    public SpriteRenderer bbg;
    
    // singleton
    private static DM2 _instance;

    public static DM2 Instance()
    {
        if (_instance == null)
        {
            GameObject dd = new GameObject();
            dd.AddComponent<DM2>();
            _instance = dd.GetComponent<DM2>();
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
        motherChat = GameObject.Find("mother").transform.Find("Dialogue").gameObject;
        motherText = motherChat.transform.Find("Panel/Text").GetComponent<Text>();
        loverChat = GameObject.Find("lover").transform.Find("Dialogue").gameObject;
        loverText = loverChat.transform.Find("Panel/Text").GetComponent<Text>();
        friendChat = GameObject.Find("friend").transform.Find("Dialogue").gameObject;
        friendText = friendChat.transform.Find("Panel/Text").GetComponent<Text>();
        daugnterChat = GameObject.Find("daughter").transform.Find("Dialogue").gameObject;
        dauchterText = dauchterText.transform.Find("Panel/Text").GetComponent<Text>();
        dateText = GameObject.Find("DateText").GetComponent<Text>();
        currentStep = 0;
        playerChat.SetActive(false);
        motherChat.SetActive(false);
        friendChat.SetActive(false);
        loverChat.SetActive(false);
        dialogues.Add(new D2(null, "孩子，没关系，重头再来，也未尝见不到新的风景。", "看病把钱都花光了？跟兄弟客气什么，我给你！你放心走！", "你知道的，我和妈都一直在你身后.....", null));
        dialogues.Add(new D2(null, null, null, null, null));
        dialogues.Add(new D2(null, "好事，好事啊。哎，人老了就是容易落泪。", null, "老公，你要当爸爸了......", null));
        dialogues.Add(new D2(null, null, "在几个厂一起办的庆祝申奥的活动上，我遇到了个女人......", null, null));
        dialogues.Add(new D2(null, "明天我去给你爸烧叠纸，让他保佑保佑孙女儿。", null, "你看，孩子长得真像你！", "（女儿出现在场景中）哇哇哇哇！"));
        dialogues.Add(new D2(null, null, "筹备婚礼真累啊，你当初是怎么过来的？", "哎，睡不踏实，孩子老是半夜哭。", "呜呜呜呜！"));
        dialogues.Add(new D2(null, "你媳妇儿嫌弃我溺爱孙子？这还有理吗？", "哈哈，你也觉得西式婚礼不适合我吗？", null, "呜呜呜呜呜！"));
        dialogues.Add(new D2(null, null, null, "老公！孩子终于会叫我们啦！", "爸...爸！"));
        dialogues.Add(new D2("？", "这孩子在说些什么？", "？", "？", "哇酷哇酷！"));
        dialogues.Add(new D2(null, null, "小孩子这么可爱，我要不要也生一个？", null, "爸爸，玩具！"));
        dialogues.Add(new D2(null, "我也真是老了，孙女儿都抱不动啦。", null, "最近女儿和学生老气得我头疼。", "不吃！不吃番茄！"));
        dialogues.Add(new D2(null, null, "我家那口子说什么新世纪新观念，要丁克，随她吧。", null, "呜呜呜哇，爸爸，不要走！"));
        dialogues.Add(new D2(null, "你们也该买个房子啦，我的钱都给你们。", null, "孩子越来越大了，是该买个房子了", null));
        dialogues.Add(new D2(null, null, null, "看房子和备课确实有些累，最近头疼的时间也多了。", "爸爸！我要当太空人！"));
        dialogues.Add(new D2(null, "诶，你俩干嘛要迁就我买个低层？", "最近经济不太平啊，我得想想法子，让厂子别亏了。", null, null));
        dialogues.Add(new D2("有些累了...", null, "我家那口子天跟我吵架，说我忙工作不回家......", "总算搬进来啦......", "新房子！"));
        dialogues.Add(new D2(null, "昨晚梦到你爸了。真是奇怪，他走之后我还从没梦到过他。", "最近又是地震，又是金融危机的，我的厂子也倒了......", "你在外面也要注意安全！", "地震！地震好玩吗爸爸？"));
        dialogues.Add(new D2("......", null, "节哀。", "可惜，妈没看成奥运会......", "爸爸，好大的雪啊，奶奶去哪里玩雪了吗？"));
        dialogues.Add(new D2("这些年，我到底在做些什么？", null, null, "亲爱的......", "爸爸，你不舒服吗？我来给你捶捶背！"));
        dialogues.Add(new D2("这一切，值得吗？", null, null, null, null));
        date = new Date(2000, 6);
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

    public void Display(D2 dialogue)
    {
        playerChat.SetActive(false);
        if (dialogue.playerTxt != null)
        {
            playerChat.SetActive(true);
            playerText.text = dialogue.playerTxt;
        }
        motherChat.SetActive(false);
        if (dialogue.motherTxt != null)
        {
            motherChat.SetActive(true);
            motherText.text = dialogue.motherTxt;
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
        daugnterChat.SetActive(false);
        if (dialogue.daughterTxt != null)
        {
            daugnterChat.SetActive(true);
            dauchterText.text = dialogue.daughterTxt;
        }
    }
}
