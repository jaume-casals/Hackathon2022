using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScene(int index)
	{
        Debug.Log("a");
		SceneManager.LoadScene (index);
	}

	public void Exit()
	{
		Application.Quit ();
	}
}
