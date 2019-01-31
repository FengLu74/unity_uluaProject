//----------------------------------------------
//            NGUI: Next-Gen UI kit
// Copyright © 2011-2016 Tasharen Entertainment
//----------------------------------------------

using UnityEditor;
using UnityEngine;

/// <summary>
/// Inspector class used to edit UITextures.
/// </summary>

[CanEditMultipleObjects]
[CustomEditor(typeof(UIBasicSprite), true)]
public class UIBasicSpriteEditor : UIWidgetInspector
{
	/// <summary>
	/// Draw all the custom properties such as sprite type, flip setting, fill direction, etc.
	/// </summary>

	protected override void DrawCustomProperties ()
	{
		GUILayout.Space(6f);

		SerializedProperty sp = NGUIEditorTools.DrawProperty("Type", serializedObject, "mType", GUILayout.MinWidth(20f));

		UISprite.Type type = (UISprite.Type)sp.intValue;

		if (type == UISprite.Type.Simple)
		{
			NGUIEditorTools.DrawProperty("Flip", serializedObject, "mFlip");
		}
		else if (type == UISprite.Type.Tiled)
		{
			NGUIEditorTools.DrawBorderProperty("Trim", serializedObject, "mBorder");
			NGUIEditorTools.DrawProperty("Flip", serializedObject, "mFlip");
		}
		else if (type == UISprite.Type.Sliced)
		{
			NGUIEditorTools.DrawBorderProperty("Border", serializedObject, "mBorder");
			NGUIEditorTools.DrawProperty("Flip", serializedObject, "mFlip");

			EditorGUI.BeginDisabledGroup(sp.hasMultipleDifferentValues);
			{
				sp = serializedObject.FindProperty("centerType");
				bool val = (sp.intValue != (int)UISprite.AdvancedType.Invisible);

				if (val != EditorGUILayout.Toggle("Fill Center", val))
				{
					sp.intValue = val ? (int)UISprite.AdvancedType.Invisible : (int)UISprite.AdvancedType.Sliced;
				}
			}
			EditorGUI.EndDisabledGroup();
		}
		else if (type == UISprite.Type.Filled)
		{
			NGUIEditorTools.DrawProperty("Flip", serializedObject, "mFlip");
			NGUIEditorTools.DrawProperty("Fill Dir", serializedObject, "mFillDirection", GUILayout.MinWidth(20f));
			GUILayout.BeginHorizontal();
			GUILayout.Space(4f);
			NGUIEditorTools.DrawProperty("Fill Amount", serializedObject, "mFillAmount", GUILayout.MinWidth(20f));
			GUILayout.Space(4f);
			GUILayout.EndHorizontal();
			NGUIEditorTools.DrawProperty("Invert Fill", serializedObject, "mInvert", GUILayout.MinWidth(20f));
		}
		else if (type == UISprite.Type.Advanced)
		{
			NGUIEditorTools.DrawBorderProperty("Border", serializedObject, "mBorder");
			NGUIEditorTools.DrawProperty("  Left", serializedObject, "leftType");
			NGUIEditorTools.DrawProperty("  Right", serializedObject, "rightType");
			NGUIEditorTools.DrawProperty("  Top", serializedObject, "topType");
			NGUIEditorTools.DrawProperty("  Bottom", serializedObject, "bottomType");
			NGUIEditorTools.DrawProperty("  Center", serializedObject, "centerType");
			NGUIEditorTools.DrawProperty("Flip", serializedObject, "mFlip");
		}
        //——2017.3.7刘洋添加 径向渐变效果
        else if(type == UIBasicSprite.Type.RadialGradient)
        {
            NGUIEditorTools.DrawProperty("径向渐变圆心", serializedObject, "radialCircleCenterPos", GUILayout.MinWidth(20f));
            NGUIEditorTools.DrawProperty("径向渐变直径", serializedObject, "radialCircleRadius", GUILayout.MinWidth(20f));
        }
        //——2017.4.27刘洋添加 纯色渐变效果
        else if (type == UIBasicSprite.Type.ColorGradient)
        {
            NGUIEditorTools.DrawProperty("Direction", serializedObject, "mColorChangeDirection");
            GUILayout.BeginHorizontal();
            NGUIEditorTools.SetLabelWidth(80f);
            serializedObject.DrawProperty("mGradientTop", "Top", GUILayout.MinWidth(40f));
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
            NGUIEditorTools.SetLabelWidth(80f);
            serializedObject.DrawProperty("mGradientBottom", "Bottom", GUILayout.MinWidth(40f));
            GUILayout.EndHorizontal();
        }
        else if (type == UIBasicSprite.Type.RadialClipping)
        {
            NGUIEditorTools.DrawProperty("Flip", serializedObject, "mFlip");
            NGUIEditorTools.DrawProperty("Center", serializedObject, "radialCircleCenterPos", GUILayout.MinWidth(20f));
            NGUIEditorTools.DrawProperty("Radius", serializedObject, "radialCircleRadius", GUILayout.MinWidth(20f));
        }

		if (type == UIBasicSprite.Type.Simple || type == UIBasicSprite.Type.Sliced || type == UIBasicSprite.Type.RadialClipping) // Gradients get too complicated for tiled and filled.
		{
			GUILayout.BeginHorizontal();
            SerializedProperty gr = NGUIEditorTools.DrawProperty("Gradient", serializedObject, "mApplyGradient", GUILayout.Width(95f));
            
            

			EditorGUI.BeginDisabledGroup(!gr.hasMultipleDifferentValues && !gr.boolValue);
			{
				NGUIEditorTools.SetLabelWidth(30f);
				serializedObject.DrawProperty("mGradientTop", "Top", GUILayout.MinWidth(40f));
				GUILayout.EndHorizontal();
				GUILayout.BeginHorizontal();
				NGUIEditorTools.SetLabelWidth(50f);
				GUILayout.Space(79f);

				serializedObject.DrawProperty("mGradientBottom", "Bottom", GUILayout.MinWidth(40f));
				NGUIEditorTools.SetLabelWidth(80f);

                GUILayout.EndHorizontal();
                GUILayout.BeginHorizontal();
                GUILayout.Space(79f);
                NGUIEditorTools.SetLabelWidth(60f);
                serializedObject.DrawProperty("mColorChangeDirection", "Direction");
                
                //GUILayout.EndHorizontal();



			}
			EditorGUI.EndDisabledGroup();
			GUILayout.EndHorizontal();
		}
		base.DrawCustomProperties();
	}
}
