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
        dialogues.Add(new D3("�ҵ��׸��������ߣ�ǰ�������ˣ�", null, null, null));
        dialogues.Add(new D3(null, "�װ��ģ����ܲ��ܻؼҿ�����", "�ְ֣��һᵯ��������", null));
        dialogues.Add(new D3(null, "���Ƕ���ʮ���ˣ�û�ж���ȥ�ӻ���......", "�Ҳ���̫����������Ҫ�����ּң�", "�þ�û����ϵ���ˣ���Ƿ��Ǯ̫����......"));
        dialogues.Add(new D3("......", "�Ҳ�����ָ���㣡��Ҳ������㳳�ܣ�", "�ְ����������������󻵵���", null));
        dialogues.Add(new D3(null, "������������ʮ��ǰ��������BP����ʱ��......", "�����㣡", "���ӡ����ӣ������Ķ����ˣ��Һõ���û�����ӡ�"));
        dialogues.Add(new D3(null, null, "������費����......", "�ܲ����ٽ��ҵ����"));
        dialogues.Add(new D3("���Ѿ���Ŭ���������ˣ����Һ��񲻹�һ�е��ߵ�̫Զ�ˡ�", "����������ҲӦ���������������������ұ���֧������", null, null));
        dialogues.Add(new D3("����Ŭ�������ߣ���һ�к�������ǰ��......", null, "�ְ֣�����Ҫ���¼������������ܸ�������", null));
        dialogues.Add(new D3(null, "�����Щƣ���������ǿ��ϵö��˰ɡ�", null, null));
        dialogues.Add(new D3("���ǵȵ���......", "ҽ��˵��һֱ������̫���ˡ��ҿ���ҪסԺһ��ʱ��......", "�֣����еĵ�һ�μҳ��ᣬ���ܻ�����", "�����ծ�Ĵߵý����ҵ�ȥ����ܱܷ�ͷ���ټ���......"));
        dialogues.Add(new D3(null, null, "�֣����淳������ң����Ѿ�������С�����ˣ�", null));
        dialogues.Add(new D3("......", "�һ�Ȼ���ã���Щ�������ҹ��ò����Ҹ���", null, null));
        dialogues.Add(new D3(null, "�Ҳ�������Ϊ��ЩС�³����ˣ���������......", "�ҵ�Ȼ�Ǹ�����������", null));
        dialogues.Add(new D3("�ȵ��ң�", null, null, null));
        dialogues.Add(new D3(null, null, null, null));
        dialogues.Add(new D3("Ϊʲô��������", null, null, null));
        dialogues.Add(new D3(null, null, null, null));
        dialogues.Add(new D3("Ҫ��β��ܻص���ȥ���ص�һ��ѡ��Ŀ�ͷ��", null, null, null));
        dialogues.Add(new D3(null, null, "�֣����Ⱳ�Ӳ�������һ��µµ��Ϊ����Ҫȥ׷Ѱ�ҵļ�ֵ��", null));
        dialogues.Add(new D3("�����һ����Ļ�......", null, null, null));
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
