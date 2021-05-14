﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInterfaceController : MonoBehaviour
{
    public void EnableObject(GameObject obj)
    {

        obj.SetActive(true);
    }

    public void DisableObject(GameObject obj)
    {
        obj.SetActive(false);
    }

    public void QuitGame()
    {
        print("Quiting game..");
        Application.Quit();
    }
}
