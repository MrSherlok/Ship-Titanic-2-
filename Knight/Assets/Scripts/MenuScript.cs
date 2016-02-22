using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{

    private Image shootImage;
    private Image secondShootImage;
    private Image jumpImage;
    private Image pauseImage;
    //private Image backImage;
    private Text scoreImage;
    private Image voiceImage;
    private Image authorsImage;
    private Image startImage;
    private Image firstHpIm;
    private Image secondHpIm;
    private Image authorImage;
    private Image backToGameImage;


    public Sprite voiseOnSprite;
    public Sprite voiseOffSprite;

    private bool canMute = true;


    void Start()
    {

        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        secondShootImage = GameObject.Find("Fire1").GetComponent<Image>();
        authorImage = GameObject.Find("Author").GetComponent<Image>();
        backToGameImage = GameObject.Find("BackToGame").GetComponent<Image>();
        shootImage = GameObject.Find("Fire").GetComponent<Image>();
        jumpImage = GameObject.Find("Jump").GetComponent<Image>();
        pauseImage = GameObject.Find("Pause").GetComponent<Image>();
        //backImage = GameObject.Find("Reload").GetComponent<Image>();
        scoreImage = GameObject.Find("Score").GetComponent<Text>();
        voiceImage = GameObject.Find("Voise").GetComponent<Image>();
        authorsImage = GameObject.Find("Authors").GetComponent<Image>();
        startImage = GameObject.Find("Start").GetComponent<Image>();
        firstHpIm = GameObject.Find("Heart").GetComponent<Image>();
        secondHpIm = GameObject.Find("Heart2").GetComponent<Image>();

        authorImage.enabled = false;
        backToGameImage.enabled = false;
        //backImage.enabled = false;
        shootImage.enabled = false;
        secondShootImage.enabled = false;
        jumpImage.enabled = false;
        pauseImage.enabled = false;
        scoreImage.enabled = false;
        firstHpIm.enabled = false;
        secondHpIm.enabled = false;
        startImage.enabled = true;
        voiceImage.enabled = true;
        authorsImage.enabled = true;
        GameObject.Find("Tap to start").GetComponent<SpriteRenderer>().enabled = true;

        Time.timeScale = 0;
    }

    public void StartButton()
    {
        GameObject.Find("Character_Global_CTRL").GetComponent<Animator>().SetBool("Idle", false);
        GameObject.Find("Character_Global_CTRL").GetComponent<Animator>().SetBool("Run", true);
        shootImage.enabled = true;
        secondShootImage.enabled = true;
        jumpImage.enabled = true;
        pauseImage.enabled = true;
        scoreImage.enabled = true;
        firstHpIm.enabled = true;
        secondHpIm.enabled = true;

        voiceImage.enabled = false;
        startImage.enabled = false;
        authorsImage.enabled = false;
        GameObject.Find("Tap to start").GetComponent<SpriteRenderer>().enabled = false;

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

     public void LoadAuthors()
    {
        authorImage.enabled = true;
        backToGameImage.enabled = true;

        secondShootImage.enabled = false;
        shootImage.enabled = false;
        jumpImage.enabled = false;
        pauseImage.enabled = false;
        scoreImage.enabled = false;
        firstHpIm.enabled = false;
        secondHpIm.enabled = false;
        voiceImage.enabled = false;
        startImage.enabled = false;
        authorsImage.enabled = false;
    }


    public void BackToMenu()
    {
        authorImage.enabled = false;
        backToGameImage.enabled = false;

        secondShootImage.enabled = false;
        shootImage.enabled = false;
        jumpImage.enabled = false;
        pauseImage.enabled = false;
        scoreImage.enabled = false;
        firstHpIm.enabled = false;
        secondHpIm.enabled = false;

        voiceImage.enabled = true;
        startImage.enabled = true;
        authorsImage.enabled = true;

    }


}
