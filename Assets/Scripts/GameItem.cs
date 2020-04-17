using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameItem : MonoBehaviour
{
    public bool Active = true;
    public bool AutoUse = true;
    public bool DeleteOnUse = true;
    public bool SingleUse = true;
    public UnityEngine.Events.UnityEvent OnUse;

    private Transform originalParent;
    private Vector3 originalPos;

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
        originalPos = transform.localPosition;
    }

    public virtual void Use(Player sender)
    {
        
        WasUsed = true;
        OnUse.Invoke();
        if (DeleteOnUse)
            Destroy(gameObject);
    }

    public virtual void Reset()
    {
        WasUsed = false;
        transform.SetParent(originalParent);
        transform.localPosition = originalPos;
        SetColor(Color.white);
    }

    public void SetColor(Color c)
    {
        Renderer r = GetComponent<Renderer>();
        if (r)
            r.sharedMaterial.color = c;
    }
}
