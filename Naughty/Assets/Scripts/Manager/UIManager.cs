using System;
using TMPro;
using UI;
using UnityEngine;
using UnityEngine.UI;
using Utilities;

namespace Manager
{
    public class UIManager : MonoSingleton<UIManager>
    {
        public event Action OnClickDessertListButton;
        public event Action OnClickIceCreamListButton;
        public event Action OnClickMeatListButton;
        public event Action OnClickMilkListButton;
        public event Action OnClickSodaListButton;
        public event Action OnWinner;

        public Button PlayButton;
        public Button SettingButton;
        public Button ExitButton;
        public Button CreditButton;
        public Button BackButton;
        public Button AudioButton;
        public Button ControlButton;
        public Button IncreaseVolumeButton;
        public Button DecreaseVolumeButton;
        public TextMeshProUGUI SoundLevelText;

        [HideInInspector] public float SoundLevel;
        
        [SerializeField] private RectTransform uiCanvasGame;
        [SerializeField] private RectTransform uiCanvasMenu;
        [SerializeField] private RectTransform menuDialog;
        [SerializeField] private RectTransform settingDialog;
        [SerializeField] private RectTransform creditDialog;
        [SerializeField] private RectTransform mainPlayerDialog;
        [SerializeField] private RectTransform fToStoreUI;
        [SerializeField] private RectTransform storeDialog;
        [SerializeField] private RectTransform winnerDialog;
        [SerializeField] private RectTransform notCompleteUI;
        [SerializeField] private RectTransform characterUI;
        [SerializeField] private RectTransform volumeSettingUI;
        [SerializeField] private RectTransform controlKeyBoardUI;
        [SerializeField] private RectTransform nextLevelUI;
        [SerializeField] private BuyListUI buyListUI;
        [SerializeField] private CountBulletUI countBulletUI;
        [SerializeField] private HpUI hpUI;
        [SerializeField] private ShelfDessertUI shelfDessertUI;
        [SerializeField] private ShelfIceCreamUI shelfIceCreamUI;
        [SerializeField] private ShelfMeatUI shelfMeatUI;
        [SerializeField] private ShelfMilkUI shelfMilkUI;
        [SerializeField] private ShelfSodaUI shelfSodaUI;
        [SerializeField] private Button dessertListButton;
        [SerializeField] private Button iceCreamListButton;
        [SerializeField] private Button meatListButton;
        [SerializeField] private Button milkListButton;
        [SerializeField] private Button sodaListButton;

        private float cooldown = 0;
        private int soundVolume = 0;

        public void OnClosShelfStored()
        {
            HideShelfUI(shelfDessertUI, true);
            HideShelfUI(shelfIceCreamUI, true);
            HideShelfUI(shelfMeatUI, true);
            HideShelfUI(shelfMilkUI, true);
            HideShelfUI(shelfSodaUI, true);
            HideWinnerDialog(true);
            HideNotCompleteUI(true);
        }

        public void OnOpenWinnerDialog()
        {
            HideWinnerDialog(false);

            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = false;


            cooldown += Time.deltaTime;

            if (cooldown >= 3)
            {
                Winner();

                cooldown = 0;

                OnWinner?.Invoke();
            }
        }

        public bool IsWinner()
        {
            if (StuffManager.Instance.HaveDessert >= buyListUI.CountNeedDessert &&
                StuffManager.Instance.HaveIceCream >= buyListUI.CountNeedIceCream &&
                StuffManager.Instance.HaveMeat >= buyListUI.CountNeedMeat &&
                StuffManager.Instance.HaveMilk >= buyListUI.CountNeedMilk &&
                StuffManager.Instance.HaveSoda >= buyListUI.CountNeedSoda)
            {
                return true;
            }

            return false;
        }

        public void HideStoreDialog(bool hide)
        {
            storeDialog.gameObject.SetActive(!hide);
        }

        public void HideFToStoreUI(bool hide)
        {
            fToStoreUI.gameObject.SetActive(!hide);
        }

        public void HideNotCompleteUI(bool hide)
        {
            notCompleteUI.gameObject.SetActive(!hide);
        }

        public void SetTextListDessertUI(int count)
        {
            shelfDessertUI.SetTextList(count);
        }

        public void SetTextListIceCreamUI(int count)
        {
            shelfIceCreamUI.SetTextList(count);
        }

        public void SetTextListMeatUI(int count)
        {
            shelfMeatUI.SetTextList(count);
        }

        public void SetTextListMilkUI(int count)
        {
            shelfMilkUI.SetTextList(count);
        }

        public void SetTextListSodaUI(int count)
        {
            shelfSodaUI.SetTextList(count);
        }

        public void SetTextCountBulletUI(int count)
        {
            countBulletUI.SetText(count);
        }

        public void SetTextHpUI(int hp)
        {
            hpUI.SetText(hp);
        }

        public void OnOpenShelfDessertUI()
        {
            HideShelfUI(shelfDessertUI, false);
        }

        public void OnOpenShelfIceCreamUI()
        {
            HideShelfUI(shelfIceCreamUI, false);
        }

        public void OnOpenShelfMeatUI()
        {
            HideShelfUI(shelfMeatUI, false);
        }

        public void OnOpenShelfMilkUI()
        {
            HideShelfUI(shelfMilkUI, false);
        }

        public void OnOpenShelfSodaUI()
        {
            HideShelfUI(shelfSodaUI, false);
        }

        private new void Awake()
        {
            Debug.Assert(uiCanvasGame != null, "uiCanvasGame cannot be null");
            Debug.Assert(uiCanvasMenu != null, "uiCanvasMenu cannot be null");
            Debug.Assert(menuDialog != null, "menuDialog cannot be null");
            Debug.Assert(settingDialog != null, "settingDialog cannot be null");
            Debug.Assert(creditDialog != null, "creditDialog cannot be null");
            Debug.Assert(mainPlayerDialog != null, "mainPlayerDialog cannot be null");
            Debug.Assert(fToStoreUI != null, "fToStoreUI cannot be null");
            Debug.Assert(storeDialog != null, "storeDialog cannot be null");
            Debug.Assert(winnerDialog != null, "winnerDialog cannot be null");
            Debug.Assert(notCompleteUI != null, "notCompleteUI cannot be null");
            Debug.Assert(characterUI != null, "characterUI cannot be null");
            Debug.Assert(volumeSettingUI != null, "volumeSettingUI cannot be null");
            Debug.Assert(controlKeyBoardUI != null, "controlKeyBoardUI cannot be null");
            Debug.Assert(buyListUI != null, "buyListUI cannot be null");
            Debug.Assert(countBulletUI != null, "countBulletUI cannot be null");
            Debug.Assert(hpUI != null, "hpUI cannot be null");
            Debug.Assert(shelfDessertUI != null, "shelfDessertUI cannot be null");
            Debug.Assert(shelfIceCreamUI != null, "shelfIceCreamUI cannot be null");
            Debug.Assert(shelfMeatUI != null, "shelfMeatUI cannot be null");
            Debug.Assert(shelfMilkUI != null, "shelfMilkUI cannot be null");
            Debug.Assert(shelfSodaUI != null, "shelfSodaUI cannot be null");
            Debug.Assert(dessertListButton != null, "dessertListButton cannot be null");
            Debug.Assert(iceCreamListButton != null, "iceCreamListButton cannot be null");
            Debug.Assert(meatListButton != null, "meatListButton cannot be null");
            Debug.Assert(milkListButton != null, "milkListButton cannot be null");
            Debug.Assert(sodaListButton != null, "sodaListButton cannot be null");

            HideUICanvasGame(true);
            HideUICanvasMenu(false);
            HideMenuDialog(menuDialog, false);
            HideMainPlayerDialog(false);
            HideBuyListUI(false);
            HideCountBulletUI(false);
            HideHpUI(false);
            HideCharacterUI(false);
            HideBackButton(true);
            IsWinner();

            dessertListButton.onClick.AddListener(OnDessertListButtonClicked);
            iceCreamListButton.onClick.AddListener(OnIceCreamListButtonClicked);
            meatListButton.onClick.AddListener(OnMeatListButtonClicked);
            milkListButton.onClick.AddListener(OnMilkListButtonClicked);
            sodaListButton.onClick.AddListener(OnSodaListButtonClicked);

            GameManager.Instance.OnPlayGame += OnClickPlay;
            GameManager.Instance.OnSetting += OnClickSetting;
            GameManager.Instance.OnBack += OnClickBlack;
            GameManager.Instance.OnCredit += OnClickCredit;
            GameManager.Instance.OnAudio += OnClickAudio;
            GameManager.Instance.OnControl += OnClickControl;
            GameManager.Instance.OnIncreaseVolume += OnClickIncreaseVolume;
            GameManager.Instance.OnDecreaseVolume += OnClickDecreaseVolume;
            GameManager.Instance.OnNextLevel += NextLevel;
        }

        private void Update()
        {
            SetTextSoundLevel();
        }

        private void SetTextSoundLevel()
        {
            SoundLevelText.text = $"{soundVolume}";
        }

        private void OnClickDecreaseVolume()
        {
            if (soundVolume != 0)
            {
                SoundLevel -= 0.1f;

                soundVolume--;
            }
        }

        private void OnClickIncreaseVolume()
        {
            if (SoundLevel < 1f)
            {
                SoundLevel += 0.1f;
                
                soundVolume++;
            }
        }

        private void OnClickControl()
        {
            HideControlKeyBoardUI(false);
            HideVolumeSettingUI(true);
        }

        private void OnClickAudio()
        {
            HideVolumeSettingUI(false);
            HideControlKeyBoardUI(true);
        }

        private void OnClickCredit()
        {
            HideMenuDialog(settingDialog, true);
            HideMenuDialog(menuDialog, true);
            HideMenuDialog(creditDialog, false);
            HideBackButton(false);
        }

        private void OnClickBlack()
        {
            HideMenuDialog(settingDialog, true);
            HideMenuDialog(menuDialog, false);
            HideMenuDialog(creditDialog, true);
            HideBackButton(true);
        }

        private void OnClickPlay()
        {
            uiCanvasMenu.gameObject.SetActive(false);
            uiCanvasGame.gameObject.SetActive(true);

            HideMenuDialog(menuDialog, true);
            HideMenuDialog(creditDialog, true);
        }

        private void OnClickSetting()
        {
            HideMenuDialog(settingDialog, false);
            HideMenuDialog(menuDialog, true);
            HideMenuDialog(creditDialog, true);
            HideBackButton(false);
        }

        private void Winner()
        {
            uiCanvasMenu.gameObject.SetActive(true);
            uiCanvasGame.gameObject.SetActive(false);
            nextLevelUI.gameObject.SetActive(false);

            HideWinnerDialog(true);
            HideMenuDialog(menuDialog, false);
        }

        private void NextLevel()
        {
            nextLevelUI.gameObject.SetActive(true);
        }

        private void HideMenuDialog(RectTransform dialog, bool hide)
        {
            dialog.gameObject.SetActive(!hide);
        }

        private void HideShelfUI(BaseShelfUI ui, bool hide)
        {
            ui.gameObject.SetActive(!hide);
        }

        private void HideBackButton(bool hide)
        {
            BackButton.gameObject.SetActive(!hide);
        }

        private void HideUICanvasGame(bool hide)
        {
            uiCanvasGame.gameObject.SetActive(!hide);
        }

        private void HideUICanvasMenu(bool hide)
        {
            uiCanvasMenu.gameObject.SetActive(!hide);
        }

        private void HideCharacterUI(bool hide)
        {
            characterUI.gameObject.SetActive(!hide);
        }

        private void HideWinnerDialog(bool hide)
        {
            winnerDialog.gameObject.SetActive(!hide);
        }

        private void HideMainPlayerDialog(bool hide)
        {
            mainPlayerDialog.gameObject.SetActive(!hide);
        }

        private void HideBuyListUI(bool hide)
        {
            buyListUI.gameObject.SetActive(!hide);
        }

        private void HideCountBulletUI(bool hide)
        {
            countBulletUI.gameObject.SetActive(!hide);
        }

        private void HideHpUI(bool hide)
        {
            hpUI.gameObject.SetActive(!hide);
        }

        private void HideVolumeSettingUI(bool hide)
        {
            volumeSettingUI.gameObject.SetActive(!hide);
        }

        private void HideControlKeyBoardUI(bool hide)
        {
            controlKeyBoardUI.gameObject.SetActive(!hide);
        }

        private void OnDessertListButtonClicked()
        {
            OnClickDessertListButton?.Invoke();
        }

        private void OnIceCreamListButtonClicked()
        {
            OnClickIceCreamListButton?.Invoke();
        }

        private void OnMeatListButtonClicked()
        {
            OnClickMeatListButton?.Invoke();
        }

        private void OnMilkListButtonClicked()
        {
            OnClickMilkListButton?.Invoke();
        }

        private void OnSodaListButtonClicked()
        {
            OnClickSodaListButton?.Invoke();
        }
    }
}