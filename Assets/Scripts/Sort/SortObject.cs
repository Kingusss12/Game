using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortObject : GameItem
{
    public int Value;
    public SpriteRenderer ValueText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void HandleUse(Player player)
    {
        player.Objective.OnProgress.AddListener(OnProgress);
        SetColor(Color.green);
    }

    public void OnProgress(GameItem obj)
    {
        if (Player.Instance.Objective.OnProgress.GetPersistentEventCount() == 2)
        {

        }
    }
}
