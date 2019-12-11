using UnityEngine;
using UnityEditor;
using System.IO;
using UnityQuickSheet;

///
/// !!! Machine generated code !!!
/// 
public partial class GoogleDataAssetUtility
{
    [MenuItem("Assets/Create/Google/GachaTop")]
    public static void CreateGachaTopAssetFile()
    {
        GachaTop asset = CustomAssetUtility.CreateAsset<GachaTop>();
        asset.SheetName = "GachaDB";
        asset.WorksheetName = "GachaTop";
        EditorUtility.SetDirty(asset);        
    }
    
}