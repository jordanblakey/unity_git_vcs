using UnityEngine;

public class MainManager : MonoBehaviour
{
  public static MainManager Instance;
  public Color TeamColor;
  private void Awake()
  {
    if (Instance != null)
    {
      Destroy(gameObject);
      return;
    }
    Instance = this;
    DontDestroyOnLoad(gameObject);
    LoadColor();
  }

  [System.Serializable]
  class SaveData
  {
    public Color TeamColor;
  }

  public void SaveColor()
  {
    string path = Application.persistentDataPath + "/savefile.json";
    SaveData data = new();
    data.TeamColor = TeamColor;
    string json = JsonUtility.ToJson(data);
    System.IO.File.WriteAllText(path, json);
  }

  public void LoadColor()
  {
    string path = Application.persistentDataPath + "/savefile.json";
    if (System.IO.File.Exists(path))
    {
      string json = System.IO.File.ReadAllText(path);
      SaveData data = JsonUtility.FromJson<SaveData>(json);
      TeamColor = data.TeamColor;
    }
  }
}
