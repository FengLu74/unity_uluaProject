module("testUluaPanel", package.seeall)
--error("testUluaPaneltestUluaPaneltestUluaPanel");
---------------------------------------label路径---------------------------------------

-----------------------------------------按钮路径--------------------------------------

-----------------------------------------Sprite路径------------------------------------

----------------------------------gameobject所在的路径---------------------------------

----------------------------------通用的名称路径---------------------------------------

-----------------------------------引用的对象------------------------------------------
-- 面板对象
local m_panelObject = nil;

function OnInit(parm1,parm2)

    if (parm2 ==nil) and (parm1 ==nil) then
        return false,false;
    end

    m_panelObject = parm1.transform.parent;
    if m_panelObject ~=nil then
        --error("m_panelObject.name:");
    end
    setObjectEvent(parm1,onClickBtn1);
    setObjectEvent(parm2,onClickBtn2);

end
TT1=nil;
TT2 =nil;
function onClickBtn1(e)
    -- body
    --error("e.name"..e.name);
    TT1 = 10;
    MonoTools.Lua_Debug(TT1);
end
function onClickBtn2(e)
    -- body
    --error("e.name"..e.name);
    TT2 = 20;
    MonoTools.Lua_Debug(TT2);
end

function setObjectEvent(obj,event)
    
    local gameobject = nil;
    if type(obj) == "string" and m_panelObject~=nil then
        gameobject = m_panelObject.transform.Find(obj).gameobject;
    else
        gameobject = obj;
    end
    UIEventListener.Get(gameobject).onClick = LuaHelper.OnClick(event);

end