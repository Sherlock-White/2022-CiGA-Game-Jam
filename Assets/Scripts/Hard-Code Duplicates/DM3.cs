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
    public string motherTxt;
    public string friendTxt;
    public string loverTxt;

    public D3(string playerTxt, string motherTxt, string friendTxt, string loverTxt)
    {
        this.playerTxt = playerTxt;
        this.motherTxt = motherTxt;
        this.friendTxt = friendTxt;
        this.motherTxt = motherTxt;
    }
}

public class DM3 : MonoBehaviour
{
    private GameObject playerChat;
    private Text playerText;
    private GameObject daugnterChat;
    private Text daugnterText;
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
        daugnterChat = GameObject.Find("mother").transform.Find("Dialogue").gameObject;
        daugnterText = daugnterChat.transform.Find("Panel/Text").GetComponent<Text>();
        loverChat = GameObject.Find("lover").transform.Find("Dialogue").gameObject;
        loverText = loverChat.transform.Find("Panel/Text").GetComponent<Text>();
        friendChat = GameObject.Find("friend").transform.Find("Dialogue").gameObject;
        friendText = friendChat.transform.Find("Panel/Text").GetComponent<Text>();
        dateText = GameObject.Find("DateText").GetComponent<Text>();
        currentStep = 0;
        playerChat.SetActive(false);
        daugnterChat.SetActive(false);
        friendChat.SetActive(false);
        loverChat.SetActive(false);
        dialogues.Add(new D3(null, null, null, null));
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
        daugnterChat.SetActive(false);
        if (dialogue.motherTxt != null)
        {
            daugnterChat.SetActive(true);
            daugnterText.text = dialogue.motherTxt;
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
