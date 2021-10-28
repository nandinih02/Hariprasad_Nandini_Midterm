using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star_Behaviour : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer>1f)
        {
            Object.Destroy(this.gameObject);
            timer = 0;
        }


        timer += Time.deltaTime;
    }
    private void FixedUpdate()
    {
        rigidbody.AddForce(new Vector3(rigidbody.velocity.x, 20f, 0));
    }
}
