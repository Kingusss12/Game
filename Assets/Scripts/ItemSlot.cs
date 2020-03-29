using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlot : GameItem
{
    public bool AllowEmpty;
    public bool KillOnIncompatible;
    public GameItem[] CompatibleItems;
    public GameItem Slot;

    public override bool CanUse {
        get
        {
            if (!base.CanUse)
                return false;
            Player p = Player.Instance;
            GameItem obj = p.PickedUpObject;
            Debug.Log("check");

            if (obj)
            {
                if (KillOnIncompatible)
                    return true;
                Debug.Log("obj exists");
                for (int i = 0; i < CompatibleItems.Length; i++)
                {
                    if (CompatibleItems[i] == obj)
                    {
                        Debug.Log("t");
                        return true;
                    }
                }
                return false;
            }
            else
            {
                if (AllowEmpty)
                {
                    return true;
                }
            }
            return false;
        }
    }

    protected override void HandleUse(Player player)
    {
        Player p = Player.Instance;
        GameItem obj = p.PickedUpObject;
        if (obj)
        {
            if (CheckCompatibility(obj))
                p.Die();
            obj.transform.SetParent(transform);
            obj.transform.localPosition = Vector3.zero;
        }
        if (Slot)
        {
            Slot.transform.SetParent(p.transform);
            Slot.transform.localPosition = p.PickupOffset;
        }
        p.PickedUpObject = Slot;
        Slot = obj;
    }

    private bool CheckCompatibility(GameItem item)
    {
        if (KillOnIncompatible)
        {
            for (int i = 0; i < CompatibleItems.Length; i++)
            {
                if (CompatibleItems[i] == item)
                {
                    return false;
                }
            }
            return true;
        }
        return false;
    }
}
