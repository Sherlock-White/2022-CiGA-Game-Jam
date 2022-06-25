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


public class Hero : MonoBehaviour
{
    //主角动画机
    private Animator playerAnimator;

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

    //更新角色的朝向
    void UpdatePlayer()
    {
        playerAnimator.Play(_direction.ToString());
    }

    //��ʱд����֮�������������ȡ
    public float xOffset = 225;
    public float yOffset = 113;
    public float zOffset;



    //���ƽ�ɫ�ص�ǰ�����ƶ�
    public void MovePlayer()
    {
        switch (_direction)
        {
            case DIRECTION.LEFT_UP:
                gameObject.transform.Translate(new Vector3(-xOffset, yOffset, 0));
                break;
            case DIRECTION.LEFT_DOWN:
                gameObject.transform.Translate(new Vector3(-xOffset, -yOffset, 0));
                break;
            case DIRECTION.RIGHT_UP:
                gameObject.transform.Translate(new Vector3(xOffset, yOffset, 0));
                break;
            case DIRECTION.RIGHT_DOWN:
                gameObject.transform.Translate(new Vector3(xOffset, -yOffset, 0));
                break;
        }
    }

    void Start()
    {
        playerAnimator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
