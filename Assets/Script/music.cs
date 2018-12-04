using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class music : MonoBehaviour
{

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadSceneAsync("menu");
    }

}
