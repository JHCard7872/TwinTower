﻿using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TwinTower
{
    public class UI_SettingScene : UI_Base
    {
        private int BUTTON_COUNT = 5;
        [SerializeField] private Sprite noSelect_noClick;
        [SerializeField] private Sprite noSelect_Click;
        [SerializeField] private Sprite select_noCliCK;
        [SerializeField] private Sprite select_Click;

        private Dictionary<int, int> bgmbuttonCount = new Dictionary<int, int>();
        private Dictionary<int, int> sebuttonCount = new Dictionary<int, int>();
        private Dictionary<int, int> mainCategory = new Dictionary<int, int>();
        
        private int bgmcursor;
        private int seccursor;
        private int currentcoursor;
        
        
        enum Images
        {
            BGM_Button,
            SE_Button,
            DisplayMode_Button,
            Display_Button,
            Language_Button,
            Audio_Setting,
            Display_Setting,
            Language_Setting,
            BGM_Button1,
            BGM_Button2,
            BGM_Button3,
            BGM_Button4,
            BGM_Button5,
            SE_Button1,
            SE_Button2,
            SE_Button3,
            SE_Button4,
            SE_Button5
        }
        public override void Init()
        {
            Bind<Image>(typeof(Images));

            UIManager.Instance.InputHandler -= KeyInput;
            UIManager.Instance.InputHandler += KeyInput;
            bgmcursor = 2;
            seccursor = 2;
            currentcoursor = 0;
            InitBgmButtonCount();
            InitSeButtonCount();
            InitMainCategory();
            InitSetting();
            Get<Image>((int)Images.BGM_Button).gameObject.BindEvent(()=>ChangeCoursor((int)Images.BGM_Button), Define.UIEvent.Click);
            Get<Image>((int)Images.SE_Button).gameObject.BindEvent(()=>ChangeCoursor((int)Images.SE_Button), Define.UIEvent.Click);
            Get<Image>((int)Images.DisplayMode_Button).gameObject.BindEvent(()=>ChangeCoursor((int)Images.DisplayMode_Button), Define.UIEvent.Click);
            Get<Image>((int)Images.Display_Button).gameObject.BindEvent(()=>ChangeCoursor((int)Images.Display_Button), Define.UIEvent.Click);
            Get<Image>((int)Images.Language_Button).gameObject.BindEvent(()=>ChangeCoursor((int)Images.Language_Button), Define.UIEvent.Click);
            
            Get<Image>((int)Images.BGM_Button1).gameObject.BindEvent(() => PushSoundButton(Images.BGM_Button, Images.BGM_Button1), Define.UIEvent.Click);
            Get<Image>((int)Images.BGM_Button2).gameObject.BindEvent(() => PushSoundButton(Images.BGM_Button, Images.BGM_Button2), Define.UIEvent.Click);
            Get<Image>((int)Images.BGM_Button3).gameObject.BindEvent(() => PushSoundButton(Images.BGM_Button, Images.BGM_Button3), Define.UIEvent.Click);
            Get<Image>((int)Images.BGM_Button4).gameObject.BindEvent(() => PushSoundButton(Images.BGM_Button, Images.BGM_Button4), Define.UIEvent.Click);
            Get<Image>((int)Images.BGM_Button5).gameObject.BindEvent(() => PushSoundButton(Images.BGM_Button, Images.BGM_Button5), Define.UIEvent.Click);
            
            Get<Image>((int)Images.SE_Button1).gameObject.BindEvent(() => PushSoundButton(Images.SE_Button, Images.SE_Button1), Define.UIEvent.Click);
            Get<Image>((int)Images.SE_Button2).gameObject.BindEvent(() => PushSoundButton(Images.SE_Button, Images.SE_Button2), Define.UIEvent.Click);
            Get<Image>((int)Images.SE_Button3).gameObject.BindEvent(() => PushSoundButton(Images.SE_Button, Images.SE_Button3), Define.UIEvent.Click);
            Get<Image>((int)Images.SE_Button4).gameObject.BindEvent(() => PushSoundButton(Images.SE_Button, Images.SE_Button4), Define.UIEvent.Click);
            Get<Image>((int)Images.SE_Button5).gameObject.BindEvent(() => PushSoundButton(Images.SE_Button, Images.SE_Button5), Define.UIEvent.Click);
        }

        private void KeyInput()
        {
            if (!Input.anyKey) return;

            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                if(currentcoursor == 0)
                    PushSoundButton((Images)currentcoursor, 0, (bgmcursor - 1 + BUTTON_COUNT) % BUTTON_COUNT);
                else
                    PushSoundButton((Images)currentcoursor, 0, (seccursor - 1 + BUTTON_COUNT) % BUTTON_COUNT);
            }

            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                if(currentcoursor == 0)
                    PushSoundButton((Images)currentcoursor, 0, (bgmcursor + 1) % BUTTON_COUNT);
                else
                    PushSoundButton((Images)currentcoursor, 0, (seccursor + 1) % BUTTON_COUNT);
            }

            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                ChangeCoursor((currentcoursor - 1 + BUTTON_COUNT) % BUTTON_COUNT);
                return;
            }

            if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            {
                ChangeCoursor((currentcoursor + 1) % BUTTON_COUNT);
            }
        }

        
        private void InitBgmButtonCount()
        {
            bgmbuttonCount.Add(0, (int)Images.BGM_Button1);
            bgmbuttonCount.Add(1, (int)Images.BGM_Button2);
            bgmbuttonCount.Add(2, (int)Images.BGM_Button3);
            bgmbuttonCount.Add(3, (int)Images.BGM_Button4);
            bgmbuttonCount.Add(4, (int)Images.BGM_Button5);
            
            bgmbuttonCount.Add((int)Images.BGM_Button1, 0);
            bgmbuttonCount.Add((int)Images.BGM_Button2, 1);
            bgmbuttonCount.Add((int)Images.BGM_Button3, 2);
            bgmbuttonCount.Add((int)Images.BGM_Button4, 3);
            bgmbuttonCount.Add((int)Images.BGM_Button5, 4);
        }

        private void InitSeButtonCount()
        {
            sebuttonCount.Add(0, (int)Images.SE_Button1);
            sebuttonCount.Add(1, (int)Images.SE_Button2);
            sebuttonCount.Add(2, (int)Images.SE_Button3);
            sebuttonCount.Add(3, (int)Images.SE_Button4);
            sebuttonCount.Add(4, (int)Images.SE_Button5);
            
            sebuttonCount.Add((int)Images.SE_Button1, 0);
            sebuttonCount.Add((int)Images.SE_Button2, 1);
            sebuttonCount.Add((int)Images.SE_Button3, 2);
            sebuttonCount.Add((int)Images.SE_Button4, 3);
            sebuttonCount.Add((int)Images.SE_Button5, 4);
        }

        private void InitMainCategory()
        {
            mainCategory.Add(0, (int)Images.Audio_Setting);
            mainCategory.Add(1, (int)Images.Display_Setting);
            mainCategory.Add(2, (int)Images.Language_Setting);
        }
        private void SetColor(GameObject gameObject, string color, bool isImageCheck)
        {
            Color newcolor;
            if (ColorUtility.TryParseHtmlString(color, out newcolor))
            {
                if (!isImageCheck)
                    gameObject.GetComponentInChildren<TextMeshProUGUI>().color = newcolor;
                else
                    Util.FindChild<Image>(gameObject).color = newcolor;
            }
        }

        private void SelectSoundButton(int isCheck)
        {
            for (int i = 0; i < 5; i++)
            {
                if (isCheck == 0)
                {
                    if(i == bgmcursor)
                        Get<Image>(bgmbuttonCount[i]).gameObject.GetComponent<Image>().sprite = select_Click;
                    else
                        Get<Image>(bgmbuttonCount[i]).gameObject.GetComponent<Image>().sprite = select_noCliCK;
                    
                }
                else
                {
                    if(i == seccursor)
                        Get<Image>(sebuttonCount[i]).gameObject.GetComponent<Image>().sprite = select_Click;
                    else
                        Get<Image>(sebuttonCount[i]).gameObject.GetComponent<Image>().sprite = select_noCliCK;
                }
            }
        }
        private void NoSelectSoundButton(int isCheck)
        {
            for (int i = 0; i < 5; i++)
            {
                if (isCheck == 0)
                {
                    if(i == bgmcursor)
                        Get<Image>(bgmbuttonCount[i]).gameObject.GetComponent<Image>().sprite = noSelect_Click;
                    else
                        Get<Image>(bgmbuttonCount[i]).gameObject.GetComponent<Image>().sprite = noSelect_noClick;
                    
                }
                else
                {
                    if(i == seccursor)
                        Get<Image>(sebuttonCount[i]).gameObject.GetComponent<Image>().sprite = noSelect_Click;
                    else
                        Get<Image>(sebuttonCount[i]).gameObject.GetComponent<Image>().sprite = noSelect_noClick;
                }
            }
        }
        private void InitSetting()
        {
            SetColor(Get<Image>((int)Images.Audio_Setting).gameObject, "#D86ECC", false);
            SetColor(Get<Image>((int)Images.Audio_Setting).gameObject, "#D86ECC", true);
            SetColor(Get<Image>(currentcoursor).gameObject, "#D86ECC", false);
            SelectSoundButton(0);
            NoSelectSoundButton(1);
        }

        private void PushSoundButton(Images selectsound, Images soundbutton, int nextidx = -1)
        {
            
            NoSelectSoundButton(1);
            NoSelectSoundButton(0);
            SetColor(Get<Image>(mainCategory[currentcoursor / 2]).gameObject, "#FFFFFF", true);
            SetColor(Get<Image>(mainCategory[currentcoursor / 2]).gameObject, "#FFFFFF", false);
            SetColor(Get<Image>(currentcoursor).gameObject, "#FFFFFF", false);

            if (selectsound == Images.BGM_Button)
            {
                bgmcursor = nextidx == -1 ? bgmbuttonCount[(int)soundbutton] : nextidx;
                SelectSoundButton(0);
            }
            else
            {
                seccursor = nextidx == -1 ? sebuttonCount[(int)soundbutton] : nextidx;
                SelectSoundButton(1);
            }

            currentcoursor = (int)selectsound;
            SetColor(Get<Image>(mainCategory[currentcoursor / 2]).gameObject, "#D86ECC", true);
            SetColor(Get<Image>(mainCategory[currentcoursor / 2]).gameObject, "#D86ECC", false);
            SetColor(Get<Image>(currentcoursor).gameObject, "#D86ECC", false);

        }
        
        private void ChangeSoundCoursor(int next)
        {
            
        }

        private void EnterCoursor(int nextidx)
        {
            SetColor(Get<Image>(mainCategory[currentcoursor / 2]).gameObject, "#FFFFFF", true);
            SetColor(Get<Image>(mainCategory[currentcoursor / 2]).gameObject, "#FFFFFF", false);
            SetColor(Get<Image>(currentcoursor).gameObject, "#FFFFFF", false);
            if(currentcoursor != 0 && currentcoursor != 1)
                SetColor(Get<Image>(currentcoursor).gameObject, "#FFFFFF", true);

            if (currentcoursor == 0 || currentcoursor == 1)
            {
                NoSelectSoundButton(currentcoursor);
            }

            currentcoursor = nextidx;
            
            SetColor(Get<Image>(mainCategory[currentcoursor / 2]).gameObject, "#D86ECC", true);
            SetColor(Get<Image>(mainCategory[currentcoursor / 2]).gameObject, "#D86ECC", false);
            SetColor(Get<Image>(currentcoursor).gameObject, "#D86ECC", false);
            if(currentcoursor != 0 && currentcoursor != 1)
                SetColor(Get<Image>(currentcoursor).gameObject, "#D86ECC", true);
            if (currentcoursor == 0 || currentcoursor == 1)
            {
                SelectSoundButton(currentcoursor);
            }

            
        }

        private void ExitCoursor(int idx)
        {
            
        }

        private void ChangeCoursor(int nextidx)
        {
            EnterCoursor(nextidx);      
        }
    }
}