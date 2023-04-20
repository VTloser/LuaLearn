using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rigidbody;
    private GameObject Tag;

    private void Awake()
    {
        Tag = GameObject.Find("Tag");
        rigidbody = (Rigidbody)Tag.GetComponent(typeof(Rigidbody));
        pos = Tag.transform.position;
        
    }

    private Vector3 pos;
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            pos += new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
            rigidbody.MovePosition(pos*0.5f);
            rigidbody.useGravity = false;
            
        }
    }
}
