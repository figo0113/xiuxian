using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FightManger : View {

    public Slider playerBlood;
    public Slider targetBlood;
    private GameObject m_Player;
    private GameObject m_Target;
    Animator p_Animator;
    Animator t_Animator;
    FightModel fm;
    GameModel gm;
    MapModel mm;
    Vector3 playerInitialPos =new Vector3 (-1.5f,3.33f,0);
    Vector3 targetInitialPos = new Vector3(1.5f, 3.33f, 0);

    Vector3 playerAtkPos =new Vector3(0.38f, 3.33f, 0);
    Vector3 targetAtkPos = new Vector3(-0.38f, 3.33f, 0);

    FightRole p_fightRole;
    FightRole t_fightRole;
    private int p_AttackRate;
    private int t_AttackRate;
    float totalTime =0;//计时

    bool isescape = false;//逃跑
    bool isend = false; //战斗结束

    public override string Name
    {
        get
        {
            return Consts.V_FightManger;
        }
    }

    void Start () {

        fm = GetModel<FightModel>();
        gm = GetModel<GameModel>();
        mm = GetModel<MapModel>();
        isend = false;
        isescape = false;
        m_Player = (GameObject)Instantiate(Resources.Load("Prefab/Role/Player_kongshou"), playerInitialPos,Quaternion.Euler(0,180,0));
        if (fm.targetType == 2)
        {
            m_Target = (GameObject)Instantiate(Resources.Load("Prefab/Role/Monster/Player"), targetInitialPos, Quaternion.identity);
        }
        else if (fm.targetType == 1)
        {
            m_Target = (GameObject)Instantiate(Resources.Load("Prefab/Role/NPC/Player"), targetInitialPos, Quaternion.identity);
        }

        //p_Animator = m_Player.GetComponent<Animator>();
       // t_Animator = m_Target.GetComponent<Animator>();

        p_AttackRate = fm.targetRole.speed;
        t_AttackRate = gm.player.Speed;

        //初始化战斗对象
        p_fightRole = m_Player.GetComponent<FightRole>();
        p_fightRole.InitFightRole(gm.player, playerInitialPos, playerAtkPos, p_AttackRate);
        t_fightRole = m_Target.GetComponent<FightRole>();
        t_fightRole.InitFightRole(fm.targetRole, targetInitialPos, targetAtkPos, t_AttackRate);

        //初始化血条
        float v1 = (float)gm.player.Hp / gm.player.MaxHp;
        playerBlood.value = v1;
        float v2 = (float)fm.targetRole.Hp / fm.targetRole.maxHp;
        targetBlood.value = v2;

        gm.player.HpChange += Player_HpChange;
        fm.targetRole.HpChange += TargetRole_HpChange;
        //StartCoroutine("Fight");


    }

    private void TargetRole_HpChange(int obj)
    {

        float v = (float)fm.targetRole.Hp / fm.targetRole.maxHp;
        targetBlood.value = v;
        //Debug.Log("对手血量"+fm.targetMonster.Hp);
    }

    private void Player_HpChange(int obj)
    {
        float v = (float)gm.player.Hp / gm.player.MaxHp;
        playerBlood.value = v;
        //Debug.Log("自身血量" + gm.player.Hp);
    }

    void Update()
    {
        //逃跑
        if (isescape)
        {
            isescape = false;
            Game.Instance.LoadScene(2);
        }

        if (!isend)
        {

            //判断谁出手
            if (!p_fightRole.isAct && !t_fightRole.isAct)
            {
                totalTime += Time.deltaTime;
                if (totalTime >= 0.4)// 攻击间隔
                {
                    totalTime = 0;
                    if (p_fightRole.AttackRate * p_fightRole.atkCount < t_fightRole.AttackRate * t_fightRole.atkCount)
                    {
                        p_fightRole.isAct = true;
                    }
                    else if (p_fightRole.AttackRate * p_fightRole.atkCount == t_fightRole.AttackRate * t_fightRole.atkCount)
                    {
                        if (p_fightRole.AttackRate >= t_fightRole.AttackRate)
                        {
                            p_fightRole.isAct = true;
                        }
                        else
                        {
                            t_fightRole.isAct = true;
                        }
                    }
                    else
                    {
                        t_fightRole.isAct = true;
                    }
                }
            }
            if (p_fightRole.isAct)
            {
                Attack(p_fightRole, t_fightRole);
                
            }

            if (t_fightRole.isAct)
            {
                Attack(t_fightRole, p_fightRole);
                
            }

            if (p_fightRole.roleInfo.Hp <= 0)
            {
                isend = true;
                SendEvent(Consts.E_Lost);
                //Game.Instance.LoadScene(2);
                return;
            }

            if (t_fightRole.roleInfo.Hp <= 0)
            {
                if (fm.targetType == 2) //怪物
                {
                    mm.m_Map.allNode[mm.CurrentPos].includeMonster.RemoveAt(fm.MonsterListIndex);
                    isend = true;
                    SendEvent(Consts.E_Win, new FightArgs() { TargetType = 2, ID = fm.targetID });
                    //Game.Instance.LoadScene(2);
                    return;
                }
                if (fm.targetType == 1)
                {
                    gm.NPCs[fm.targetID].isdead = true;
                    SendEvent(Consts.E_Win);
                    Game.Instance.LoadScene(2);
                    return;
                }

            }
        }
    }

    void Attack(FightRole A, FightRole D)
    {
        if (!A.isAttackComplete) 
        {
            if(A.RoleObj.transform.position != A.atkPoslPos)
               A.RoleObj.transform.position = A.atkPoslPos; //角色移动到攻击位
        }
        else
        {
            Formula.Attack(A.roleInfo, D.roleInfo);
           // A.isDamgea = true;
            A.isAtking = false;
            A.RoleObj.transform.position = A.initialPos;
            A.isAttackComplete = false;
            A.isAct = false;            
            A.atkCount++;
            return;
        }

        if (!A.isAtking)//触发攻击动作
        {
            A.role_Animator.SetTrigger("Attack");
            A.isAtking = true;
        }
              
    }

    /*IEnumerator Fight()
    {
        int p_AtkCount = 1;
        int t_AtkCount = 1;


            yield return new WaitForSeconds(0.4f);
            if (p_AttackRate * p_AtkCount < t_AttackRate * t_AtkCount)
            {
                m_Player.transform.position = playerAtkPos;
                p_Animator.SetTrigger("Attack");
                yield return new WaitForSeconds(0.3f);
                Formula.Attack(gm.player, fm.targetRole);
                yield return new WaitForSeconds(0.3f);
                if (fm.targetRole.hp <= 0)
                    break;
                m_Player.transform.position = playerInitialPos;
                p_AtkCount++;

            }
            else if (p_AttackRate * p_AtkCount == t_AttackRate * t_AtkCount)
            {
                if (p_AttackRate >= t_AttackRate)
                {
                    m_Player.transform.position = playerAtkPos;
                    p_Animator.SetTrigger("Attack");
                    yield return new WaitForSeconds(0.3f);
                    Formula.Attack(gm.player, fm.targetRole);
                    yield return new WaitForSeconds(0.3f);
                    if (fm.targetRole.hp <= 0)
                        break;
                    m_Player.transform.position = playerInitialPos;
                    p_AtkCount++;
                }
                else
                {
                    m_Target.transform.position = targetAtkPos;
                    t_Animator.SetTrigger("Attack");
                    yield return new WaitForSeconds(0.3f);
                    Formula.Attack(fm.targetRole, gm.player);
                    yield return new WaitForSeconds(0.3f);
                    if (gm.player.hp <= 0)
                        break;
                    m_Target.transform.position = targetInitialPos;
                    t_AtkCount++;
                }
            }
            else
            {
                m_Target.transform.position = targetAtkPos;
                t_Animator.SetTrigger("Attack");
                yield return new WaitForSeconds(0.3f);
                Formula.Attack(fm.targetRole, gm.player);
                yield return new WaitForSeconds(0.3f);
                if (gm.player.hp <= 0)
                    break;
                m_Target.transform.position = targetInitialPos;
                t_AtkCount++;
            }

    
        }
        
        Game.Instance.LoadScene(2);
        
    }*/


    public override void HandleEvent(string eventName, object data)
    {

    }

    public override void RegisterEvents()
    {
        
    }

    public void escapeClick()
    {
        isescape = true;
    }
}
