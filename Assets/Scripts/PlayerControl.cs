using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private CharacterController controller;

    public GameObject tool;
    private MeshCollider toolCollider;

    private float ySpeed = 0;

    public float moveSpeed;
    public float jumpPower;
    private float xSpeed = 0;
    private float zSpeed = 0;

    // Start is called before the first frame update
    void Start()
    {
        tool = transform.Find("metarig/hips/spine/chest/shoulder.R/upper_arm.R/forearm.R/hand.R/hand.R_end/tool").gameObject;
        controller = gameObject.GetComponent<CharacterController>();
        toolCollider = tool.GetComponent<MeshCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 moveDir = new Vector3(xSpeed * moveSpeed, ySpeed, zSpeed * moveSpeed) * Time.deltaTime;

        GetComponent<Animator>().SetBool("moving", Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0);

        controller.Move(moveDir);

        if (Input.GetMouseButton(0) && !GetComponent<Animator>().GetBool("attacking")) {
            GetComponent<Animator>().SetBool("attacking", true);
            xSpeed = 0;
            zSpeed = 0;
        }

        if (!controller.isGrounded) {
            ySpeed -= 9.8f * Time.deltaTime;
        } else {
            ySpeed = 0;
            if (Input.GetKey(KeyCode.Space)) {
                ySpeed = jumpPower;
            }
            xSpeed = Input.GetAxis("Horizontal");
            zSpeed = Input.GetAxis("Vertical");
        }
    }

    public void endAttack() {
        tool.GetComponent<MeshCollider>().enabled = false;
    }

    public void beginAttack() {
        tool.GetComponent<MeshCollider>().enabled = true;
    }
     
    public void endAttackAnim() {
        GetComponent<Animator>().SetBool("attacking", false);
    }
}
