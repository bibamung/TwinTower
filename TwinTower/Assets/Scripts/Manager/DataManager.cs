﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEngine;

namespace TwinTower
{
    public class DataManager : Manager<DataManager>
    {
        

        private UIGameData _uiGameData;
        private StageInfo _stageInfo;
        private List<string> scripts;
        public UIGameData UIGameDatavalue
        {
            get
            {
                return _uiGameData;
            }
            set
            {
                _uiGameData = value;
                SaveData(_uiGameData);
            }
        }

        public StageInfo StageInfovalue
        {
            get
            {
                return _stageInfo;
            }
            set
            {
                _stageInfo = value;
            }
        }

        public List<string> Scripstvalue
        {
            get
            {
                return scripts;
            }
            set
            {
                scripts = value;
            }
        }
        
        protected override void Awake()
        {
            base.Awake();
            InitDataSetting();
        }

        private void InitDataSetting()
        {
            _uiGameData = new UIGameData(2, 2, 0, 2, 0);
            _stageInfo = new StageInfo(0, "testtxt");
            LoadData(_uiGameData);
            LoadData(_stageInfo);
        }

        private void SaveData<T>(T data) where T : GameData
        {
            var fields = typeof(T).GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            for (int i = 0, k = 0; i < fields.Length - 2; i++,k++)
            {
                if (fields[i].FieldType == typeof(int))
                {
                    PlayerPrefs.SetInt(data.names[k], Int32.Parse(data.value[k]));
                }
                else if (fields[i].FieldType == typeof(string))
                {
                    PlayerPrefs.SetString(data.names[k], data.value[k]);
                }
                else
                {
                    PlayerPrefs.SetFloat(data.names[k], float.Parse(data.value[k]));   
                }
            }
        }

        private void LoadData<T>(T data) where T : GameData
        {
            var fields = typeof(T).GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            for (int i = 0, k = 0; i < fields.Length - 2; i++,k++)
            {

                if (!PlayerPrefs.HasKey(data.names[k])) continue;

                if (fields[i].FieldType == typeof(int))
                {
                    data.value[k] = PlayerPrefs.GetInt(data.names[k]).ToString();
                }
                else if (fields[i].FieldType == typeof(string))
                {
                    data.value[k] = PlayerPrefs.GetString(data.names[k]);
                }
                else
                {
                    data.value[k] = PlayerPrefs.GetFloat(data.names[k]).ToString();
                }
            }
            data.Set();
        }

        public List<string> ReadText(string s)
        {
            List<string> script = new List<string>();
            
            TextAsset textfile = Resources.Load("testtxt") as TextAsset;
            ;
            StringReader stringReader = new StringReader(textfile.text);

            while (true)
            {
                string line = stringReader.ReadLine();
                if (line == null) break;
                
                script.Add(line);
            }

            return script;
        }
    }
}