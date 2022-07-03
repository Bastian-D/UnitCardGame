using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class ResourceSystem : Singleton<ResourceSystem>
{
    public List<CardData> Cards { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        AssembleResources();
    }

    private void AssembleResources()
    {
        Cards = Resources.LoadAll<CardData>("Cards").ToList();
    }
}
