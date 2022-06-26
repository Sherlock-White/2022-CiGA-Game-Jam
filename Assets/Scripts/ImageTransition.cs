using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageTransition : MonoBehaviour
{
    public SpriteRenderer bg;

    public SpriteRenderer bbg;

    public List<Sprite> newspapers;

    public int currentStep;
    
    // Start is called before the first frame update
    void Start()
    {
        currentStep = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private IEnumerator ChangeBackground ()
    {
        while (true)
        {
            float seconds = 2f;
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
            currentStep = (currentStep + 1) % newspapers.Count;
        }
    }
}
