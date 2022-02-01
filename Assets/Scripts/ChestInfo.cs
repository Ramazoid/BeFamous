using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ChestInfo
{
    public string chest;
    public items[] chest_items;

}
[System.Serializable]
public class items
{
    public string type;
    public string slottype;
    public string rarity;
    public int level;
    public int level_wmin;
    public string itemkey;
    public string value;
    public SkillStruct skill;
    public VarsStruct[] ext_vars;
    public GemsStruct[] gems;
    public int set_id;
}
[System.Serializable]
public struct SkillStruct
{
    public string key;
    public int prcnt;
    public string effect;
}
[System.Serializable] 
public struct VarsStruct
{
    public string name;
    public int count;
    public Vars[] vars;
}
public struct Vars
{
    public string name;
    public float value;
}
public struct GemsStruct
{
    public string name;
    public int count;

}
public struct Gems
{
    public string name;
    public int id;
}