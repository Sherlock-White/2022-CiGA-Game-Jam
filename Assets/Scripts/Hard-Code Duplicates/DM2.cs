using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditorInternal;
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
        dialogues.Add(new D2(null, null, null, null, null));
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
