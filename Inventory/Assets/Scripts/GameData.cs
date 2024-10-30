using System.Text;
using System;

public enum ItemType
{
    Weapon = 1,
    Shield,
    ChestArmor,
    Gloves,
    Boots,
    Accessery
}

public enum ItemGrade
{
    Common = 1,
    Uncommon,
    Rare,
    Epic,
    Legendary
}

[Serializable]
public class ItemModel
{
    public int item_id;
    public string item_name;
    public int attack_power;
    public int defense;

    public static ItemGrade GetGrade(int id)
    {
        return (ItemGrade)((id / 1000) % 10);
    }

    public static ItemType GetType(int id)
    {
        return (ItemType)(id / 10000);
    }

    public static string GetIconPath(int id)
    {
        StringBuilder sb = new(id.ToString());
        sb[1] = '1';

        return sb.ToString();
    }
}