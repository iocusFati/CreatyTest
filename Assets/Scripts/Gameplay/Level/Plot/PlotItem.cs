using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Infrastructure.StaticData.Level
{
    [Serializable]
    public class PlotItem
    {
        public PlotItemType Type;
        
        [ShowIf("Type",  PlotItemType.Dialogue)]
        [TextArea] public string DialogueVerse;

        [ShowIf("Type",  PlotItemType.CameraStateSwitch)]
        public AnimationCameraState CameraState;

        [ShowIf("Type",  PlotItemType.Action)]
        public PlotActionType ActionType;
    }
}