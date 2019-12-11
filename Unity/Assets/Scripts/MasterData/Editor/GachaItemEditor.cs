using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using GDataDB;
using GDataDB.Linq;

using UnityQuickSheet;

///
/// !!! Machine generated code !!!
///
[CustomEditor(typeof(GachaItem))]
public class GachaItemEditor : BaseGoogleEditor<GachaItem>
{	    
    public override bool Load()
    {        
        GachaItem targetData = target as GachaItem;
        
        var client = new DatabaseClient("", "");
        string error = string.Empty;
        var db = client.GetDatabase(targetData.SheetName, ref error);	
        var table = db.GetTable<GachaItemData>(targetData.WorksheetName) ?? db.CreateTable<GachaItemData>(targetData.WorksheetName);
        
        List<GachaItemData> myDataList = new List<GachaItemData>();
        
        var all = table.FindAll();
        foreach(var elem in all)
        {
            GachaItemData data = new GachaItemData();
            
            data = Cloner.DeepCopy<GachaItemData>(elem.Element);
            myDataList.Add(data);
        }
                
        targetData.dataArray = myDataList.ToArray();
        
        EditorUtility.SetDirty(targetData);
        AssetDatabase.SaveAssets();
        
        return true;
    }
}
