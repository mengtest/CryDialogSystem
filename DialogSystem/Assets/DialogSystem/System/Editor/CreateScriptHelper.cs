﻿/**********************************************************
*Author: wangjiaying
*Date: 2016.7.11
*Func:
**********************************************************/
using UnityEditor;
using UnityEngine;

namespace CryDialog.Editor
{
    public class CreateScriptHelper
    {
        [MenuItem("Dialog System/Create/Action")]
        private static void CreateAction()
        {
            string path = EditorUtility.SaveFilePanel("Create Action", Application.dataPath, "NewAction", "cs");
            if (string.IsNullOrEmpty(path)) return;
            CreateScript(path, "Action");
        }

        [MenuItem("Dialog System/Create/Condition")]
        private static void CreateCondition()
        {
            string path = EditorUtility.SaveFilePanel("Create Condition", Application.dataPath, "NewCondition", "cs");
            if (string.IsNullOrEmpty(path)) return;
            CreateScript(path, "Condition");
        }

        [MenuItem("Dialog System/Create/Event")]
        private static void CreateEvent()
        {
            string path = EditorUtility.SaveFilePanel("Create Event", Application.dataPath, "NewEvent", "cs");
            if (string.IsNullOrEmpty(path)) return;
            CreateScript(path, "Event");
        }

        [MenuItem("Dialog System/Create/Decorator")]
        private static void CreateDecorator()
        {
            string path = EditorUtility.SaveFilePanel("Create Decorator", Application.dataPath, "NewDecorator", "cs");
            if (string.IsNullOrEmpty(path)) return;
            CreateScript(path, "Decorator");
        }

        private static void CreateScript(string path, string parent)
        {
            TextAsset txt = Resources.Load<TextAsset>("Template/" + parent + "ScriptTemplate");
            if (!txt)
            {
                EditorUtility.DisplayDialog("Error", "Read Templete File Faild!", "OK");
                return;
            }

            string name = System.IO.Path.GetFileNameWithoutExtension(path);
            string content = txt.text.Replace("{Date}", System.DateTime.Now.ToString()).Replace("{Name}", name).Replace(
                "{Parent}", parent).Replace("{UserName}", System.Environment.UserName + " with PC " + System.Environment.MachineName);

            System.IO.File.WriteAllText(path, content, System.Text.Encoding.UTF8);

            AssetDatabase.Refresh();
        }
    }
}
