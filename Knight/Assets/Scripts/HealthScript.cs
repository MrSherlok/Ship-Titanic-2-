
using System.Collections;
using UnityEngine.UI;

using UnityEngine;

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

    /// <summary>
    /// Наносим урон и проверяем должен ли объект быть уничтожен
    /// </summary>
    /// <param name="damageCount"></param>
    private Image deathBG;
    public void Start()
    {
 
        deathBG = GameObject.Find("Dead").GetComponent<Image>();
        //reload.enabled = false;
        deathBG.enabled = false;
    }
    public void Damage(int damageCount)
    {
        hp -= damageCount;

        if (hp <= 0)
        {
            // Смерть!
            // Destroy(gameObject);
           
            
            GetComponent<Animator>().SetBool("Die", true);
            GetComponent<Animator>().SetBool("Run", false);

            if (gameObject.tag == "Character")
            {
                Invoke("Pause", 1f);
                //Time.timeScale = 0;

                //reload.enabled = true;
                deathBG.enabled = true;

            }
            if (gameObject.tag == "Enemy")
            {
                gameObject.GetComponent<Collider2D>().enabled = false;
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
                if (otherCollider.gameObject.tag != "Stone" && otherCollider.gameObject.tag != "Enemy")
                {
                    Destroy(shot.gameObject); // Всегда цельтесь в игровой объект, иначе вы просто удалите скрипт.      }
                }

                if(otherCollider.gameObject.tag == "Enemy" )
                {
                    otherCollider.GetComponent<Animator>().SetBool("Die", true);
                    otherCollider.GetComponent<Animator>().SetBool("Run", false);
                    Destroy(gameObject, 10f);
                }
            }
        }
    }
}