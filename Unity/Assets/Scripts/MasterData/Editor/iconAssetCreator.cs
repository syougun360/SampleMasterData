using UnityEngine;
using UnityEditor;
using System.IO;
using UnityQuickSheet;

namespace MasterData
{
    public partial class GoogleDataAssetUtility
    {
        [MenuItem("Assets/Create/Google/icon")]
        public static void CreateiconAssetFile()
        {
            icon asset = CustomAssetUtility.CreateAsset<icon>();
            asset.SheetName = "IconTextureDB";
            asset.WorksheetName = "icon";
            EditorUtility.SetDirty(asset);        
        }
    
    }
}