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
[CustomEditor(typeof(GachaTop))]
public class GachaTopEditor : BaseGoogleEditor<GachaTop>
{	    
    public override bool Load()
    {        
        GachaTop targetData = target as GachaTop;
        
        var client = new DatabaseClient("", "");
        string error = string.Empty;
        var db = client.GetDatabase(targetData.SheetName, ref error);	
        var table = db.GetTable<GachaTopData>(targetData.WorksheetName) ?? db.CreateTable<GachaTopData>(targetData.WorksheetName);
        
        List<GachaTopData> myDataList = new List<GachaTopData>();
        
        var all = table.FindAll();
        foreach(var elem in all)
        {
            GachaTopData data = new GachaTopData();
            
            data = Cloner.DeepCopy<GachaTopData>(elem.Element);
            myDataList.Add(data);
        }
                
        targetData.dataArray = myDataList.ToArray();
        
        EditorUtility.SetDirty(targetData);
        AssetDatabase.SaveAssets();
        
        return true;
    }
}
