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

    private List<GameObject> _enemyArray = new List<GameObject>();

    private int hpHeart = 2;
    private SpriteRenderer heartRenderer;
    private Rigidbody2D heartRb;
    private SpriteRenderer heart1Renderer;
    private Rigidbody2D heart1Rb;
    private Vector3 pointPoz;

    public void Start()
    {
        _enemyArray.Add((GameObject)GameObject.Find("Enemy_Prefab"));
        _enemyArray.Add((GameObject)GameObject.Find("Enemy_Prefab (1)"));
        _enemyArray.Add((GameObject)GameObject.Find("Enemy_Prefab (2)"));
        _enemyArray.Add((GameObject)GameObject.Find("Enemy_Prefab (3)"));
        _enemyArray.Add((GameObject)GameObject.Find("Enemy_Prefab (4)"));

        reload = GameObject.Find("Reload").GetComponent<Image>();
        deathBG = GameObject.Find("Dead")/*.GetComponent<Image>()*/;
        reload.enabled = false;
        deathBG.GetComponent<Image>().enabled = false;
        deathBG.GetComponent<Animator>().enabled = false;

        GameObject.FindWithTag("Foregraund").GetComponent<ScrollingScript>().enabled = true;

        heartRenderer = GameObject.Find("heart").GetComponent<SpriteRenderer>();
        heartRenderer.enabled = false;

        heartRb = GameObject.Find("heart").GetComponent<Rigidbody2D>();
        heartRb.gravityScale = 0;

        heart1Renderer = GameObject.Find("heart(1)").GetComponent<SpriteRenderer>();
        heart1Renderer.enabled = false;

        heart1Rb = GameObject.Find("heart(1)").GetComponent<Rigidbody2D>();
        heart1Rb.gravityScale = 0;

        


    }

    /// <summary>
    /// Наносим урон и проверяем должен ли объект быть уничтожен
    /// </summary>
    /// <param name="damageCount"></param>
    public void Damage(int damageCount)
    {
        hp -= damageCount;

        if (gameObject.tag == "Character")
        {
            pointPoz = GameObject.Find("heartPoint").transform.position;
            if (damageCount == 1)
            {
                GameObject.Find("heart").transform.position = pointPoz;
                heartRenderer.enabled = true;
                heartRb.gravityScale = 1;
                heartRb.AddForce(Vector2.up * 100);
                Debug.Log("it was");
            }  else
            {
                GameObject.Find("heart").transform.position = new Vector3(pointPoz.x+1, pointPoz.y, 0);
                GameObject.Find("heart(1)").transform.position = pointPoz;
                heartRenderer.enabled = true;
                heartRb.gravityScale = 1;
                heartRb.AddForce(Vector2.up * 100);
                heart1Renderer.enabled = true;
                heart1Rb.gravityScale = 1;
                heart1Rb.AddForce(Vector2.up * 100);
            }
            Invoke("HeartUnable", 1.5f);

        }

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
                for(int i = 0; i < 5; i++)
                {
                    _enemyArray[i].GetComponent<MoveScript>().speed.x = 0;

                }


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
    void HeartUnable()
    {

        heartRenderer.enabled = false;       
        heartRb.gravityScale = 0;        
        heart1Renderer.enabled = false;        
        heart1Rb.gravityScale = 0;
        

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
                if (otherCollider.gameObject.tag == "Arrow" && otherCollider.gameObject.tag != "Character") /*!= "Stone" && otherCollider.gameObject.tag != "Enemy" && otherCollider.gameObject.tag != "Character"*/
                {
                    Destroy(shot.gameObject); // Всегда цельтесь в игровой объект, иначе вы просто удалите скрипт.      }
                }

                if(otherCollider.gameObject.tag == "Enemy" )
                {
                    otherCollider.GetComponent<Animator>().SetBool("Die", true);
                    otherCollider.GetComponent<Animator>().SetBool("Run", false);
                    //Destroy(gameObject, 1f);
                }
            }
        }
    }
}