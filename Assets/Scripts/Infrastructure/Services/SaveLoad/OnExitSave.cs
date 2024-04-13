using System;
using UnityEngine;

namespace Infrastructure.Services.SaveLoad
{
    public class OnExitSave : MonoBehaviour
    {
        // private void OnApplicationFocus(bool hasFocus) => 
        //     AllServices.Container.Single<ISaveLoadService>().SaveProgress();

        private void OnApplicationQuit() => 
            AllServices.Container.Single<ISaveLoadService>().SaveProgress();

        private void OnApplicationPause(bool pauseStatus) => 
            AllServices.Container.Single<ISaveLoadService>().SaveProgress();
    }
}