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
        dialogues.Add(new D2(null, "���ӣ�û��ϵ����ͷ������Ҳδ���������µķ羰��", "������Ǯ�������ˣ����ֵܿ���ʲô���Ҹ��㣡������ߣ�", "��֪���ģ��Һ��趼һֱ�������.....", null));
        dialogues.Add(new D2(null, null, null, null, null));
        dialogues.Add(new D2(null, "���£����°������������˾����������ᡣ", null, "�Ϲ�����Ҫ���ְ���......", null));
        dialogues.Add(new D2(null, null, "�ڼ�����һ������ף��µĻ�ϣ��������˸�Ů��......", null, null));
        dialogues.Add(new D2(null, "������ȥ������յ�ֽ���������ӱ�����Ů����", null, "�㿴�����ӳ��������㣡", "��Ů�������ڳ����У��������ۣ�"));
        dialogues.Add(new D2(null, null, "�ﱸ�������۰����㵱������ô�����ģ�", "����˯��̤ʵ���������ǰ�ҹ�ޡ�", "�������أ�"));
        dialogues.Add(new D2(null, "��ϱ�����������簮���ӣ��⻹������", "��������Ҳ������ʽ�����ʺ�����", null, "���������أ�"));
        dialogues.Add(new D2(null, null, null, "�Ϲ����������ڻ����������", "��...�֣�"));
        dialogues.Add(new D2("��", "�⺢����˵Щʲô��", "��", "��", "�ۿ��ۿᣡ"));
        dialogues.Add(new D2(null, null, "С������ô�ɰ�����Ҫ��ҪҲ��һ����", null, "�ְ֣���ߣ�"));
        dialogues.Add(new D2(null, "��Ҳ�������ˣ���Ů��������������", null, "���Ů����ѧ����������ͷ�ۡ�", "���ԣ����Է��ѣ�"));
        dialogues.Add(new D2(null, null, "�Ҽ��ǿ���˵ʲô�������¹��Ҫ���ˣ������ɡ�", null, "�������ۣ��ְ֣���Ҫ�ߣ�"));
        dialogues.Add(new D2(null, "����Ҳ��������������ҵ�Ǯ�������ǡ�", null, "����Խ��Խ���ˣ��Ǹ����������", null));
        dialogues.Add(new D2(null, null, null, "�����Ӻͱ���ȷʵ��Щ�ۣ����ͷ�۵�ʱ��Ҳ���ˡ�", "�ְ֣���Ҫ��̫���ˣ�"));
        dialogues.Add(new D2(null, "������������ҪǨ��������Ͳ㣿", "������ò�̫ƽ�����ҵ����뷨�ӣ��ó��ӱ���ˡ�", null, null));
        dialogues.Add(new D2("��Щ����...", null, "�Ҽ��ǿ�������ҳ��ܣ�˵��æ�������ؼ�......", "����������......", "�·��ӣ�"));
        dialogues.Add(new D2(null, "�����ε�����ˡ�������֣�����֮���һ���û�ε�������", "������ǵ������ǽ���Σ���ģ��ҵĳ���Ҳ����......", "��������ҲҪע�ⰲȫ��", "���𣡵��������ְ֣�"));
        dialogues.Add(new D2("......", null, "�ڰ���", "��ϧ����û���ɰ��˻�......", "�ְ֣��ô��ѩ��������ȥ������ѩ����"));
        dialogues.Add(new D2("��Щ�꣬�ҵ�������Щʲô��", null, null, "�װ���......", "�ְ֣��㲻������������㴷������"));
        dialogues.Add(new D2("��һ�У�ֵ����", null, null, null, null));
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
