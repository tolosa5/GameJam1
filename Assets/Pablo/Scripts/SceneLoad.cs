using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneLoad
{
    public static string nextLVL;

    public static void LoadScene(string nameLvL)
    {
        nextLVL = nameLvL;
        SceneManager.LoadScene("Loading");
    }
}
