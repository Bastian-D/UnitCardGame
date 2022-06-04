using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class ResourceSystem : Singleton<ResourceSystem>
{
    //public List<UnitData> Units { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        AssembleResources();
    }

    private void AssembleResources()
    {
        //Units = Resources.LoadAll<UnitData>("Units").ToList();
    }
}
