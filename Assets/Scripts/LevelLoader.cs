using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;

    public float transitionTime = 1f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            LoadNextLevel();
        }
    }
    
    public void LoadNextLevel()
    {
        //协程方式
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        //播放转场动画
        transition.SetTrigger("Start");
        //延迟载入场景防止覆盖
        yield return new WaitForSeconds(transitionTime);
        //载入场景
        SceneManager.LoadScene(levelIndex);

    }
}
