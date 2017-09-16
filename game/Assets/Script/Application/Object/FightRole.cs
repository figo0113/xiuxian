using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightRole :MonoBehaviour {

    public Role roleInfo;
    public GameObject RoleObj;
    public Vector3 initialPos;
    public Vector3 atkPoslPos;
    public Animator role_Animator;
    public int AttackRate;


    public bool isAct = false; //是否行动
    public bool isAttackComplete = false;//是否完成攻击动作
    public bool isAtking = false;//攻击中
    public bool isDamgea = false; //是否造成伤害(结算伤害)
    public int atkCount ;//攻击次数

    public void InitFightRole(Role roleInfo, Vector3 initialPos, Vector3 atkPoslPos, int AttackRate)

    {
        this.roleInfo = roleInfo;
        this.RoleObj = this.gameObject;
        this.initialPos = initialPos;
        this.atkPoslPos = atkPoslPos;
        this.role_Animator = this.gameObject.GetComponent<Animator>();
        this.AttackRate = AttackRate;
        atkCount = 1;
    }

    public void AttackComplete()   
    {
        isAttackComplete = true;
    }
}
