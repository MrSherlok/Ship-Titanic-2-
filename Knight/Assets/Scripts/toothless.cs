using UnityEngine;
using System.Collections;


[RequireComponent(typeof(Rigidbody2D))]

public class toothless : MonoBehaviour {
    Rigidbody2D rb;
    [SerializeField]
    private Transform[] groundPoints;
    [SerializeField]
    private float groundRadius;
    [SerializeField]
    private LayerMask whatIsGround;
    public bool isGrounded;

    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        
    }
    
  //public void Shot()
  //{      
  //      bool shoot = true;
  //  if (shoot == true )
  //  {
  //    WeaponScript weapon = GetComponent<WeaponScript>();
  //    if (weapon != null)
  //    {

  //      weapon.Attack(false);
  //    }
  //  }
  //}

	void FixedUpdate () {
        
        isGrounded = IsGrounded();


        if (isGrounded == true) {
            GetComponent<Animator>().SetBool("Jump", false);
            GetComponent<Animator>().SetBool("Run", true);
        }
        transform.rotation = Quaternion.Euler(Vector3.zero);
    }

    public void Jump()
    {
        if (isGrounded==true)
        {
            rb/*.velocity += 10 * Vector2.up;*/.AddForce(Vector2.up * 350);
            GetComponent<Animator>().SetBool("Run", false);
            GetComponent<Animator>().SetBool("Jump", true);
            isGrounded = false;
        }
        
    }



    public bool IsGrounded()
    {
        if (rb.velocity.y <= 0)
        {
            foreach (Transform point in groundPoints)
            {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(point.position, groundRadius, whatIsGround);

                for (int i = 0; i < colliders.Length; i++)
                {
                    if (colliders[i].gameObject != gameObject)
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }




    //void OnCollisionEnter2D(Collision2D coll)
    //{
    //    if (coll.gameObject.tag == "Ground")
    //    {
    //        GetComponent<Animator>().SetBool("Jump", false);
    //        isGrounded = true;
    //    }

    //}
}
