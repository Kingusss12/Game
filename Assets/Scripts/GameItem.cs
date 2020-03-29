using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameItem : MonoBehaviour
{
    public bool Active = true;
    public bool AutoUse = true;
    public bool DeleteOnUse = true;
    public bool PickupOnUse = false;
    public bool SingleUse = true;
    public UnityEngine.Events.UnityEvent OnUse;

    private Transform originalParent;

    public bool WasUsed
    {
        get;
        private set;
    }

    public virtual bool CanUse
    {
        get
        {
            return Active && !(SingleUse && WasUsed);
        }
    }

    protected virtual void Awake()
    {
        originalParent = transform.parent;
    }

    public void Use(Player sender)
    {
        
        WasUsed = true;
        HandleUse(sender);
        OnUse.Invoke();
        if (DeleteOnUse)
            Destroy(gameObject);
    }

    protected virtual void HandleUse(Player player)
    {

    }

    public virtual void Reset()
    {
        WasUsed = false;
        transform.SetParent(originalParent);
        transform.localPosition = Vector3.zero;
        SetColor(Color.white);
    }

    public void SetColor(Color c)
    {
        Renderer r = GetComponent<Renderer>();
        if (r)
            r.material.color = c;
    }
}
