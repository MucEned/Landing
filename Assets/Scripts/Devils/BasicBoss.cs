using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBoss : MonoBehaviour
{
    [SerializeField] private GameObject attackWave;
    [SerializeField] private Transform rightHand;
    [SerializeField] private Transform leftHand;
    private float attackCountdown;
    private const float ATTACK_COOLDOWN = 10f;
    private Animator anim;
    private const int MAX_ATTACK_STYLE = 4;
    private readonly string[] ATTACK_STYLE_STR = new string[] {
        "LeftHandAttack", "RightHandAttack", "LeftHandSideAttack", "RightHandSideAttack"};

    [SerializeField] private int cheatBossAttackStyle = -1;
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
        int attackStyle = Random.Range(0, MAX_ATTACK_STYLE);

        if (cheatBossAttackStyle != -1)
            attackStyle = Mathf.Clamp(attackStyle, 0, MAX_ATTACK_STYLE - 1);
            
        anim.Play(ATTACK_STYLE_STR[attackStyle]);
        attackCountdown = ATTACK_COOLDOWN;
    }
    public void SpawnAttackLeftDown()
    {
        SpawnAttackWave(leftHand, true);
    }
    public void SpawnAttackRightDown()
    {
        SpawnAttackWave(rightHand, true);
    }
    public void SpawnAttackLeftSide()
    {
        SpawnAttackWave(leftHand, false);
    }
    public void SpawnAttackRightSide()
    {
        SpawnAttackWave(rightHand, false, true);
    }
    public void SpawnAttackWave(Transform hand, bool isHorizonDir, bool flipY = false)
    {
        float horizonDir = isHorizonDir ? 0f : 90f;
        GameObject wave = Instantiate(attackWave, hand.position, Quaternion.Euler(0f, 0f, horizonDir));

        if (flipY)
        {
            wave.transform.localScale = new Vector3(1f, -1f, 1f);
        }
    }
}
