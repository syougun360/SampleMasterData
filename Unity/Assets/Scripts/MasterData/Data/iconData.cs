using UnityEngine;
using System.Collections;

namespace MasterData
{
    [System.Serializable]
    public class IconData
    {
        [SerializeField]
        int id;
        public int ID { get {return id; } set { id = value;} }
        
        [SerializeField]
        ICONLABEL iconlabel;
        public ICONLABEL Iconlabel { get {return iconlabel; } set { iconlabel = value;} }
        
        [SerializeField]
        string folder;
        public string Folder { get {return folder; } set { folder = value;} }
        
        [SerializeField]
        string name;
        public string Name { get {return name; } set { name = value;} }
        
    }
}