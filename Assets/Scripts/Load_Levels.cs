using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load_Levels : MonoBehaviour
{
    [SerializeField] private string text;

    public void Load()
    {
        SceneManager.LoadScene(text);
    }
}
