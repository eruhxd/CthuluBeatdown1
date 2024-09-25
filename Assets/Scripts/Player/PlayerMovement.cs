using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerAnimation player_Anim;
    private Rigidbody rb;
    public float walk_Speed = 3f;
    public float Z_Speed = 1.5f;
    private float rotation_Y_FRONTAL = 190f;
    private float rotation_Y_BACK = 0f;
    private float rotation_Speed = 15f;

    void Start()
    {

    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        player_Anim = GetComponent<PlayerAnimation>();
    }

    void Update()
    {
        RotatePlayer();
        AnimatePlayerWalk();
    }

    private void FixedUpdate()
    {
        DetectMovement();
    }

    void DetectMovement()
    {
        rb.velocity = new Vector3
            (
            Input.GetAxisRaw(Axis.VERTICAL_AXIS) * (walk_Speed),
            rb.velocity.y,
            Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) * (-Z_Speed)
            );
    }
    void RotatePlayer()
    {
        if (Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) > 0)
        {
            transform.rotation = Quaternion.Euler(0f, rotation_Y_FRONTAL, 0f);
        }
        else if (Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) < 0)
        {
            transform.rotation = Quaternion.Euler(0f, Mathf.Abs(rotation_Y_BACK), 0f);
        }
    }

    void AnimatePlayerWalk()
    {
        if(Input.GetAxisRaw(Axis.VERTICAL_AXIS) !=0 ||
        Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) !=0)
        {
            player_Anim.Walk(true);
        }
        else
        {
            player_Anim.Walk(false);
        }

    }
}
 