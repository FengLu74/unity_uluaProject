/*************************************************
author：ricky pu
data：2014.4.12
email:32145628@qq.com
**********************************************/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using LuaInterface;
using System;

public static class LuaHelper
{
    // 保存创建过写成的实例，防止出现重叠调用
    private static Dictionary<UIProgressBar, Coroutine> m_dicCoroutine = new Dictionary<UIProgressBar, Coroutine>();
    /// <summary>
    /// getType
    /// </summary>
    /// <param name="classname"></param>
    /// <returns></returns>
    public static System.Type GetType(string classname)
    {
        Assembly assb = Assembly.GetExecutingAssembly();  //.GetExecutingAssembly();
        System.Type t = null;
        t = assb.GetType(classname); ;
        if (t == null)
        {
            t = assb.GetType(classname);
        }
        return t;
    }

    /// <summary>
    /// GetComponentInChildren
    /// </summary>
    public static Component GetComponentInChildren(GameObject obj, string classname)
    {
        System.Type t = GetType(classname);
        Component comp = null;
        if (t != null && obj != null) comp = obj.GetComponentInChildren(t);
        return comp;
    }

    /// <summary>
    /// GetComponent
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="classname"></param>
    /// <returns></returns>
    public static Component GetComponent(GameObject obj, string classname)
    {
        if (obj == null) return null;
        return obj.GetComponent(classname);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="classname"></param>
    /// <returns></returns>
    public static Component[] GetComponentsInChildren(GameObject obj, string classname)
    {
        System.Type t = GetType(classname);
        if (t != null && obj != null) return obj.transform.GetComponentsInChildren(t);
        return null;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static Transform[] GetAllChild(GameObject obj)
    {
        Transform[] child = null;
        int count = obj.transform.childCount;
        child = new Transform[count];
        for (int i = 0; i < count; i++)
        {
            child[i] = obj.transform.GetChild(i);
        }
        return child;
    }


    public static Action Action(LuaFunction func)
    {
        Action action = () =>
        {
            func.Call();
        };
        return action;
    }

    public static UIEventListener.VoidDelegate OnClick(LuaFunction func)
    {
        if (func == null)
        {
            return null;
        }
        UIEventListener.VoidDelegate action = (go) =>
        {
            func.Call(go);
        };
        return action;
    }

    /// <summary>
    /// OnPress事件
    /// </summary>
    /// <param name="func"></param>
    /// <returns></returns>
    public static UIEventListener.BoolDelegate OnPress(LuaFunction func)
    {
        if (func == null)
        {
            return null;
        }
        UIEventListener.BoolDelegate action = (go, state) =>
        {
            func.Call(go, state);
        };
        return action;
    }

    /// <summary>
    /// OnDragEnd事件
    /// </summary>
    /// <param name="func"></param>
    /// <returns></returns>
    public static UIEventListener.VoidDelegate OnDragEnd(LuaFunction func)
    {
        if (func == null)
        {
            return null;
        }
        UIEventListener.VoidDelegate action = (go) =>
        {
            func.Call(go);
        };
        return action;
    }

    /// <summary>
    /// OnDrag事件
    /// </summary>
    /// <param name="func"></param>
    /// <returns></returns>
    public static UIEventListener.VoidDelegate OnDragStart(LuaFunction func)
    {
        if (func == null)
        {
            return null;
        }
        UIEventListener.VoidDelegate action = (go) =>
        {
            func.Call(go);
        };
        return action;
    }

    /// <summary>
    /// OnHover事件
    /// </summary>
    /// <param name="func"></param>
    /// <returns></returns>
    public static UIEventListener.BoolDelegate OnHover(LuaFunction func, int excelID)
    {
        if (func == null)
        {
            return null;
        }
        UIEventListener.BoolDelegate action = (go, state) =>
        {
            func.Call(go, state, excelID);
        };
        return action;
    }

    /// <summary>
    /// OnPress事件
    /// </summary>
    /// <param name="func"></param>
    /// <returns></returns>
    public static UIEventListener.BoolDelegate OnPress(LuaFunction func, int excelID)
    {
        if (func == null)
        {
            return null;
        }
        UIEventListener.BoolDelegate action = (go, state) =>
        {
            func.Call(go, state, excelID);
        };
        return action;
    }

    /// <summary>
    /// 带参数的OnClick事件
    /// </summary>
    /// <param name="func"></param>
    /// <returns></returns>
    public static UIEventListener.VoidDelegate OnClickWithLuaTable(LuaFunction func, LuaTable luaTable)
    {
        if (func == null)
        {
            return null;
        }
        UIEventListener.VoidDelegate action = (go) =>
        {
            func.Call(go, luaTable);
        };
        return action;
    }

    /// <summary>
    /// 增加OnClick事件
    /// </summary>
    /// <param name="obj">点击事件对象</param>
    /// <param name="func">lua函数</param>
    public static void AddObjOnClickEvent(GameObject obj,LuaFunction func)
    {
        UIEventListener.Get(obj).onClick += OnClick(func);
    }

    /// <summary>
    /// 主界面技能和血量蓝量恢复用的冷却
    /// </summary>
    /// <param name="pb">progresssbar控件</param>
    /// <param name="timeLabel">剩余时间文本</param>
    /// <param name="box">按钮碰撞盒子</param>
    /// <param name="seconds">总时间</param>
    /// <param name="leftValue">UIProgressBar开始最大值</param>
    public static void CoolDown(UIProgressBar pb, UILabel timeLabel, BoxCollider box,float seconds, float leftValue = 1)
    {
        //if (m_dicCoroutine.ContainsKey(pb))
        //{
        //    if (m_dicCoroutine[pb] != null)
        //        Ioo.GameManager.StopCoroutine(m_dicCoroutine[pb]);
        //    Coroutine curCoroutine = Ioo.GameManager.StartCoroutine(IECoolDown(pb, timeLabel, box ,seconds,  leftValue));
        //    m_dicCoroutine[pb] = curCoroutine;
        //}
        //else
        //{
        //    Coroutine curCoroutine = Ioo.GameManager.StartCoroutine(IECoolDown(pb, timeLabel, box, seconds,  leftValue));
        //    m_dicCoroutine.Add(pb, curCoroutine);
        //}

    }

    /// <summary>
    /// 停止技能cd和MPHP的cd协成
    /// </summary>
    public static void StopSkillCDAndMpHpCoroutines()
    {
        m_dicCoroutine.Clear();
    }

    /// <summary>
    /// 执行技能CD效果
    /// </summary>
    /// <param name="pb">progresssbar进程条</param>
    /// <param name="timeLabel">剩余时间文本</param>
    /// <param name="box">按钮碰撞盒子</param>
    /// <param name="seconds">总时间</param>
    /// <param name="type"></param>
    /// <param name="leftValue">UIProgressBar开始最大值</param>
    /// <returns></returns>
    private static IEnumerator IECoolDown(UIProgressBar pb, UILabel timeLabel, BoxCollider box, float seconds, float leftValue)
    {
        float curCDTimes = seconds;
        if (timeLabel != null)
            timeLabel.text = ((int)curCDTimes).ToString();
        pb.value = leftValue;
        if (box != null)
            box.enabled = false;
        while (pb != null && pb.value > 0)
        {
            yield return new WaitForSeconds(0.1f);
            pb.value -= (float)0.1f / seconds;
            curCDTimes -= 0.1f;
            if (timeLabel != null && curCDTimes > 0)
                timeLabel.text = Math.Ceiling(curCDTimes).ToString();
        }
        if (timeLabel != null)
            timeLabel.text = string.Empty;
        if (box != null)
            box.enabled = true;
    }

    /// <summary>
    /// 主界面血量蓝量动画的表现过程
    /// </summary>
    /// <param name="pb">progresssbar控件</param>
    /// <param name="seconds">时间</param>
    /// <param name="goValue">progresssbar要变化到的值</param>
    /// <param name="fromValue">progressbar当前的值</param>
    public static void HpMpTweenShow(UIProgressBar pb, float seconds, float goValue, float fromValue)
    {
        //if (m_dicCoroutine.ContainsKey(pb))
        //{
        //    if (m_dicCoroutine[pb] != null)
        //        Ioo.GameManager.StopCoroutine(m_dicCoroutine[pb]);
        //    Coroutine curCoroutine = Ioo.GameManager.StartCoroutine(TweenShow(pb, seconds, goValue, fromValue));
        //    m_dicCoroutine[pb] = curCoroutine;
        //}
        //else
        //{
        //    Coroutine curCoroutine = Ioo.GameManager.StartCoroutine(TweenShow(pb, seconds, goValue, fromValue));
        //    m_dicCoroutine.Add(pb, curCoroutine);
        //}

    }
    /// <summary>
    /// 动画表现过程的协成函数
    /// </summary>
    /// <param name="pb">progresssbar控件</param>
    /// <param name="seconds">时间</param>
    /// <param name="goValue">progresssbar要变化到的值</param>
    /// <param name="fromValue">progressbar当前的值</param>
    /// <returns></returns>
    private static IEnumerator TweenShow(UIProgressBar pb, float seconds, float goValue, float fromValue)
    {
        pb.value = fromValue;
        while (pb != null && pb.value > goValue)
        {
            yield return new WaitForSeconds(0.1f);
            pb.value -= (fromValue - goValue) * 0.1f / seconds;
        }
    }

}