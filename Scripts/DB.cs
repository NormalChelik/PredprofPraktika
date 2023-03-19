using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;
using UnityEngine.Networking;



public class DB : MonoBehaviour
{
    [Header("Info")]
    [SerializeField] public List<int> SH;
    [SerializeField] public List<int> distance;
    private DatabaseReference dbref;


    void Start()
    {
        dbref = FirebaseDatabase.DefaultInstance.RootReference;
        string url = "https://dt.miet.ru/ppo_it_final";
        StartCoroutine(LoadFromServer(url));
    }

    // Update is called once per frame
    private void SaveData()
    {
        Polet user = new Polet(1, 1);
        string json = JsonUtility.ToJson(user);
        dbref.Child("main").Child("points").SetRawJsonValueAsync(json);
    }

    public IEnumerator LoadFromServer(string url)
    {
        UnityWebRequest www = UnityWebRequest.Get(url);
        www.SetRequestHeader("x-auth-token", "9kvgvr6m");
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log(www.downloadHandler.text);
            distance.Sort();
        }
    }
}

public class Polet
{
    public int SH;
    public int distance;

    public Polet(int SH, int distance)
    {
        this.SH = SH;
        this.distance = distance;
    }
}
