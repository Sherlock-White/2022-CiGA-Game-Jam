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


public class Player : MonoBehaviour{
    public GameObject player;
    public GameObject playerLeftUp;
    public GameObject playerLeftDown;
    public GameObject playerRightUp;
    public GameObject playerRightDown;
    //人物朝向
    private DIRECTION _direction = DIRECTION.RIGHT_DOWN;

    //控制角色转向
    void ToLeftUp(){
        _direction = DIRECTION.LEFT_UP;
        UpdatePlayer();
    }
    void ToLeftDown(){
        _direction = DIRECTION.LEFT_DOWN;
        UpdatePlayer();
    }
    void ToRightUp(){
        _direction = DIRECTION.RIGHT_UP;
        UpdatePlayer();
    }
    void ToRightDown(){
        _direction = DIRECTION.RIGHT_DOWN;
        UpdatePlayer();
    }

    void UpdatePlayer(){
        playerLeftUp.SetActive(false);
        playerLeftDown.SetActive(false);
        playerRightUp.SetActive(false);
        playerRightDown.SetActive(false);
        switch (_direction){
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

    //控制角色沿当前方向移动
    void MovePlayer(float xOffset,float yOffset){
        Transform _transform = GetComponent<Transform>();
        switch (_direction){
            case DIRECTION.LEFT_UP:
                player.transform.Translate(new UnityEngine.Vector3(_transform.position.x - xOffset,_transform.position.y + yOffset,_transform.position.z));
                break;
            case DIRECTION.LEFT_DOWN:
                player.transform.Translate(new UnityEngine.Vector3(_transform.position.x - xOffset,_transform.position.y - yOffset,_transform.position.z));
                break;
            case DIRECTION.RIGHT_UP:
                player.transform.Translate(new UnityEngine.Vector3(_transform.position.x + xOffset,_transform.position.y + yOffset,_transform.position.z));
                break;
            case DIRECTION.RIGHT_DOWN:
                player.transform.Translate(new UnityEngine.Vector3(_transform.position.x + xOffset,_transform.position.y - yOffset,_transform.position.z));
                break;
        }

    }

    void Start(){

    }

    // Update is called once per frame
    void Update(){
        
    }
}
