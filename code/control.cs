
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class scri : MonoBehaviour
{
    private Vector3 last_mouse_position = Vector3.zero;
    private Animator animator = null;
    public Transform gun;
    public Transform gun2;
    public ParticleSystem fire;
    public GameObject shooted;
    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        last_mouse_position = Input.mousePosition;
        
    }



    // Update is called once per frame
    void Update()
    {
       
    Vector3 mouse_position = Input.mousePosition;
    Vector3 delta_mouse_position = mouse_position - last_mouse_position;
        if (Input.GetKeyDown(KeyCode.E))
        {
            gunc.instance.changegun();
        }


        gameObject.transform.Rotate(new Vector3(0f, delta_mouse_position.x * 0.2f, 0f));
      Camera.main.transform.Rotate(new Vector3(-delta_mouse_position.y * 0.2f, 0f, 0f));
      /* if (Camera.main.transform.rotation.eulerAngles.x > 40f)
        { 
            Camera.main.transform.rotation = Quaternion.Euler(new Vector3(40f,0 ,0f) );
            
        }*/
    
        last_mouse_position = mouse_position;


        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;
        forward.y = 0;
        right.y = 0;
        forward.Normalize();
        right.Normalize();
       LayerMask lm = ~(1 << 8);
        if (Input.GetKey(KeyCode.W))
        {
            gameObject.GetComponent<CharacterController>().Move(forward * 1.2f * Time.deltaTime);
            animator.Play("Unarmed-Run-Forward");
        }
        if (Input.GetKey(KeyCode.S))
        {
            gameObject.GetComponent<CharacterController>().Move(-forward * 1.2f * Time.deltaTime);
            animator.Play("Unarmed-Roll-Backward");
         

        }
        if (Input.GetKey(KeyCode.A))
        {
            gameObject.GetComponent<CharacterController>().Move(-right * 1.2f * Time.deltaTime);
           animator.Play("Unarmed-Roll-Left");
            
        }
        if (Input.GetKey(KeyCode.D))
        {
            gameObject.GetComponent<CharacterController>().Move(right * 1.2f * Time.deltaTime);
            animator.Play("Unarmed-Roll-Right");
          
        }
      if (Input.GetKey(KeyCode.Space ))
        {

           animator.Play("Unarmed-Jump");
          
       }
      if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            RaycastHit hit;
           
            fire.Play();
            
            if (Physics.Raycast(ray, out hit,500f,lm))
            {
                if (hit.collider.gameObject.GetComponent<Live1>()!= null && hit.collider.gameObject.tag!="master" )
                {
                                           hit.collider.gameObject.GetComponent<Live1>().LifeDown(30f);
                          
                }
                
            }
            Instantiate(shooted, hit.point, Quaternion.LookRotation(hit.normal));
        }
    }


    private void OnAnimatorIK(int layerIndex)
    {
        if (animator)
        {
                animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1f);
                animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1f);
                if (gun != null)
                {
                    //设置右手根据目标点而旋转移动父骨骼节点
                    animator.SetIKPosition(AvatarIKGoal.RightHand, gun.position);
                   animator.SetIKRotation(AvatarIKGoal.RightHand, gun.rotation);
                animator.SetIKPosition(AvatarIKGoal.LeftHand, gun2.position);
                animator.SetIKRotation(AvatarIKGoal.LeftHand, gun2.rotation);
            }

            }
            
        }
    
    }

