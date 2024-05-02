using System;
using UnityEditor;
using UnityEngine;

namespace Nextension.NEditor
{
    [CustomPropertyDrawer(typeof(NonPreloadScriptable))]
    public class NonPreloadScriptableDrawer : PropertyDrawer
    {
        private ScriptableObject _scriptableObject;
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            try
            {
                var nonPreloadScriptable = NEditorHelper.getValue<NonPreloadScriptable>(property);
                if (_scriptableObject == null || nonPreloadScriptable.getScriptableObject() != _scriptableObject)
                {
                    if (_scriptableObject != null)
                    {
                        SerializedPropertyUtil.release(_scriptableObject);
                    }
                    _scriptableObject = nonPreloadScriptable.getScriptableObject();
                }
                EditorGUI.PropertyField(position, SerializedPropertyUtil.getSerializedProperty(_scriptableObject));
            }
            catch (Exception e)
            {
                Debug.LogException(e);
                base.OnGUI(position, property, label);
            }
        }
        ~NonPreloadScriptableDrawer()
        {
            if (_scriptableObject != null)
            {
                SerializedPropertyUtil.release(_scriptableObject);
                _scriptableObject = null;
            }
        }
    }
}
