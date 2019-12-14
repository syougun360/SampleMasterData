using UnityEngine;
using System.Collections;

namespace MasterData
{
    [System.Serializable]
    public class CharacterData
    {
        [SerializeField]
        int id;
        public int Id { get {return id; } set { id = value;} }
        
        [SerializeField]
        string name;
        public string Name { get {return name; } set { name = value;} }
        
        [SerializeField]
        int rare;
        public int Rare { get {return rare; } set { rare = value;} }
        
        [SerializeField]
        int hp;
        public int Hp { get {return hp; } set { hp = value;} }
        
        [SerializeField]
        int power;
        public int Power { get {return power; } set { power = value;} }
        
    }
}