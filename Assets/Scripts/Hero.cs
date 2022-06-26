using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DIRECTION
{
    LEFT_UP = 0,
    LEFT_DOWN = 1,
    RIGHT_UP = 2,
    RIGHT_DOWN = 3,
}


public class Hero : MonoBehaviour
{
    private Animator playerAnimator;
    private DIRECTION _direction = DIRECTION.RIGHT_DOWN;
    private Map map;
    
    private GameObject leftUp;
    private GameObject leftDown;
    private GameObject rightUp;
    private GameObject rightDown;

    private Canvas buttonCanvas;

    //当前主角所在坐标，从1到49，会比map中的数组索引大1
    private int curBoxId = 43;

    public GameObject mapObj;

    public float moveTime;

    //主角移动
    public void Move(DIRECTION dir)
    {
        _direction = dir;
        playerAnimator.Play(_direction.ToString());
        MovePlayer();
        UpdateDirBtn();
    }

    //刷新角色的图层，在middleground与foreg之间修改
    public void UpdatePlayerLayer()
    {
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        int[] list = {4,10,11,13,14,18,23,24,25,31,36,38,48,49};
        bool isContained = false;
        foreach(var item in list)
        {
            if(item == curBoxId)
            {
                isContained = true;
                break;
            }
        }
        if(isContained)
        {
            spriteRenderer.sortingLayerName = "foreground1";
            buttonCanvas.sortingLayerName = "foreground1";
        }
        else
        {
            spriteRenderer.sortingLayerName = "middleground";
            buttonCanvas.sortingLayerName = "middleground";
        }

        if(curBoxId == 23)
        {

        }
    }

    //刷新方向键的显示,只有从地图的下一有效路径中获得的值为正才显示；否则隐藏
    public void UpdateDirBtn()
    {
        int[] validMove = map.FindValidMove(curBoxId);
        leftUp.SetActive(validMove[0] > 0);
        leftDown.SetActive(validMove[1] > 0);
        rightUp.SetActive(validMove[2] > 0);
        rightDown.SetActive(validMove[3] > 0);
    }

    //角色移动
    public void MovePlayer()
    {
        //更新当前所在的CurBoxId
        Map map = mapObj.GetComponent<Map>();
        int[] validMove = map.FindValidMove(curBoxId);
        curBoxId = validMove[(int)_direction];

        UpdatePlayerLayer();

        //获取到目标点的偏移量
        float startX = gameObject.GetComponent<Transform>().position.x;
        //把坐标与角色锚点之间的110px偏差手动消除
        float startY = gameObject.GetComponent<Transform>().position.y - 110;
        GameObject box = GameObject.Find("map/node/" + curBoxId);
        float endX = box.GetComponent<Transform>().position.x;
        float endY = box.GetComponent<Transform>().position.y;
        float offsetX = endX - startX;
        float offsetY = endY - startY;
        StartCoroutine(MoveOverTime(new Vector3(offsetX, offsetY, 0), moveTime));
    }
    
    private IEnumerator MoveOverTime (Vector3 offset, float seconds)
    {
        float elapsedTime = 0;
        Vector3 startPos = transform.position;
        while (elapsedTime < seconds)
        {
            gameObject.transform.position = startPos + Vector3.Lerp(Vector3.zero, offset, (elapsedTime / seconds));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        gameObject.transform.position = startPos + offset;
    }

    void Start()
    {
        playerAnimator = gameObject.GetComponent<Animator>();
        map = mapObj.GetComponent<Map>();
        leftUp = GameObject.Find("hero/Buttons/leftUp");
        leftDown = GameObject.Find("hero/Buttons/leftDown");
        rightUp = GameObject.Find("hero/Buttons/rightUp");
        rightDown = GameObject.Find("hero/Buttons/rightDown");
        GameObject buttons = transform.Find("Buttons").gameObject;
        buttonCanvas = buttons.GetComponent<Canvas>();
        UpdateDirBtn();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
