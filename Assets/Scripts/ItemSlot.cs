using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlot : GameItem
{
    public bool AllowEmpty;
    public bool KillOnIncompatible;
    public GameItem[] CompatibleItems;
    public GameItem Slot;
    private GameItem originalSlot;

    public override bool CanUse {
        get
        {
            if (!base.CanUse)
                return false;
            Player p = Player.Instance;
            GameItem obj = p.PickedUpObject;

            if (obj)
            {
                if (KillOnIncompatible)
                    return true;
                for (int i = 0; i < CompatibleItems.Length; i++)
                {
                    if (CompatibleItems[i] == obj)
                    {
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
        if (Slot)
        {
            Slot.transform.SetParent(p.transform);
            Slot.transform.localPosition = p.PickupOffset;
        }
        p.PickedUpObject = Slot;
        Slot = obj;
        if (Slot)
        {
            Slot.transform.SetParent(transform);
            Slot.transform.localPosition = Vector3.zero;
            if (CheckCompatibility(Slot))
                p.Die();
        }
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

    public override void Reset()
    {
        base.Reset();
        Slot = originalSlot;
        if (Slot)
        {
            Slot.Reset();
        }
    }

    protected override void Awake()
    {
        base.Awake();
        originalSlot = Slot;
    }
}
