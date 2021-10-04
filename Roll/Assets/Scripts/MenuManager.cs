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
    [SerializeField]
    GameObject CreditsScreen = null;
    [SerializeField]
    GameObject SkinsScreen = null;
    //[SerializeField]
    //GameObject TitleScreen = null;

    bool credits = false;
    bool skins = false;
    bool isPlaying = false;

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

    public enum Skin
    {
        Base,
        Melon,
        Bill
    }
    private Skin currentSkin;

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
        if (!isPlaying && Input.GetKeyDown("escape"))
        {
            close();
        }
    }

    void close()
    {
        if ((credits || skins))
        {
            Play.gameObject.SetActive(true);
            Credits.gameObject.SetActive(true);
            Quit.gameObject.SetActive(true);
            CreditsScreen.gameObject.SetActive(false);
            SkinsScreen.gameObject.SetActive(false);
            Skins.gameObject.SetActive(true);

            credits = false;
            //enlever les crédits
        }
    }

    void PlayClick()
    {
        SceneManager.LoadScene("SampleScene");
        isPlaying = true;
    }

    void CreditsClick()
    {
        Play.gameObject.SetActive(false);
        Credits.gameObject.SetActive(false);
        Quit.gameObject.SetActive(false);
        CreditsScreen.gameObject.SetActive(true);
        Skins.gameObject.SetActive(false);

        credits = true;
        //afficher crédits

    }

    void SkinsClick()
    {
        Play.gameObject.SetActive(false);
        Credits.gameObject.SetActive(false);
        Quit.gameObject.SetActive(false);
        SkinsScreen.gameObject.SetActive(true);
        Skins.gameObject.SetActive(false);


        skins = true;
        //afficher skins

    }

    void BaseClick()
    {
        currentSkin = Skin.Base;
        close();
    }
    void MelonClick()
    {
        currentSkin = Skin.Melon;
        close();
    }
    void BillClick()
    {
        currentSkin = Skin.Bill;
        close();
    }

    public Material chooseSkin()
    {
        if (currentSkin == Skin.Bill){
            return billMat;
        }
        if (currentSkin == Skin.Melon)
        {
            return melonMat;
        }
        return baseMat;

    }

    void QuitClick()
    {
        Application.Quit();
    }

}
