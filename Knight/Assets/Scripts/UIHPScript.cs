using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Handle hitpoints and damages
/// </summary>
public class UIHPScript : MonoBehaviour
{
    /// Всего хитпоинтов
    private int hpUI;
    private Image firstHpImage;
    private Image secondHpImage;
    public Sprite fullHpSprite;
    public Sprite emptyHpSprite;

    void Start()
    {
        firstHpImage = GameObject.Find("Heart").GetComponent<Image>();
        secondHpImage = GameObject.Find("Heart2").GetComponent<Image>();
    }
    void Update()
    {
        hpUI = GameObject.FindWithTag("Character").GetComponent<HealthScript>().hp;
        if (hpUI > 1)
        {
            secondHpImage.sprite = fullHpSprite;
        }
        else
        {
            secondHpImage.sprite = emptyHpSprite;
        }
        if (hpUI > 0)
        {
            firstHpImage.sprite = fullHpSprite;
        }
        else
        {
            firstHpImage.sprite = emptyHpSprite;
        }

    }
}