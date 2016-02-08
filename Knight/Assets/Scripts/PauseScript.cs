using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour {
	private bool isPause = false;
    private Button _fire;
    private Button _jump;


    void Start()
    {
        _fire = GameObject.Find("Fire").GetComponent<Button>();
        _jump = GameObject.Find("Jump").GetComponent<Button>();
    }

    public void Pause () {
		isPause = !isPause;
		if (isPause) {
			Time.timeScale = 0;
            _fire.enabled = false;
            _jump.enabled = false;
        }


        else {
			Time.timeScale = 1; 
	
		}

	}
    public void Reload()
    {
        Application.LoadLevel("tryMe");
        Time.timeScale = 1;
    }
}
