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
    //主角动画机
    private Animator playerAnimator;

    //主角方向
    private DIRECTION _direction = DIRECTION.RIGHT_DOWN;

    //当前主角所在坐标，从1到49，会比map中的数组索引大1
    private int curBoxId = 43;

    public GameObject mapObj;

    //主角转向
    public void ToLeftUp()
    {
        _direction = DIRECTION.LEFT_UP;
        playerAnimator.Play(_direction.ToString());
        MovePlayer();
        UpdateDirBtn();
    }
    public void ToLeftDown()
    {
        _direction = DIRECTION.LEFT_DOWN;
        playerAnimator.Play(_direction.ToString());
        MovePlayer();
        UpdateDirBtn();
    }
    public void ToRightUp()
    {
        _direction = DIRECTION.RIGHT_UP;
        playerAnimator.Play(_direction.ToString());
        MovePlayer();
        UpdateDirBtn();
    }
    public void ToRightDown()
    {
        _direction = DIRECTION.RIGHT_DOWN;
        playerAnimator.Play(_direction.ToString());
        MovePlayer();
        UpdateDirBtn();
    }

    //刷新方向键的显示,只有从地图的下一有效路径中获得的值为正才显示；否则隐藏
    public void UpdateDirBtn()
    {
        Map map = mapObj.GetComponent<Map>();
        int[] validMove = map.FindValidMove(curBoxId);
        GameObject leftUp = GameObject.Find("hero/Buttons/leftUp");
        GameObject leftDown = GameObject.Find("hero/Buttons/leftDown");
        GameObject rightUp = GameObject.Find("hero/Buttons/rightUp");
        GameObject rightDown = GameObject.Find("hero/Buttons/rightDown");
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

        //获取到目标点的偏移量
        float startX = gameObject.GetComponent<Transform>().position.x;
        //把坐标与角色锚点之间的120px偏差手动消除
        float startY = gameObject.GetComponent<Transform>().position.y - 120;
        GameObject box = GameObject.Find("map/" + curBoxId);
        float endX = box.GetComponent<Transform>().position.x;
        float endY = box.GetComponent<Transform>().position.y;
        float offsetX = endX - startX;
        float offsetY = endY - startY;
        gameObject.transform.Translate(new Vector3(offsetX, offsetY, 0));
    }

    void Start()
    {
        playerAnimator = gameObject.GetComponent<Animator>();
        UpdateDirBtn();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
