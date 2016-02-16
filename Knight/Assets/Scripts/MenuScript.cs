using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{

    private Image shootImage;
    private Image jumpImage;
    private Image pauseImage;
    //private Image backImage;
    private Text scoreImage;
    private Image voiceImage;
    private Image startImage;
    private Image firstHpIm;
    private Image secondHpIm;

    public Sprite voiseOnSprite;
    public Sprite voiseOffSprite;

    private bool canMute = true;


    void Start()
    {

        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        shootImage = GameObject.Find("Fire").GetComponent<Image>();
        jumpImage = GameObject.Find("Jump").GetComponent<Image>();
        pauseImage = GameObject.Find("Pause").GetComponent<Image>();
        //backImage = GameObject.Find("Reload").GetComponent<Image>();
        scoreImage = GameObject.Find("Score").GetComponent<Text>();
        voiceImage = GameObject.Find("Voise").GetComponent<Image>();
        startImage = GameObject.Find("Start").GetComponent<Image>();
        firstHpIm = GameObject.Find("Heart").GetComponent<Image>();
        secondHpIm = GameObject.Find("Heart2").GetComponent<Image>();

        //backImage.enabled = false;
        shootImage.enabled = false;
        jumpImage.enabled = false;
        pauseImage.enabled = false;
        scoreImage.enabled = false;
        firstHpIm.enabled = false;
        secondHpIm.enabled = false;
        startImage.enabled = true;
        voiceImage.enabled = true;

        Time.timeScale = 0;
    }

    public void StartButton()
    {
        shootImage.enabled = true;
        jumpImage.enabled = true;
        pauseImage.enabled = true;
        scoreImage.enabled = true;
        firstHpIm.enabled = true;
        secondHpIm.enabled = true;

        voiceImage.enabled = false;
        startImage.enabled = false;

        Time.timeScale = 1;

    }
    public void MusicUI()
    {
        canMute = !canMute;
        if (canMute)
        {
            AudioListener.pause = true;
            voiceImage.sprite = voiseOffSprite;
        }
        else
        {
            AudioListener.pause = false;
            voiceImage.sprite = voiseOnSprite;
        }
    }



}
