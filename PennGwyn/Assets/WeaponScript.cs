using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public SpriteRenderer Character;
    public Transform ProjectileContainer;
    public GameObject Bullet;
    public Transform WeaponHolster;
    public Transform WeaponTip;
    Vector2 mousePos;
    public float offset;

    bool LookingRight = true;
    Vector3 difference;
    float rotation_z;

    // Start is called before the first frame update
    void Start()
    {
      //  Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {

        /*Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        WeaponHolster.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - WeaponHolster.tra.position);*/

               
      
        difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - WeaponHolster.transform.position;
    
        
       
        difference.Normalize();
        rotation_z  = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        // Check if the player should flip
        Debug.Log(difference.x);
        
        
        if (LookingRight)
        {
            if (difference.x > 0.1f)
            {
                // flip
                flip();
                LookingRight = false;
            }
        }
        else
        {
            if (difference.x < 0.1f)
            {
                // flip
                 flip();
                LookingRight = true;
            }
        }
      

       //rotation_z = Mathf.Clamp(rotation_z, -50, 50);

        WeaponHolster.transform.rotation = Quaternion.Euler(0f, 0f, rotation_z + offset);

        if (Input.GetKeyDown(KeyCode.F)) { Fire(); }
    }

    private void Fire()
    {
        GameObject projectile =  GameObject.Instantiate(Bullet);
        projectile.transform.SetParent(ProjectileContainer);
        Rigidbody2D rig = projectile.GetComponent<Rigidbody2D>();
        projectile.transform.position = WeaponTip.position;



        rig.AddForce(WeaponTip.transform.right * 1000f);
    


        Destroy(projectile, 3);


    }


    private void flip()
    {
        Debug.Log("SCALE");
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        Character.transform.localScale = scale;

    }
}
