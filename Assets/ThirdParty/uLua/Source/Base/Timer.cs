using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer:MonoBehaviour
{
    private static Timer m_Instance;

    public static Timer Instance
    {
        get
        {
            if (m_Instance != null)
                return m_Instance;
            var go = new GameObject("Timer_Instance");
            GameObject.DontDestroyOnLoad(go);
            go.hideFlags = HideFlags.NotEditable;
            m_Instance = go.AddComponent<Timer>();
            return m_Instance;
        }
    }

    protected class TimerProc
    {
        public float duration;
        public float time;
        public int loop = -1;
        //后面加上是否受timescale影响
        public bool beScale = true;
        public Action Call = delegate { };

        public void SubTime(float deltaTime, float noScaleTime)
        {
            float t = beScale ? deltaTime : noScaleTime;
            this.time -= t;
        }
    }

    List<TimerProc> list = new List<TimerProc>();
    List<TimerProc> addList = new List<TimerProc>();
    List<TimerProc> delList = new List<TimerProc>();

    private void OnDestroy()
    {
        list.Clear();
        addList.Clear();
        delList.Clear();
    }

    private void Update()
    {
        OnUpdate(Time.deltaTime);
    }

    /// <summary>
    /// 添加Timer事件
    /// </summary>
    /// <param name="duration">每次调用的间隔时间</param>
    /// <param name="loop">循环次数 0执行1次 -1:一直循环 >0指定次数</param>
    /// <param name="call">回调</param>
    /// <param name="beScale">是否使用时间缩放</param>
    /// <returns></returns>
    public object AddTimer(float duration, int loop, Action call, bool beScale)
    {
        TimerProc proc = new TimerProc();
        proc.duration = duration;
        proc.time = duration;
        proc.loop = loop;
        proc.Call = call;
        proc.beScale = beScale;
        addList.Add(proc);
        return proc;
    }

    /// <summary>
    /// 添加Timer事件
    /// </summary>
    /// <param name="duration">每次调用的间隔时间</param>
    /// <param name="loop">循环次数 0执行1次 -1:一直循环 >0指定次数</param>
    /// <param name="call">回调</param>
    /// <returns></returns>
    public object AddTimer(float duration, int loop, Action call)
    {
        return AddTimer(duration, loop, call, false);
    }

    public void Yield(int frame, Action action)
    {
        StartCoroutine(YieldByFrame(frame, action));
    }

    IEnumerator YieldByFrame(int frame, Action call)
    {
        while (frame > 0)
        {
            yield return null;
            --frame;
        }

        call();
    }

    public void WaitEndOfFrame(Action action)
    {
        StartCoroutine(CoWaitEndFrame(action));
    }

    IEnumerator CoWaitEndFrame(Action action)
    {
        yield return new WaitForEndOfFrame();
        action();
    }

    public void ResetTimer(object timer, float duration, int loop, Action call, bool beScale)
    {
        TimerProc proc = timer as TimerProc;
        proc.duration = duration;
        proc.time = duration;
        proc.loop = loop;
        proc.Call = call;
        proc.beScale = beScale;

        if (!list.Contains(proc))
        {
            addList.Add(proc);
        }
    }

    public void StopTimer(object proc)
    {
        TimerProc tp = proc as TimerProc;
        delList.Add(tp);
    }

    public void StopAllTimer()
    {
        for (int i = list.Count - 1; i >= 0; i--)
        {
            StopTimer(list[i]);
        }
    }

    void DealAddTimerProcs()
    {
        if (addList.Count > 0)
        {
            for (int i = 0; i < addList.Count; i++)
            {
                list.Add(addList[i]);
            }
            addList.Clear();
        }
    }

    void DealDelTimerProcs()
    {
        if (delList.Count > 0)
        {
            for (int i = 0; i < delList.Count; i++)
            {
                for (int j = 0; j < list.Count; j++)
                {
                    if (list[j] == delList[i])
                    {
                        list.RemoveAt(j--);
                    }
                }
            }
            delList.Clear();
        }
    }

    bool IsValid(TimerProc tp)
    {
        if (delList.Count > 0)
        {
            for (int i = 0; i < delList.Count; i++)
            {
                if (delList[i] == tp)
                {
                    return false;
                }
            }
        }
        return true;
    }

    public void OnUpdate(float deltaTime)
    {
        DealAddTimerProcs();
        DealDelTimerProcs();

        float fixTime = deltaTime / Time.timeScale;
        for (int i = 0; i < list.Count; i++)
        {
            TimerProc proc = list[i];
            if (!IsValid(proc))
                continue;
            proc.SubTime(deltaTime, fixTime);

            if (proc.time <= 0)
            {
                try
                {
                    proc.Call();
                }
                catch(Exception e)
                {
                    delList.Add(proc);
                    Debug.LogError("timer call exception: " + e.Message);
                    continue;
                }
                if (proc.loop > 0)
                {
                    --proc.loop;
                    proc.time += proc.duration;
                }

                if (proc.loop == 0)
                {
                    delList.Add(proc);
                }
                else if (proc.loop < 0)
                {
                    proc.time += proc.duration;
                }
            }
        }
    }
}
