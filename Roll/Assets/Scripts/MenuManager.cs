using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private static MenuManager instance;

    public static MenuManager Instance
    {
        get
        {
            if (instance == null)
                Debug.LogError("MenuManager instance not found");

            return instance;
        }
    }

    [SerializeField]
    Button Play = null, Credits = null, Skins = null, Quit = null;
    [SerializeField]
    Button Base = null, Melon = null, Bill = null;
    [SerializeField]
    Material baseMat = null, melonMat = null, billMat = null;
    bool melon = false, bill = false;
    [SerializeField]
    GameObject CreditsScreen = null;
    [SerializeField]
    GameObject SkinsScreen = null;
    //[SerializeField]
    //GameObject TitleScreen = null;

    bool credits = false;
    bool skins = false;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    void Start()
    {
        Play.onClick.AddListener(PlayClick);
        Credits.onClick.AddListener(CreditsClick);
        Skins.onClick.AddListener(SkinsClick);
        Quit.onClick.AddListener(QuitClick);

        Base.onClick.AddListener(BaseClick);
        Melon.onClick.AddListener(MelonClick);
        Bill.onClick.AddListener(BillClick);
    }

    void Update()
    {
        if ((credits || skins) && Input.GetKeyDown("escape"))
        {
            Play.gameObject.SetActive(true);
            Credits.gameObject.SetActive(true);
            Quit.gameObject.SetActive(true);
            CreditsScreen.gameObject.SetActive(false);
            SkinsScreen.gameObject.SetActive(false);

            credits = false;
            //enlever les crédits
        }
    }

    void PlayClick()
    {
        SceneManager.LoadScene("SampleScene");
    }

    void CreditsClick()
    {
        Play.gameObject.SetActive(false);
        Credits.gameObject.SetActive(false);
        Quit.gameObject.SetActive(false);
        CreditsScreen.gameObject.SetActive(true);

        credits = true;
        //afficher crédits

    }

    void SkinsClick()
    {
        Play.gameObject.SetActive(false);
        Credits.gameObject.SetActive(false);
        Quit.gameObject.SetActive(false);
        SkinsScreen.gameObject.SetActive(true);
        

        skins = true;
        //afficher skins

    }

    void BaseClick()
    {
        melon = false;
        bill = false;

    }
    void MelonClick()
    {
        melon = true;
        bill = false;
    }
    void BillClick()
    {
        bill = true;
        melon = false;
    }

    public Material chooseSkin()
    {
        if (bill){
            Debug.Log("bill");
            return billMat;
        }
        if (melon){
            Debug.Log("melon");
            return melonMat;
        }
        Debug.Log("r");
        return baseMat;

    }

    void QuitClick()
    {
        Application.Quit();
    }

}
