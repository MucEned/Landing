using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBoss : MonoBehaviour
{
    private float attackCountdown;
    private const float ATTACK_COOLDOWN = 10f;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (attackCountdown >= 0)
        {
            attackCountdown -= Time.deltaTime;
            if (attackCountdown <= 0)
            {
                Attack();
            }
        }
    }
    private void Attack()
    {
        int rand = Random.Range(0, 2);
        if (rand < 1)
        {
            anim.Play("LeftHandAttack");
        }
        else
            anim.Play("RightHandAttack");

        attackCountdown = ATTACK_COOLDOWN;
    }
    public void SpawnAttackLeftDown()
    {

    }
    public void SpawnAttackRightDown()
    {
        
    }
    public void SpawnAttackLeftSide()
    {
        
    }
    public void SpawnAttackRightSide()
    {
        
    }
}
