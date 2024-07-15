using System.IO;
using UnityEngine;

namespace Assets.Scripts.ServicesScripts.Progress
{
    public class LoadProgressService : IService
    {
        private const string Path = "Assets/CodeBase/ServicesScripts/Progress/file.txt";
        
        public PlayerProgress Progress { get; private set; }

        public void Load()
        {
            Progress = File.ReadAllText(Path) == null || File.ReadAllText(Path).Length == 0 ? new() : File.ReadAllText(Path).FromJson<PlayerProgress>();
            Debug.Log(Progress.ToJson());
        }

        public void Save()
        {
            File.WriteAllText(Path, Progress.ToJson());
            Debug.Log(Progress.ToJson());
        }

        public void Reset()
        {
            PlayerPrefs.DeleteAll();
            Load();
            Save();
        }
    }
}
