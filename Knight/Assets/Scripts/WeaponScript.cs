

using UnityEngine;


public class WeaponScript : MonoBehaviour
{
    public static bool isShooting = false; // стреляет ли сейчас игрок
    public Transform shotPrefab; //Префаб снаряда для стрельбы
    public float shootingRate = 0.25f; //Время перезарядки в секундах
    private float shootCooldown; //перезарядка

    void Start()
    {
        shootCooldown = 0f;
    }

    void Update()
    {
        if (shootCooldown > 0)
        {
            shootCooldown -= Time.deltaTime;
        }
    }

    //--------------------------------
    // 3 - Стрельба из другого скрипта
    //--------------------------------

    /// <summary>
    /// Создайте новый снаряд, если это возможно
    /// </summary>


    public void Attack(bool isEnemy)
    {
        if (CanAttack)
        {
            ShootAnim();
            Invoke("ShotCreate", 5f/6f);
        }
    }

    void ShotCreate()
    {
            shootCooldown = shootingRate;

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
            

            // Сделайте так, чтобы выстрел всегда был направлен на него
            MoveScript move = shotTransform.gameObject.GetComponent<MoveScript>();
            if (move != null)
            {
              move.direction = Vector2.right; // в двухмерном пространстве это будет справа от спрайта
            }
        GameObject.FindGameObjectWithTag("Character").GetComponent<Animator>().SetBool("Run", true);
        GameObject.FindGameObjectWithTag("Character").GetComponent<Animator>().SetBool("Shoot", false);

        isShooting = false;

    }

    void ShootAnim()
    {
        var ch = GameObject.FindGameObjectWithTag("Character");
        var anim = ch.GetComponent<Animator>();
            anim.SetBool("Run", false);
            anim.SetBool("Shoot", true);
        isShooting = true;
        
 
    }

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
