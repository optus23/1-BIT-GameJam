using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public Camera MainCamera;
    GameObject button;
    public GameObject credits;
    FadeObject fdObject;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = MainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.transform.gameObject.name == "StartBtn")
                {
                    button = hit.transform.gameObject;

                    foreach (Transform aChild in credits.transform)
                    {
                        aChild.gameObject.AddComponent<FadeObject>();
                        fdObject = aChild.GetComponent<FadeObject>();
                        fdObject.FadeOutObject();
                        if(fdObject.fadeOut == false)
                        {
                            aChild.gameObject.SetActive(false);
                        }
                    }

                    button.gameObject.AddComponent<FadeObject>();
                    fdObject = button.GetComponent<FadeObject>();
                    fdObject.FadeOutObject();
                    if (fdObject.fadeOut == false)
                    {
                        button.SetActive(false);
                    }
                    GameStateController.Instance.UpdateGameState(GameStateController.GameState.GAME);
                }

                else if (hit.transform.gameObject.name == "optus23")
                {
                    Application.OpenURL("https://optus23.github.io/");

                }

                else if (hit.transform.gameObject.name == "youis11")
                {
                    Application.OpenURL("https://youis11.github.io/");

                }
            }
        }
    }
}
