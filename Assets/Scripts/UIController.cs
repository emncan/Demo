using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : Singleton<UIController>
{

    [SerializeField]
    public Button addButton;
    [SerializeField]
    public Button reStart;
    [SerializeField]
    public InputField numberOfObject;
    public Text numberofHideObject;
    public static int number;
    void Start()
    {
       addButton.onClick.AddListener(AddButtonOnClick);
       reStart.onClick.AddListener(RestartScene);
    }

    // Update is called once per frame
    void Update()
    {
        NumberOfHideObject();
    }

    private void RestartScene()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        CoreObject.numberofhide = 0;
    }
    public void AddButtonOnClick()
    {
        int value = int.Parse(numberOfObject.text);
        TestScript.Instance.CreateNewObject(value);
    }
    public void NumberOfHideObject()
    {
        numberofHideObject.text = "" + CoreObject.numberofhide;
    }
}
