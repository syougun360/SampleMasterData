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
        [MenuItem("Assets/Create/Google/Character")]
        public static void CreateCharacterAssetFile()
        {
            Character asset = CustomAssetUtility.CreateAsset<Character>();
            asset.SheetName = "CharacterDB";
            asset.WorksheetName = "Character";
            EditorUtility.SetDirty(asset);        
        }
    
    }
}