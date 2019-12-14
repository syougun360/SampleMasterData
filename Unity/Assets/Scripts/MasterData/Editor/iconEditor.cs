using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using GDataDB;
using GDataDB.Linq;

using UnityQuickSheet;

namespace MasterData
{
    [CustomEditor(typeof(icon))]
    public class iconEditor : BaseGoogleEditor<icon>
    {	    
        public override bool Load()
        {        
            icon targetData = target as icon;
        
            var client = new DatabaseClient("", "");
            string error = string.Empty;
            var db = client.GetDatabase(targetData.SheetName, ref error);	
            var table = db.GetTable<iconData>(targetData.WorksheetName) ?? db.CreateTable<iconData>(targetData.WorksheetName);
        
            List<iconData> myDataList = new List<iconData>();
        
            var all = table.FindAll();
            foreach(var elem in all)
            {
                iconData data = new iconData();
            
                data = Cloner.DeepCopy<iconData>(elem.Element);
                myDataList.Add(data);
            }
                
            targetData.dataArray = myDataList.ToArray();
        
            EditorUtility.SetDirty(targetData);
            AssetDatabase.SaveAssets();
        
            return true;
        }
    }
}