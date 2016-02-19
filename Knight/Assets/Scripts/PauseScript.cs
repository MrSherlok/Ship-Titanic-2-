using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour {
	private bool isPause = false;
    private Button _fire;
    private Button _jump;
    private Image pauseIm;
    public Sprite onPause;
    public Sprite offPause;

void Start()
    {
        pauseIm = GameObject.Find("Pause").GetComponent<Image>();
        _fire = GameObject.Find("Fire").GetComponent<Button>();
        _jump = GameObject.Find("Jump").GetComponent<Button>();
    }

    public void Pause () {
		isPause = !isPause;
		if (isPause) {
            pauseIm.sprite = onPause;
			Time.timeScale = 0;
            _fire.enabled = false;
            _jump.enabled = false;
        }


        else {
            pauseIm.sprite = offPause;
            _fire.enabled = true;
            _jump.enabled = true;
            Time.timeScale = 1; 
	
		}

	}
    public void Reload()
    {
        Application.LoadLevel("tryMe");
        Time.timeScale = 1;
    }
}
