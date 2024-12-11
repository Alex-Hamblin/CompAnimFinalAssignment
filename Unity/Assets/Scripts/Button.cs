using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Button : MonoBehaviour
{
    public Color baseC;
    public Color hoverC;
    public TextMeshProUGUI textMeshProUGUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeScene()
    {
        SceneManager.LoadScene("Test1");
    }
    public void OnHover()
    {
        textMeshProUGUI.color = hoverC;
    }
    public void OnUnHover()
    {

        textMeshProUGUI.color = baseC;
    }
}
