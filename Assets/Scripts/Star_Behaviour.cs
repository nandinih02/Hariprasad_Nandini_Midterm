using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star_Behaviour : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Float"))
        {
            rigidbody.velocity = Vector2.up * 50f;
        }
        
    }
}
