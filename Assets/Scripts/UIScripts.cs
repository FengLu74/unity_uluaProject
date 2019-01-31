using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScripts : MonoBehaviour {
    private GameObject sprite1;
    private GameObject sprite2;
	// Use this for initialization
	void Start () {
        sprite1 = transform.Find("Sprite1").gameObject;
        sprite2 = transform.Find("Sprite2").gameObject;
        StartDoFileLua();

	}
    void StartDoFileLua()
    {
        LuaScriptMgr.Instance.Start(testCallUluaFunc);
    }
    void testCallUluaFunc(bool state)
    {
        if (state == true)
        {
            excuteLuaFunc();
        }
        else
        {
            Debug.LogError("do ulua file error!!!");
        }
    }
    void excuteLuaFunc()
    {
        object[] data = LuaScriptMgr.Instance.CallLuaFunction("testUluaPanel.OnInit", sprite1, sprite2);
        if (data != null)
        {
            //int.TryParse(data[0].ToString(), out footModeId);
            Debug.LogError("#data--> 长度:" + data.Length);
            for (int i = 0; i < data.Length; i++)
            {
                Debug.LogError("i: " + i + " data[i]: " + data[i]);
            }
        }
    }
	// Update is called once per frame
	void Update () {
		
	}
}
