using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed;
    private MoveCommand _moveCommand;

    public ObjectPool objectPool;
    public KeyCode fireKey = KeyCode.Space;

    // Start is called before the first frame update
    void Start()
    {
        speed = 3.0f;

        Rigidbody rigidbody = GetComponent<Rigidbody>();
        if (rigidbody == null)
        {
            rigidbody = gameObject.AddComponent<Rigidbody>();
        }
        Vector3 movement = new Vector3(1, 0, 0);
        _moveCommand = new MoveCommand(rigidbody, movement);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _moveCommand.Excecute();
            
        }

        speed = 3.0f;

        //Player Movement Code
        //read the input of the horizontal and vertical, store them in a variable
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        //Debug.Log("The vertical is " + verticalInput + " and the horizontal is " + horizontalInput);
        Vector3 inputFromPlayer = new Vector3(horizontalInput, 0, verticalInput);

        //move the player based on the values
        transform.Translate(inputFromPlayer * speed * Time.deltaTime);

        

        if (Input.GetKeyDown(fireKey))
        {
            GameObject bullet = objectPool.bullets.Find(b => !b.activeInHierarchy);
            if (bullet != null)
            {
                bullet.GetComponent<BulletController>().Fire();
            }
        }
    }

  
}
