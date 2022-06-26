using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;

    public float transitionTime = 0f;

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
        //Э�̷�ʽ
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        //����ת������
        transition.SetTrigger("Start");
        //�ӳ����볡����ֹ����
        yield return new WaitForSeconds(transitionTime);
        //���볡��
        SceneManager.LoadScene(levelIndex);

    }
}
