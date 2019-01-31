using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// mono 工具类
/// </summary>
public class MonoTools : MonoBehaviour {
    private static MonoTools s_Instance;
    [NoToLua]
	// Use this for initialization
    public static MonoTools Instance
    {
        get { return s_Instance; }
    }
    void Awake()
    {
        if (s_Instance == null)
        {
            s_Instance = this;
        }
    }
    public static void Lua_Debug(string s)
    {
        Debug.LogError("[C#]"+s);
    }
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
