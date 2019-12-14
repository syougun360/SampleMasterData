using UnityEngine;
using UnityEditor;
using System.IO;
using UnityQuickSheet;

namespace MasterData
{
    public partial class GoogleDataAssetUtility
    {
        [MenuItem("Assets/Create/Google/GachaItem")]
        public static void CreateGachaItemAssetFile()
        {
            GachaItem asset = CustomAssetUtility.CreateAsset<GachaItem>();
            asset.SheetName = "GachaDB";
            asset.WorksheetName = "GachaItem";
            EditorUtility.SetDirty(asset);        
        }
    
    }
}