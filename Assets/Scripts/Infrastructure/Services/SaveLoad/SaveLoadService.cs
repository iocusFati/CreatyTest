using System.Collections.Generic;
using Infrastructure.Data;
using Infrastructure.Services.PersistentProgress;
using UI.Entities;
using UnityEngine;

namespace Infrastructure.Services.SaveLoad
{
    public class SaveLoadService : ISaveLoadService
    {
        private const string ProgressKey = "Progress";
        private const string ReadersKey = "Readers";

        private readonly IPersistentProgressService _persistentProgress;
        
        private readonly List<ISavedProgressReader> _progressReaders = new();
        private readonly List<ISavedProgress> _progressWriters = new();

        public SaveLoadService(IPersistentProgressService persistentProgress)
        {
            _persistentProgress = persistentProgress;
        }

        public void SaveProgress()
        {
            foreach (var writer in _progressWriters) 
                writer.UpdateProgress(_persistentProgress.Progress);
            
            PlayerPrefs.SetString(ProgressKey, _persistentProgress.Progress.ToJson());
            PlayerPrefs.SetString(ReadersKey, _progressReaders.ToJson());
        }

        public PlayerProgress LoadProgress() => 
            PlayerPrefs.GetString(ProgressKey)?.ToDeserialized<PlayerProgress>();

        public void InformReaders()
        {
            foreach (var reader in _progressReaders)
                reader.LoadProgress(_persistentProgress.Progress);
        }

        public void Register(ISavedProgressReader reader)
        {
            _progressReaders.Add(reader);
            if (reader is ISavedProgress writer) 
                _progressWriters.Add(writer);
        }
    }
}