using System.Collections;
using System.Collections.Generic;
using Events;
using UnityEngine;
using Random = UnityEngine.Random;

public class NameGenerator : MonoBehaviour
{
  public StringEvent onRandomName;

  private List<string> AllNames;
  private List<string> Male;
  private List<string> Female;

  private bool doRandom;

  public string randomName;
  private void OnEnable()
  {
    doRandom = true;
  }

  private void Awake()
  {
    // Retrieve data
    var jnames = Resources.Load<TextAsset>("names").ToString();

    IDictionary<string, string[]> names = Utils.GetStringArrayAsDictionary(jnames);
    AllNames = Male = new List<string>(names["boys"]);
    Female = new List<string>(names["girls"]);
    AllNames.AddRange(Female);
  }

  private void Start()
  {
    StartRandomNames();
    // MessageTransporter.instance.onCharacterDataReceived += StopRandomNames;
  }

  public void StartRandomNames()
  {
    StartCoroutine(RandomNames());
  }

  public void StopRandomNames(IDictionary<string, string> state)
  {
    doRandom = false;
    onRandomName.Invoke(state["nickname"]);
  }

  public void SetRandomName()
  {
    doRandom = false;
    var rName = AllNames[Random.Range(0, AllNames.Count)];
    onRandomName.Invoke(rName);
  }

  private IEnumerator RandomNames()
  {
    while (doRandom)
    {
      var rName = AllNames[Random.Range(0, AllNames.Count)];
      randomName = rName;
      onRandomName.Invoke(rName);
      yield return new WaitForSeconds(0.2f);
    }
  }
}
