using UnityEngine;
using UnityEditor;
using System.IO;
using UnityQuickSheet;

namespace MasterData
{
    ///
    /// !!! Machine generated code !!!
    /// 
    public partial class GoogleDataAssetUtility
    {
        [MenuItem("Assets/Create/Google/GachaRareWeight")]
        public static void CreateGachaRareWeightAssetFile()
        {
            GachaRareWeight asset = CustomAssetUtility.CreateAsset<GachaRareWeight>();
            asset.SheetName = "GachaDB";
            asset.WorksheetName = "GachaRareWeight";
            EditorUtility.SetDirty(asset);        
        }
    
    }
}