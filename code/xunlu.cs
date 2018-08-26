using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class xunlu : MonoBehaviour
{
   
    private Transform player;
    public float attackDistance = 2f;
    private Animator animator;
    public float speed;
    private CharacterController cc;
    public float attacktime = 3;
    private float attackcounter = 0;
    // Use this for initialization
    void Start()
    {
        // myNav = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("master").transform;
        cc = this.GetComponent<CharacterController>();
        animator = this.GetComponent<Animator>();//控制动画状态机中的奔跑动作调用
        attackcounter = attacktime;//一开始只要抵达目标立即攻击
       
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Live1>().HP > 0)
        {

            //myNav.SetDestination(target.position);

            Vector3 targetPos = player.position;
            targetPos.y = transform.position.y;//此处的作用将自身的Y轴值赋值给目标Y值
            transform.LookAt(targetPos);//旋转的时候就保证已自己Y轴为轴心旋转
            float distance = Vector3.Distance(targetPos, transform.position);
            if (distance <= attackDistance)
            {
                attackcounter += Time.deltaTime;
                if (attackcounter > attacktime)
                {
                    animator.Play("attack");
                    attackcounter = 0;
                }
                else animator.SetBool("walk", false);
            }
            else
            {
                attackcounter = attacktime;//每次移动到最小攻击距离时就会立即攻击
                                           // if (animator.GetCurrentAnimatorStateInfo(0).IsName("walk"))//EnimyWalk是动画状态机中的行走的状态
                animator.SetBool("walk", true);
                cc.SimpleMove(transform.forward * speed);
                //animator.SetBool("attack ", true);//移动的时候播放跑步动画
            }
        }


    }
}