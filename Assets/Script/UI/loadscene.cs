using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class loadscene : MonoBehaviour {

	
	public void loadlewel (string name)
    {
        Time.timeScale = 1f;
        StartCoroutine(LoadAsynchronusly(name));
	}

     IEnumerator LoadAsynchronusly (string name)
     {
        AsyncOperation op = SceneManager.LoadSceneAsync(name);

        while(!op.isDone)
        {

            yield return null;

        }
    }

    public void Exit()
    {
        Application.Quit();
        Debug.Log("Exit");
    }
}
