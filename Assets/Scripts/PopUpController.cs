using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PopUpController : MonoBehaviour
{
    [SerializeField]
    private GameObject background;
    
    private List<GameObject> _popUps = new List<GameObject>();

    private void Awake()
    {
        foreach (Transform child in transform)
            _popUps.Add(child.gameObject);
    }

    public void OpenPopUp(GameObject up)
    {
        foreach (GameObject pop in _popUps)
            pop.SetActive(pop == up);
        
        background.SetActive(true);
    }

    public void OpenPopUpWithTopPanel(GameObject up)
    {
        foreach (GameObject pop in _popUps)
            pop.SetActive(pop == up);
        
        
    }

    public void ClosePopUp()
    {
        foreach (GameObject pop in _popUps)
            pop.SetActive(false);
        
        background.SetActive(false);
    }

    public void OpenEmpty()
    {
        background.SetActive(true);
    }
}
