using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

/// <summary>
/// Handle hitpoints and damages
/// </summary>
public class HealthScript : MonoBehaviour
{
    /// <summary>
    /// Всего хитпоинтов
    /// </summary>
    public int hp = 1;

    /// <summary>
    /// Враг или игрок?
    /// </summary>
    public bool isEnemy = true;
    private Image reload;
    private GameObject deathBG;

    public void Start()
    {
        reload = GameObject.Find("Reload").GetComponent<Image>();
        deathBG = GameObject.Find("Dead")/*.GetComponent<Image>()*/;
        reload.enabled = false;
        deathBG.GetComponent<Image>().enabled = false;
        deathBG.GetComponent<Animator>().enabled = false;

        GameObject.FindWithTag("Foregraund").GetComponent<ScrollingScript>().enabled = true;
    }

    /// <summary>
    /// Наносим урон и проверяем должен ли объект быть уничтожен
    /// </summary>
    /// <param name="damageCount"></param>
    public void Damage(int damageCount)
    {
        hp -= damageCount;

        if (hp <= 0)
        {
            // Смерть!
            // Destroy(gameObject);
           
            
            GetComponent<Animator>().SetBool("Die", true);
            GetComponent<Animator>().SetBool("Run", false);
            GetComponent<Animator>().SetBool("Shoot", false);
            GetComponent<Animator>().SetBool("Jump", false);

            if (gameObject.tag == "Character")
            {
                //Invoke("Pause", 0.4f);
                reload.enabled = true;
                deathBG.GetComponent<Image>().enabled = true;
                deathBG.GetComponent<Animator>().enabled = true;
                GameObject.FindWithTag("Foregraund").GetComponent<ScrollingScript>().enabled = false;

            }
            if (gameObject.tag == "Enemy")
            {

                //GetComponent<Animator>().SetBool("Die", true);
                //GetComponent<Animator>().SetBool("Run", false);

                gameObject.GetComponent<Collider2D>().enabled = false;
                gameObject.GetComponent<MoveScript>().speed.x = 0;
                //Destroy(gameObject, 5f);
            }


        }
    }

    void Pause()
    {
        Time.timeScale = 0;
    }

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        // Это выстрел?
        ShotScript shot = otherCollider.gameObject.GetComponent<ShotScript>();
        if (shot != null)
        {
            // Избегайте дружественного огня
            if (shot.isEnemyShot != isEnemy)
            {
                Damage(shot.damage);

                // Уничтожить выстрел
                if (otherCollider.gameObject.tag == "Arrow") /*!= "Stone" && otherCollider.gameObject.tag != "Enemy" && otherCollider.gameObject.tag != "Character"*/
                {
                    Destroy(shot.gameObject); // Всегда цельтесь в игровой объект, иначе вы просто удалите скрипт.      }
                }

                if(otherCollider.gameObject.tag == "Enemy" )
                {
                    otherCollider.GetComponent<Animator>().SetBool("Die", true);
                    otherCollider.GetComponent<Animator>().SetBool("Run", false);
                    Destroy(gameObject, 1f);
                }
            }
        }
    }
}