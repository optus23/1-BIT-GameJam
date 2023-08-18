using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackScreenFade : MonoBehaviour
{
    FadeObject fadeObject;

    [SerializeField]
    bool callOnce = false, canSetFalse = false;
    // Start is called before the first frame update
    void Start()
    {
        fadeObject = GetComponent<FadeObject>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.A)) { SceneTransition(); }

        if(callOnce && !fadeObject.fadeIn) { SceneTransition(); }

        if (this.fadeObject.fadeOut == false && canSetFalse)
        {
            gameObject.SetActive(false);
        }
    }

    public void SceneTransition()
    {
        if (!callOnce)
        {
            fadeObject.FadeInObject();
            callOnce = true;
        }

        if (!fadeObject.fadeIn && !canSetFalse)
        {
            fadeObject.FadeOutObject();
            canSetFalse = true;
        }
    }
}
