using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float speed = 5f;
    private bool move;

    void Start()
    {
        move = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (move)
        {
            Vector3 movementVector = new Vector3(1, 0, 0) * speed * Time.deltaTime;
            transform.position += movementVector;
        }
        
    }
}
