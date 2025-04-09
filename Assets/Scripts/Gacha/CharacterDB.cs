using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Character/Database")]
public class CharacterDB : ScriptableObject
{
    public List<CharDefaultInfo> characters;

    public CharDefaultInfo GetCharacterById(string id)
    {
        return characters.Find(c => c.CharacterId == id);
    }
}
