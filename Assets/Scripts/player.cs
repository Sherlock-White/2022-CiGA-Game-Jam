using System.Numerics;
using System.Globalization;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum DIRECTION {
    LEFT_UP = 0,    //↖
    LEFT_DOWN = 1,  //↙
    RIGHT_UP = 2,   //↗
    RIGHT_DOWN = 3, //↘
}


public class player : MonoBehaviour{
    //人物朝向
    private DIRECTION _direction = DIRECTION.RIGHT_DOWN;
    //人物位置
    private Transform _transform;
    //正面/背面
    private string _type = "A";
    //水平方向移动距离
    public float xOffset;
    //垂直方向移动距离
    public float yOffset;

    //控制角色转向
    void toLeftUp(){
        _direction = DIRECTION.LEFT_UP;
        _type = "B";
    }
    void toLeftDown(){
        _direction = DIRECTION.LEFT_DOWN;
        _type = "A";
    }
    void toRightUp(){
        _direction = DIRECTION.RIGHT_UP;
        _type = "B";
    }
    void toRightDown(){
        _direction = DIRECTION.RIGHT_DOWN;
        _type = "A";
    }

    //控制角色沿当前方向移动
    void move(){
        switch (_direction){
            case DIRECTION.LEFT_UP:
                _transform.Translate(new UnityEngine.Vector3(_transform.position.x - xOffset,_transform.position.y + yOffset,_transform.position.z));
                break;
            case DIRECTION.LEFT_DOWN:
                _transform.Translate(new UnityEngine.Vector3(_transform.position.x - xOffset,_transform.position.y - yOffset,_transform.position.z));
                break;
            case DIRECTION.RIGHT_UP:
                _transform.Translate(new UnityEngine.Vector3(_transform.position.x + xOffset,_transform.position.y + yOffset,_transform.position.z));
                break;
            case DIRECTION.RIGHT_DOWN:
                _transform.Translate(new UnityEngine.Vector3(_transform.position.x + xOffset,_transform.position.y - yOffset,_transform.position.z));
                break;
        }

    }

    void Start(){
        //初始化位置
        _transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update(){
        
    }
}
