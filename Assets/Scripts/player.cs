using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DIRECTION {
    LEFT_UP = 0,    //↖
    LEFT_DOWN = 1,  //↙
    RIGHT_UP = 2,   //↗
    RIGHT_DOWN = 3, //↘
}


public class Player : MonoBehaviour{
    //主角动画机
    private Animator playerAnimator;

    //人物朝向
    private DIRECTION _direction = DIRECTION.RIGHT_DOWN;

    //控制角色转向
    public void ToLeftUp(){
        _direction = DIRECTION.LEFT_UP;
        UpdatePlayer();
    }
    public void ToLeftDown(){
        _direction = DIRECTION.LEFT_DOWN;
        UpdatePlayer();
    }
    public void ToRightUp(){
        _direction = DIRECTION.RIGHT_UP;
        UpdatePlayer();
    }
    public void ToRightDown(){
        _direction = DIRECTION.RIGHT_DOWN;
        UpdatePlayer();
    }

    //更新角色的朝向
    void UpdatePlayer(){
        playerAnimator.Play(_direction.ToString());
    }

    //暂时写死，之后根据配置来读取
    private float xOffset = 1;
    private float yOffset = 1;

    //控制角色沿当前方向移动
    public void MovePlayer(){
        switch (_direction)
        {
            case DIRECTION.LEFT_UP:
                gameObject.transform.Translate(new Vector3(-xOffset,yOffset,0));
                break;
            case DIRECTION.LEFT_DOWN:
                gameObject.transform.Translate(new Vector3(-xOffset,-yOffset,0));
                break;
            case DIRECTION.RIGHT_UP:
                gameObject.transform.Translate(new Vector3(xOffset,yOffset,0));
                break;
            case DIRECTION.RIGHT_DOWN:
                gameObject.transform.Translate(new Vector3(xOffset,-yOffset,0));
                break;
        }
    }

    void Start()
    {
        playerAnimator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update(){
        
    }
}
