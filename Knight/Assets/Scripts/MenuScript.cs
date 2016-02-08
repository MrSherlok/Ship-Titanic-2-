using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour {

    private Image shootImage;
    private Image jumpImage;
    private Image pauseImage;
  //  private Image backImage;
    private Image scoreImage;
 //   private Image voiceImage;
    private Image startImage;
    private Image firstHpIm;
    private Image secondHpIm;


    void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        shootImage = GameObject.Find("Fire").GetComponent<Image>();
        jumpImage = GameObject.Find("Jump").GetComponent<Image>();
        pauseImage = GameObject.Find("Pause").GetComponent<Image>();
     //   backImage = GameObject.Find("firstHpImage").GetComponent<Image>();
      //  scoreImage = GameObject.Find("Score").GetComponent<Image>();
     //   voiceImage = GameObject.Find("firstHpImage").GetComponent<Image>();
        startImage = GameObject.Find("Start").GetComponent<Image>();
        firstHpIm = GameObject.Find("Heart").GetComponent<Image>();
        secondHpIm = GameObject.Find("Heart2").GetComponent<Image>();

        shootImage.enabled = false;
        jumpImage.enabled = false;
        pauseImage.enabled = false;
      //  scoreImage.enabled = false;
        firstHpIm.enabled = false;
        secondHpIm.enabled = false;

        startImage.enabled = true;

        Time.timeScale = 0;
    }

    public void StartButton()
    {
        shootImage.enabled = true;
        jumpImage.enabled = true;
        pauseImage.enabled = true;
     //   scoreImage.enabled = true;
        firstHpIm.enabled = true;
        secondHpIm.enabled = true;

        startImage.enabled = false;

        Time.timeScale = 1;

    }

}
