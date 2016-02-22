

using UnityEngine;
using UnityEngine.UI;



public class WeaponScript : MonoBehaviour
{
    public static bool isShooting = false;
    public Transform shotPrefab; //Префаб снаряда для стрельбы
    public float shootingRate = 0.5f; //Время перезарядки в секундах
    private float shootCooldown; //перезарядка

    private Image _shootImage;

    void Start()
    {
        _shootImage = GameObject.Find("Fire").GetComponent<Image>();
        shootCooldown = 0f;
    }

    //void FixedUpdate()
    //{
    //    if (shootCooldown < 0)
    //    {
    //        _canAttack = true;

    //    }
    //    if (shootCooldown > 0)
    //    {
    //        shootCooldown -= Time.deltaTime;
    //    }
    //}

    //--------------------------------
    // 3 - Стрельба из другого скрипта
    //--------------------------------

    /// <summary>
    /// Создайте новый снаряд, если это возможно
    /// </summary>


    public void Attack(/*bool isEnemy*/)
    {        
        if (toothless._canAttack && toothless.isGrounded)
        {
            _shootImage.enabled = false;
            isShooting = true;
            toothless._canAttack = false;
            //ShootAnim();            
            GameObject.Find("Character_Global_CTRL").GetComponent<Animator>().SetBool("Run", false);
            GameObject.Find("Character_Global_CTRL").GetComponent<Animator>().SetBool("Shoot", true);
            GameObject.Find("Character_Global_CTRL").GetComponent<Animator>().SetBool("Jump", false);
            Invoke("ShotCreate", 2f/6f);
            Invoke("EnableButton",1f);
        }
    }

    void ShotCreate()
    {
        toothless._shootCooldown = shootingRate;

            // Создайте новый выстрел
            var shotTransform = Instantiate(shotPrefab) as Transform;

            // Определите положение
            shotTransform.position = transform.position;

        // Свойство врага
        ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript>();
            if (shot != null)
            {
               // shot.isEnemyShot = isEnemy;
            }

            MoveScript move = shotTransform.gameObject.GetComponent<MoveScript>();
            if (move != null)
            {
              move.direction = Vector2.right; // в двухмерном пространстве это будет справа от спрайта
            }

        GameObject.Find("Character_Global_CTRL").GetComponent<Animator>().SetBool("Run", true);
        GameObject.Find("Character_Global_CTRL").GetComponent<Animator>().SetBool("Shoot", false);
        isShooting = false;        
    }

    void EnableButton()
    {
        _shootImage.enabled = true;
    }

    //void ShootAnim()
    //{
    //    var ch = GameObject.Find("Character_Global_CTRL");
    //    var anim = ch.GetComponent<Animator>();
    //    GameObject.Find("Character_Global_CTRL").GetComponent<Animator>().SetBool("Run", false);

    //    GameObject.Find("Character_Global_CTRL").GetComponent<Animator>().SetBool("Shoot", true);
    //    Debug.Log(GameObject.Find("Character_Global_CTRL").GetComponent<Animator>().GetBool("Shoot"));     
    //}

    /// <summary>
    /// Готово ли оружие выпустить новый снаряд?
    /// </summary>
    public bool CanAttack
    {
        get
        {
            return shootCooldown <= 0f;
        }
    }
}
