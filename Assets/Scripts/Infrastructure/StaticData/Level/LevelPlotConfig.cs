using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Infrastructure.StaticData.Level
{
    [CreateAssetMenu(fileName = "LevelPlotConfig", menuName = "Configs/LevelPlotConfig")]
    public class LevelPlotConfig : ScriptableObject
    {
        [Header("Plots")]
        [SerializeField] private List<PlotItem> _levelStartPlot;
        [SerializeField] private List<PlotItem> _firstKeyPickedPlot;
        [SerializeField] private List<PlotItem> _allKeysCollectedPlot;
        
        [Header("Dialogue")]
        [SerializeField] private float _dialogueSpeed;

        public List<PlotItem> LevelStartPlot => _levelStartPlot;

        public List<PlotItem> FirstKeyPickedPlot => _firstKeyPickedPlot;

        public float DialogueSpeed => _dialogueSpeed;

        public List<PlotItem> AllKeysCollectedPlot => _allKeysCollectedPlot;
    }
}