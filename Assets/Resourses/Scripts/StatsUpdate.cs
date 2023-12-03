using Firebase.Database;
using TMPro;
using UnityEngine;

namespace Resourses.Scripts
{
    public class StatsUpdate : MonoBehaviour
    {
        [SerializeField] private Shoot shoot;
        [SerializeField] private UI ui;

        private string _shootCount;
        private string _id;
        private DatabaseReference _reference;
        
        public void Initialize(string id)
        {
            _reference = FirebaseDatabase.DefaultInstance.RootReference;
            _id = id;
        }

        public void DownloadData()
        {
            var shoots  = _reference.Child(_id).Child("Player").GetValueAsync().ContinueWith(task =>
            {
                if (task.IsCompleted)
                {
                    DataSnapshot snapshot = task.Result;
                    InvokeAfterTask(snapshot.Child("shootCount").Value.ToString());
                }
                else
                {
                    print("Error");
                }
            });
            
        }

        private void InvokeAfterTask(string value)
        {
            ui.shootCountChanged?.Invoke(value);
        }        
        
        public void Upload()
        {
            string json = JsonUtility.ToJson(shoot.playerStats);
            _reference.Child(_id).Child("Player").SetRawJsonValueAsync(json).ContinueWith(task =>
            {
                if (task.IsCompleted)
                {
                    Debug.Log("successfully added data to firebase database");
                }
                else
                {
                    Debug.Log("not successfully");
                }
            });
        }
        
    }
}
