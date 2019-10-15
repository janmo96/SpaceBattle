using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;

    public float h;
    public float v;

    public float maxXPos;
    public float minXPos;

    public float smooth = 5.0F;
    public float tiltAngle = 30.0F;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, minXPos, maxXPos), transform.position.y);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        v = Input.GetAxis("Vertical");
        h = Input.GetAxis("Horizontal");

        if(h < 0)
        {
            Quaternion target = Quaternion.Euler(new Vector3(0, 0, 30));
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
            rb.AddForce(new Vector2(-speed, 0) * Time.deltaTime, ForceMode2D.Force);
        } else if (h > 0)
        {
            Quaternion target = Quaternion.Euler(new Vector3(0,0, -30));
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
            rb.AddForce(new Vector2(speed, 0) * Time.deltaTime, ForceMode2D.Force);
        } else if (h == 0)
        {
            Quaternion target = Quaternion.Euler(new Vector3(0, 0, 0));
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
        }






    }
}
