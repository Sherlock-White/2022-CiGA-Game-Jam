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

public class Date
{
    public int yearOffset;
    public int monthOffset;
    public Date(int yearOffset, int monthOffset)
    {
        this.yearOffset = yearOffset;
        this.monthOffset = monthOffset;
    }

    public string getDate(int turn)
    {
        
        int monthsPassed = monthOffset + turn * 6;
        int y = yearOffset + monthsPassed / 12;
        int m = monthOffset + (monthsPassed - 6) % 12;
        return $"{y}.{m}";
    }
}

public class Dialogue
{
    public string playerTxt;
    public string motherTxt;
    public string friendTxt;
    public string loverTxt;

    public Dialogue(string playerTxt, string motherTxt, string friendTxt, string loverTxt)
    {
        this.playerTxt = playerTxt;
        this.motherTxt = motherTxt;
        this.friendTxt = friendTxt;
        this.loverTxt = loverTxt;
    }
}

public class DialogueDisplay : MonoBehaviour
{
    private GameObject playerChat;
    private Text playerText;
    private GameObject motherChat;
    private Text motherText;
    private GameObject friendChat;
    private Text friendText;
    private GameObject loverChat;
    private Text loverText;
    private Text dateText;
    [SerializeField] private AudioSource Music;
    [SerializeField] private float volumeDelta;
    private Date date;
    
    // indexed by number of clicks
    public List<Dialogue> dialogues = new List<Dialogue>();
    public int currentStep;
    public List<Sprite> newspapers = new List<Sprite>();
    public SpriteRenderer bg;
    public SpriteRenderer bbg;
    
    // singleton
    private static DialogueDisplay _instance;

    public static DialogueDisplay Instance()
    {
        if (_instance == null)
        {
            GameObject dd = new GameObject();
            dd.AddComponent<DialogueDisplay>();
            _instance = dd.GetComponent<DialogueDisplay>();
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
        dateText = GameObject.Find("DateText").GetComponent<Text>();
        currentStep = 0;
        playerChat.SetActive(false);
        motherChat.SetActive(false);
        friendChat.SetActive(false);
        loverChat.SetActive(false);
        dialogues.Add(new Dialogue(null, null, null, null));
        dialogues.Add(new Dialogue(null, "孩子，人生要高瞻远瞩，也要精打细算。", null, null));
        dialogues.Add(new Dialogue(null, null, "好兄弟，大家都在下海，我也要辞职去创业了。", "我在家乡当个老师也挺好，我等着你！"));
        dialogues.Add(new Dialogue(null, null, "我搞了个服装厂，要慢慢走上正轨了。", null));
        dialogues.Add(new Dialogue(null, null, null, "想你......"));
        dialogues.Add(new Dialogue(null, "不用担心家里，偶尔寄个信回来就好。", null, null));
        dialogues.Add(new Dialogue(null, "你爸烦，天天唠叨你不回家，别理他啊。", null, null));
        dialogues.Add(new Dialogue(null, null, "最近亏了点儿钱......没事，不多！不多！", null));
        dialogues.Add(new Dialogue(null, null, null, "我用攒起来的工资给买了两台BP机，一台给你......"));
        dialogues.Add(new Dialogue(null, null, null, "哎，评职称轮不到年轻教师。"));
        dialogues.Add(new Dialogue(null, "最近你爸老是胸口疼，你在大城市，给他弄点儿外国药回来吧。", null, null));
        dialogues.Add(new Dialogue(null, null, null, "想着你......"));
        dialogues.Add(new Dialogue(null, null, "大家都开玩笑，说再这样下去厂子就发不起工资啦。", null));
        dialogues.Add(new Dialogue(null, "最近看个病是真不容易啊......", null, null));
        dialogues.Add(new Dialogue(null, null, null, "亲爱的，我等不下去了，我们结婚好吗？"));
        dialogues.Add(new Dialogue("❤", "要好好对她！像你爸对我那样！", "手头紧，只能送兄弟你一台二手小彩电当贺礼啦！", "❤"));
        dialogues.Add(new Dialogue(null, null, "兄弟，可能是沾你的喜气，我拿到了一笔政府的大单子！", "你已经离它很近了！不用担心你爸的身体，我会替你照顾好他！"));
        dialogues.Add(new Dialogue(null, "孩子，你继续放心地去，去抓住它！", null, null));
        dialogues.Add(new Dialogue("终于就在我眼前了！", null, null, null));
        dialogues.Add(new Dialogue(null, "瞒了你这么久......", "兄弟，需要帮忙尽管跟我说。", "亲爱的，有个坏消息......"));
        date = new Date(1990, 6);
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
            //停止音乐
            GameObject.FindWithTag("MainCamera").GetComponent<AudioSource>().Stop();
            //故障白噪声
            GameObject.Find("EffectManager").GetComponent<SoundEffectManager>().PlayNextEffect(1);
            Music = GameObject.Find("EffectManager").GetComponent<AudioSource>();
            float timedelta = 2 / Time.deltaTime;
            if (timedelta > 0)
                volumeDelta = (0.5f - Music.volume) / timedelta;
            else
            {
                volumeDelta = (0.5f - Music.volume);
            }
            //载入下一个场景
            GameObject.Find("LevelLoader").GetComponent<LevelLoader>().LoadNextLevel();
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

    public void Display(Dialogue dialogue)
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
    }
}
