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
    [CustomEditor(typeof(Character))]
    public class CharacterEditor : BaseGoogleEditor<Character>
    {	    
        public override bool Load()
        {        
            Character targetData = target as Character;
        
            var client = new DatabaseClient("", "");
            string error = string.Empty;
            var db = client.GetDatabase(targetData.SheetName, ref error);	
            var table = db.GetTable<CharacterData>(targetData.WorksheetName) ?? db.CreateTable<CharacterData>(targetData.WorksheetName);
        
            List<CharacterData> myDataList = new List<CharacterData>();
        
            var all = table.FindAll();
            foreach(var elem in all)
            {
                CharacterData data = new CharacterData();
            
                data = Cloner.DeepCopy<CharacterData>(elem.Element);
                myDataList.Add(data);
            }
                
            targetData.dataArray = myDataList.ToArray();
        
            EditorUtility.SetDirty(targetData);
            AssetDatabase.SaveAssets();
        
            return true;
        }
    }
}