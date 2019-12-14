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
    [CustomEditor(typeof(GachaRareWeight))]
    public class GachaRareWeightEditor : BaseGoogleEditor<GachaRareWeight>
    {	    
        public override bool Load()
        {        
            GachaRareWeight targetData = target as GachaRareWeight;
        
            var client = new DatabaseClient("", "");
            string error = string.Empty;
            var db = client.GetDatabase(targetData.SheetName, ref error);	
            var table = db.GetTable<GachaRareWeightData>(targetData.WorksheetName) ?? db.CreateTable<GachaRareWeightData>(targetData.WorksheetName);
        
            List<GachaRareWeightData> myDataList = new List<GachaRareWeightData>();
        
            var all = table.FindAll();
            foreach(var elem in all)
            {
                GachaRareWeightData data = new GachaRareWeightData();
            
                data = Cloner.DeepCopy<GachaRareWeightData>(elem.Element);
                myDataList.Add(data);
            }
                
            targetData.dataArray = myDataList.ToArray();
        
            EditorUtility.SetDirty(targetData);
            AssetDatabase.SaveAssets();
        
            return true;
        }
    }
}