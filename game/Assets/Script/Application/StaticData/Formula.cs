using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;
using System;
public static class Formula  {

    public static void Attack(Role A, Role D)
    {
        int ActualHit = A.hit - D.miss;//实际命中
        int rand = UnityEngine.Random.Range(1, 10000);
        int damage = 0;
        if (rand <= ActualHit)
        {
            damage = A.attack - D.deffence;

            if (damage < (int)(A.attack * 0.1))
                damage = (int)(A.attack * 0.1);
            if (damage < 1)
                damage = 1;
        }
        
        D.Hp = D.Hp - damage;
        if (D.Hp < 0)
            D.Hp = 0;
    }

    public static int DropItem(List<Drop> dropList,int luck)
    {
        List<int> weight = new List<int>();
        List<int> maxWeight = new List<int>();

        int luckWeight = 0;
        int sumWeight=0;
        int itemID =0;
        if (dropList.Count==0)
            return 0;

        foreach (Drop drop in dropList)
        {
            weight.Add(drop.weight);
        }
        int MinWeight = weight.Min(); //最小权值; 

        luckWeight = (luck - 20) * 100;
        luckWeight = Mathf.Clamp(luckWeight, 0, 8000); //幸运值转化的权重为0--8000，暂定
        //Debug.Log("幸运权值=" + luckWeight);

        for (int i = 0; i< dropList.Count; i++)
        {
            //Debug.Log("初始权值=" + weight[i]);
            if (luckWeight > weight[i] - MinWeight)
            {                
                luckWeight = luckWeight - weight[i] + MinWeight;
                weight[i] = MinWeight;
            }
            else
            {                
                weight[i] = weight[i] - luckWeight;
                luckWeight = 0;
            }                                 
            sumWeight += weight[i];
            maxWeight.Add(sumWeight) ;
            //Debug.Log("加成后权值="+weight[i]+","+"累积权值="+maxWeight[i]);
        }
        
        int rand = UnityEngine.Random.Range(0, sumWeight);
       // Debug.Log("随机数=" + rand);
        for (int i = 0; i < dropList.Count; i++)
        {
            if (rand >= maxWeight[i])
            {
                continue;
            }
            else
            {
                itemID = dropList[i].id;
                //Debug.Log("掉落区间=" + i);
                break;
            }
        }
        return itemID;        
    }

    public static double hurt(Role AtkRole, Role DefRole, string formula, int lv)
    {
        formula = Parseformula(AtkRole, DefRole, formula, lv);
        string ptfFormula;
        if (check(formula))
        {
            ptfFormula = Transform(formula);
            return Calcultor(ptfFormula);
        }
        else
        {
            Debug.Log("公式错误");
            return 0;
        }
        
    }

    private static string Transform(string formula)  //转变成后缀式
    {
        Stack<string> sk = new Stack<string>();
        string ptfstr = "";
        string str3 = "0123456789.";
        char ch;
        string outstr;
        int i = 0;
        while (i < formula.Length)
        {
            ch = formula[i];
            switch (ch)
            {
                case '+':
                case '-':
                    while (sk.Count != 0 && !(sk.Peek()).Equals("("))
                    {
                        outstr = sk.Pop();
                        ptfstr += outstr;
                    }
                    sk.Push(ch.ToString());
                    i++;
                    break;
                case '*':
                case '/':
                case '%':
                    while (sk.Count != 0 && ((sk.Peek()).Equals("*") || (sk.Peek()).Equals("/") || (sk.Peek()).Equals("%") || (sk.Peek()).Equals("^")))
                    {
                        outstr = sk.Pop();
                        ptfstr += outstr;
                    }
                    sk.Push(ch.ToString());
                    i++;
                    break;
                case '^':
                    while (sk.Count != 0 && (sk.Peek()).Equals("^"))
                    {
                        outstr = sk.Pop();
                        ptfstr += outstr;
                    }
                    sk.Push(ch.ToString());
                    i++;
                    break;
                case '(':
                    sk.Push(ch.ToString());
                    i++;
                    break;
                case ')':
                    outstr = sk.Pop();
                    while (sk.Count != 0 && (!outstr.Equals("(") || outstr == null))
                    {
                        ptfstr += outstr;
                        outstr = sk.Pop();
                    }
                    i++;
                    break;
                default:
                    while (str3.Contains(ch.ToString()))
                    {
                        ptfstr += ch.ToString();
                        i++;
                        if (i < formula.Length)
                            ch = formula[i];
                        else
                            break;

                    }
                    ptfstr += " ";
                    break;

            }
        }
        while (sk.Count != 0)
        {
            outstr = sk.Pop();
            ptfstr += outstr;
        }
        return ptfstr;
    }
    public static string Parseformula(Role AtkRole, Role DefRole, string formula,int lv)
    {
        //string[] ParseString = { "A.atk", "A.def", "A.hp", "A.maxHp", "D.atk", "D.def", "D.hp", "D.maxHp" ,"lv"};
        string rep = null;
        if (formula.Contains("A.atk"))
        {
            rep = AtkRole.attack.ToString();
            formula=formula.Replace("A.atk", rep);
        }
        if (formula.Contains("D.atk"))
        {
            rep = DefRole.attack.ToString();
            formula=formula.Replace("D.atk", rep);
        }
        if (formula.Contains("A.def"))
        {
            rep = AtkRole.deffence.ToString();
            formula = formula.Replace("A.def", rep);
        }
        if (formula.Contains("D.def"))
        {
            rep = DefRole.deffence.ToString();
            formula = formula.Replace("D.def", rep);
        }

        if (formula.Contains("A.hp"))
        {
            rep = AtkRole.hp.ToString();
            formula = formula.Replace("A.hp", rep);
        }
        if (formula.Contains("D.hp"))
        {
            rep = DefRole.hp.ToString();
            formula = formula.Replace("D.hp", rep);
        }
        if (formula.Contains("A.maxHp"))
        {
            rep = AtkRole.maxHp.ToString();
            formula = formula.Replace("A.maxHp", rep);
        }
        if (formula.Contains("D.maxHp"))
        {
            rep = DefRole.maxHp.ToString();
            formula = formula.Replace("D.maxHp", rep);
        }
        if (formula.Contains("lv"))
        {
            rep = lv.ToString();
            formula = formula.Replace("lv", rep);
        }
        return formula;
    }

    private static double Calcultor(string ptfstr)  //后缀式进行运算并得出结果
    {
        Stack<double> tempsk = new Stack<double>();
        string str3 = "0123456789.";
        double num1;
        double num2;
        string str = "";
        double sum = 0;
        char ch;
        int i = 0;
        while (i < ptfstr.Length)
        {
            ch = ptfstr[i];
            if (str3.Contains(ch.ToString()))
            {
                while (ch != ' ')
                {
                    str += ch.ToString();
                    i++;
                    ch = ptfstr[i];
                }
                num1 = Convert.ToDouble(str);
                tempsk.Push(num1);
                str = "";
                i++;
            }
            else
            {
                num2 = tempsk.Pop();
                num1 = tempsk.Pop();
                switch (ch)
                {
                    case '+': sum = num1 + num2; break;
                    case '-': sum = num1 - num2; break;
                    case '*': sum = num1 * num2; break;
                    case '/': sum = num1 / num2; break;
                    case '%': sum = num1 % num2; break;
                    case '^': sum = Math.Pow(num1, num2); break;
                }
                tempsk.Push(sum);
                i++;
            }

        }
        return tempsk.Pop();
    }
    private static bool check(string s)  //判断是否是正确的计算式子
    {
        string str1 = "0123456789";
        string str2 = "+*-/^%";
        string str3 = "0123456789.";
        string infstr = null;
        infstr = s;
        s = s.Trim();
        char[] c = s.ToCharArray();
        int i;
        bool txt_flag1 = true;
        bool txt_flag2 = true;
        bool txt_flag3 = true;
        int count1 = 0;
        int count2 = 0;
        int n1 = 0;
        int n2 = 0;
        int n3 = 0;
        StringBuilder sb = new StringBuilder(s);
        for (i = 0; i < s.Length - 1; i++)
        {
            if (c[i] == '(')
            {
                if (c[i + 1] == '(' || str1.Contains(c[i + 1]) || (c[i + 1] == '-' && str1.Contains(c[i + 2])))
                {
                    if (c[i + 1] == '-' && str1.Contains(c[i + 2]))
                    {
                        infstr = sb.Insert(i + n1 + n2 + n3 + 1, "0").ToString();
                        n1++;
                    }
                    continue;
                }
                else
                    break;
            }
            else if (str1.Contains(c[i]))
            {
                if (c[i + 1] == ')' || c[i + 1] == '.' || str1.Contains(c[i + 1]) || str2.Contains(c[i + 1]))
                    continue;
                else
                    break;
            }
            else if (str2.Contains(c[i]))
            {
                if (i == 0 && c[i] != '-')
                {
                    break;
                }
                else if (c[i + 1] == '-' && i + 2 == s.Length)
                {
                    break;
                }
                else if (c[i + 1] == '(' || str1.Contains(c[i + 1]) || (c[i + 1] == '-' && str1.Contains(c[i + 2])))
                {
                    if (str2.Contains(c[i]) && c[i + 1] == '-' && str1.Contains(c[i + 2]) || (i == 0 && c[i] == '-'))
                    {
                        if (i == 0 && c[i] == '-')
                            sb = sb.Insert(i + n1 + n2 + n3, "(0");
                        else if (str2.Contains(c[i]) && c[i + 1] == '-' && str1.Contains(c[i + 2]))
                            sb = sb.Insert(i + n1 + n2 + n3 + 1, "(0");
                        n2 += 2;
                        int j = 0;
                        while (i + n1 + n2 + n3 + j < sb.Length - 2)
                        {
                            if (str3.Contains(sb[i + n1 + n2 + n3 + j + 2]))
                            {
                                j++;
                                continue;
                            }
                            else
                            {
                                break;
                            }

                        }
                        infstr = sb.Insert(i + n1 + n2 + n3 + j + 2, ")").ToString();
                        n3++;
                    }
                    continue;
                }
                else
                    break;
            }
            else if (c[i] == ')')
            {
                if (c[i + 1] == ')' || str2.Contains(c[i + 1]))
                    continue;
                else
                    break;
            }
            else if (c[i] == '.')
            {
                int j = 1;
                bool flag = true;
                if (str1.Contains(c[i + 1]))
                {
                    while (flag)//一个double数只能含有一个小数点
                    {
                        if (i + j + 1 == s.Length)
                        {
                            break;
                        }
                        else if (str1.Contains(c[i + j + 1]))
                        {
                            j++;
                            if (i + j == s.Length)
                                break;
                        }
                        else if (str2.Contains(c[i + j + 1]) || c[i + j + 1] == ')' || i + j == s.Length)
                        {
                            break;
                        }
                        else if (c[i + j + 1] == '.')
                        {
                            flag = false;
                            break;
                        }
                    }
                    if (flag)
                        continue;
                    else
                        break;
                }
                else
                    break;
            }
        }
        if (i == s.Length - 1)
            txt_flag1 = true;
        else
            txt_flag1 = false;
        if (c[s.Length - 1] == ')' || str1.Contains(c[s.Length - 1]))
            txt_flag2 = true;
        else
            txt_flag2 = false;
        foreach (char ch in s)
        {
            if (ch == '(')
                count1++;
            if (ch == ')')
                count2++;
        }
        if (count1 == count2)
            txt_flag3 = true;
        else
            txt_flag3 = false;
        if (txt_flag1 && txt_flag2 && txt_flag3)
            return true;
        else
            return false;
    }
}
