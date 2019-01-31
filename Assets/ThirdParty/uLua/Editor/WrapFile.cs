using UnityEngine;
using System;
using System.Collections;
// using SimpleFramework;
// using SimpleFramework.Manager;

public static class WrapFile {

    public static BindType[] binds = new BindType[]
    {
      //ngui
        _GT(typeof(UIEventListener)),
        _GT(typeof(UICenterOnChild)),
        _GT(typeof(UIInput)),
        _GT(typeof(UILabel)),
        _GT(typeof(UIProgressBar)),
        _GT(typeof(UIRect)),
        _GT(typeof(UIPlayTween)),
        _GT(typeof(UIWidget)),
        _GT(typeof(UIBasicSprite)),
        _GT(typeof(UISprite)),
        _GT(typeof(UITweener)),
        _GT(typeof(UICamera)),
        _GT(typeof(UIGrid)),
        _GT(typeof(UIWidgetContainer)),
        _GT(typeof(UIScrollView)),
        _GT(typeof(UIDragScrollView)),
        _GT(typeof(UIToggle)),
        _GT(typeof(UIPanel)),
        _GT(typeof(SpringPanel)),
        _GT(typeof(Animator)),
        //_GT(typeof(CUIButtonEx)),
        //_GT(typeof(CUIWidgetEx)),
        _GT(typeof(UITexture)),
        //_GT(typeof(Ioo)),
        //_GT(typeof(Util)),
        //_GT(typeof(Const)),
        //_GT(typeof(Constants)),
        //_GT(typeof(ByteBuffer)),
        //_GT(typeof(NetworkManager)),
        //_GT(typeof(ResourceManager)),
        //_GT(typeof(CPanelManager)),
        //_GT(typeof(CTimeManager)),
        //_GT(typeof(LuaHelper)),
        //_GT(typeof(BaseLua)),
        _GT(typeof(Type)),
        _GT(typeof(UIRoot)),
        //_GT(typeof(UIHUDManager)),
        //_GT(typeof(DataTable)),
        //_GT(typeof(DataTableDefine)),
       // _GT(typeof(DataTableManager)),
       // _GT(typeof(CTableDataMng)),
        //_GT(typeof(ENUM_TABLE_TYPE)),
        //_GT(typeof(CAnimatorExtendManage)),
        //_GT(typeof(CPoolManage)),
        _GT(typeof(PlayerPrefs)),
        _GT(typeof(Debug)),
        _GT(typeof(Color)),
        //_GT(typeof(KeyCode)),
        _GT(typeof(Input)),
        //_GT(typeof(CMusicManage)),
        //_GT(typeof(CBagManager)),
        //_GT(typeof(ItemAttribute)),
        //_GT(typeof(CTableDefine)),
        //_GT(typeof(CTableEquipAttrIndex)),
        _GT(typeof(TweenPosition)),
        //_GT(typeof(RoleAttribute)),
        //_GT(typeof(BaseAttribute)),
        //_GT(typeof(BaseInitData)),
        _GT(typeof(NGUIText)),
       // _GT(typeof(CTweenPositionEx)),
        _GT(typeof(TweenAlpha)),
        _GT(typeof(TweenScale)),
        _GT(typeof(Event)),
        //系统自带
        _GT(typeof(object)),
        _GT(typeof(System.String)),
        _GT(typeof(System.Enum)),   
        _GT(typeof(IEnumerator)),
        _GT(typeof(System.Delegate)),        
        _GT(typeof(Type)).SetBaseName("System.Object"),                                                     
        _GT(typeof(UnityEngine.Object)),
        _GT(typeof(Vector2)),
        _GT(typeof(Vector3)),
        _GT(typeof(Vector4)),
       // _GT(typeof(CRadarMap)),
        _GT(typeof(GameObject)),
        _GT(typeof(Transform)),
        _GT(typeof(Component)),
        _GT(typeof(Behaviour)),
        //_GT(typeof(MonoBehaviour)),
        _GT(typeof(Time)),
        _GT(typeof(Application)),
        _GT(typeof(Rect)),
        _GT(typeof(Collider)),
        _GT(typeof(BoxCollider)),
        _GT(typeof(Screen)),
        _GT(typeof(Camera)),
        //_GT(typeof(SSkillMain)),
        //_GT(typeof(MissionManager)),
        //_GT(typeof(MissionStruct)),
        //_GT(typeof(AgentPlayer)),
        //_GT(typeof(Agent)),
        //_GT(typeof(CSceneManager)),
        //_GT(typeof(CMainPlayerInfo)),
        //_GT(typeof(CCommonTool)),
        ////_GT(typeof(CModelBaseInfo)),
        ////_GT(typeof(CShow3DModel)),
        //_GT(typeof(CMapManager)),
        //_GT(typeof(CTimeBaseInfo)),
        ////---------Lua监听相关-------------
        //_GT(typeof(LuaEventDispatcher)),
        ////---------剧情相关----------------
        //_GT(typeof(MoviePlotEvent)),
        //_GT(typeof(CPlotDialogInfo)),
        //---------邮件相关----------------
        //_GT(typeof(MailInfo)),
        ////----------抽奖相关配置---------------
        //_GT(typeof(CCapsule)),
        //_GT(typeof(CapsuleInfo)),
        ////----------复活相关---------------
        //_GT(typeof(ReviveDate)),
        ////----------龙魂相关--------------
        //_GT(typeof(CDragonSoulData)),
        ////---------技能相关----------------
        ////_GT(typeof(Skill)),
        //_GT(typeof(GlobalFun)),
        //_GT(typeof(CPlayerOnLoginAnim)),//登录流程动画特效文件
        ////电影剧情相关
        //_GT(typeof(CMoviePlotManager)),
        ////------------------新手引导管理器
        //_GT(typeof(CNewPlayerGuideManager)),
        ////-------------使用药品相关--------
        //_GT(typeof(CUseMedicineManager)),
        ////-------------福利相关-----------
        //_GT(typeof(CRewardManager)),
        ////-------------活动管理器---------
        //_GT(typeof(CActivityManager)),
        //_GT(typeof(CUIAccelerateSpringPanel)),
        ////--------------公会相关-------------
        //_GT(typeof(CGuildManager)),
        //_GT(typeof(AssetPath)),
        ////语音相关
        //_GT(typeof(UIRecordOperate)),
        //_GT(typeof(CVoiceManager)),
        //_GT(typeof(CVoiceMsgData)),
        ////_GT(typeof(Yunya)),
        ////_GT(typeof(YunyaResponse)),
        ////位操作
        //_GT(typeof(BitUtil)),
        ////列表组件
        //_GT(typeof(UIListCellTrigger)),
        //_GT(typeof(UIListCell)),
        //_GT(typeof(UIListView)),

        //_GT(typeof(GameReportManager)),
        //_GT(typeof(LuaInt64)),
        _GT(typeof(Debug)),
        _GT(typeof(Timer)),
        //_GT(typeof(FileTool)),
        ////装备属性相关
        //_GT(typeof(EquipRandomAttribute)),
        //_GT(typeof(EquipSuitAttribute)),
        //_GT(typeof(PetAttribute)),
        ////装备属性相关 end
        //_GT(typeof(CUITooltip)),
        //_GT(typeof(EventDelegate)),
        //_GT(typeof(CSDKResultData)),
        //_GT(typeof(CSDKManager)),
        //_GT(typeof(GameSDK.CSDKInterface)),

        //_GT(typeof(CLGPerson)),
        //_GT(typeof(ENUM_LGS_PERSON_ATT_TYPE)),
        //_GT(typeof(LoginManager)),

        //_GT(typeof(CFashionCamera)),
        //_GT(typeof(LuaDelegateUtil)),
        _GT(typeof(SystemInfo)),

        //_GT(typeof(EmojiComponent)),
        //_GT(typeof(UIHUD)),
        //_GT(typeof(UIHUDFix)),

        //本地推送
        //_GT(typeof(CLocalNotificationManager)),
        _GT(typeof(RenderSettings)),
        
        //JSON
        //_GT(typeof(LitJson.JsonData)),
        //_GT(typeof(LitJson.JsonMapper)),

        //_GT(typeof(CParticleUpdateColor)),
        _GT(typeof(Texture)),
        //_GT(typeof(CPlayerChangeEquip)),
        //_GT(typeof(GameManager)),
        _GT(typeof(UISlider)),
        _GT(typeof(UIProgressBar)),
        _GT(typeof(UITable)),
        //_GT(typeof(RoleDateInfo)),
        //_GT(typeof(CUIAtlasManager)),
        //_GT(typeof(CMoveCameraManager)),
        //_GT(typeof(CDangerSceneBossManager)),
        //_GT(typeof(CIndividuationManager)),
        //_GT(typeof(CFashionManager)),
        //_GT(typeof(CLifeSkillManager)),
        //_GT(typeof(UIBuffManager)),
        //_GT(typeof(CTeamManager)),
        //_GT(typeof(CAuctionManager)),
        //_GT(typeof(CPlayerSettingManager)),
        //_GT(typeof(CWebBundleManager)),
        //_GT(typeof(WebBundleInfo)),
        //_GT(typeof(CWebBundlePromptManager)),
        _GT(typeof(LuaHelper)),
        _GT(typeof(MonoTools)),
       // _GT(typeof(LuaArray));
    };

    public static BindType _GT(Type t) {
        return new BindType(t);
    }

}
