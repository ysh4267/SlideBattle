using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSetDataContainer :Singleton<StageSetDataContainer>
{
    [SerializeField] public List<StageSetData> stageSet;

    public List<StageSetData> GetStageSetClone() {
        List<StageSetData> clone = stageSet.ConvertAll(o => new StageSetData());
        return clone;
    }
}
