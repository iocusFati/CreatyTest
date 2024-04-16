using System.Collections;
using Base.UI.Entities.Windows;
using Infrastructure.Services.StaticDataService;
using Infrastructure.StaticData.Level;
using TMPro;
using UnityEngine;
using Zenject;

namespace Infrastructure.States
{
    public class DialogueWindow : Window
    {
        [SerializeField] private TextMeshProUGUI dialogueText;
        
        private LevelPlotConfig _plotConfig;

        [Inject]
        public void Construct(IStaticDataService staticData)
        {
            _plotConfig = staticData.LevelPlotConfig;
        }

        public void ShowText(string text) => 
            StartCoroutine(ShowTextCoroutine(text));

        private IEnumerator ShowTextCoroutine(string text)
        {
            dialogueText.text = "";

            foreach (char letter in text)
            {
                dialogueText.text += letter; 
                yield return new WaitForSeconds(1f / _plotConfig.DialogueSpeed);
            }
        }
    }
}