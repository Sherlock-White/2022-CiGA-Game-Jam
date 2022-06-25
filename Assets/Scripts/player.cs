using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DIRECTION
{
    LEFT_UP = 0,    //�I
    LEFT_DOWN = 1,  //�L
    RIGHT_UP = 2,   //�J
    RIGHT_DOWN = 3, //�K
}


public class Player : MonoBehaviour
{
    //����
    public GameObject player;
    public GameObject playerLeftUp;
    public GameObject playerLeftDown;
    public GameObject playerRightUp;
    public GameObject playerRightDown;

    //���ﳯ��
    private DIRECTION _direction = DIRECTION.RIGHT_DOWN;

    //���ƽ�ɫת��
    public void ToLeftUp()
    {
        _direction = DIRECTION.LEFT_UP;
        UpdatePlayer();
    }
    public void ToLeftDown()
    {
        _direction = DIRECTION.LEFT_DOWN;
        UpdatePlayer();
    }
    public void ToRightUp()
    {
        _direction = DIRECTION.RIGHT_UP;
        UpdatePlayer();
    }
    public void ToRightDown()
    {
        _direction = DIRECTION.RIGHT_DOWN;
        UpdatePlayer();
    }

    //���½�ɫ�ĳ���
    void UpdatePlayer()
    {
        playerLeftUp.SetActive(false);
        playerLeftDown.SetActive(false);
        playerRightUp.SetActive(false);
        playerRightDown.SetActive(false);
        switch (_direction)
        {
            case DIRECTION.LEFT_UP:
                playerLeftUp.SetActive(true);
                break;
            case DIRECTION.LEFT_DOWN:
                playerLeftDown.SetActive(true);
                break;
            case DIRECTION.RIGHT_UP:
                playerRightUp.SetActive(true);
                break;
            case DIRECTION.RIGHT_DOWN:
                playerRightDown.SetActive(true);
                break;
        }
    }

    //��ʱд����֮�������������ȡ
    private float xOffset = (float)230;
    private float yOffset = (float)120;
    private float zOffset = (float)293;



    //���ƽ�ɫ�ص�ǰ�����ƶ�
    public void MovePlayer()
    {
        switch (_direction)
        {
            case DIRECTION.LEFT_UP:
                player.transform.Translate(new Vector3(-xOffset, yOffset, 0));
                break;
            case DIRECTION.LEFT_DOWN:
                player.transform.Translate(new Vector3(-xOffset, -yOffset, 0));
                break;
            case DIRECTION.RIGHT_UP:
                player.transform.Translate(new Vector3(xOffset, yOffset, 0));
                break;
            case DIRECTION.RIGHT_DOWN:
                player.transform.Translate(new Vector3(xOffset, -yOffset, 0));
                break;
        }
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
