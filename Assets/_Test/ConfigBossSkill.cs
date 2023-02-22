using Cathei.BakingSheet;
using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using UnityEngine;

namespace Test_CSV
{
    // Base on https://github.com/cathei/BakingSheet
    [CreateAssetMenu(fileName = "ConfigBossSkill", menuName = "Config/ConfigBossSkill")]
    public class ConfigBossSkill : ScriptableObject
    {
        [FilePath]
        public string assetPath;

        public string id;
        public string idLog;
        public string skillName;
        public string buffName;
        public int skillChance;
        public float value1;
        public float value2;
        public float value3;
        public float value4;
        public float value5;

        [Button]
        async void GetDataFromCSV()
        {
            var sheetContainer = new SheetContainer();

            var csvPath = Path.GetDirectoryName(assetPath);
            var resultPath = Path.Combine(Application.streamingAssetsPath, "CSV");

            // create csv converter from path
            var csvImporter = new CsvSheetConverter(csvPath, TimeZoneInfo.Utc);

            // bake sheets from csv converter
            await sheetContainer.Bake(csvImporter);

            Debug.Log($"Get data from {sheetContainer.ConfigBossSkill}");   
            Debug.Log(sheetContainer.ConfigBossSkill["Value1"]);

            foreach (var row in sheetContainer.ConfigBossSkill)
            {
                Debug.Log("-----");
                //Debug.Log($"row.Id = {row.Id}");
                //Debug.Log($"row.IdLog = {row.IdLog}");
                //Debug.Log($"row.SkillName = {row.SkillName}");
                //Debug.Log($"row.BuffName = {row.BuffName}");
                Debug.Log($"row.JSON = {row.ToJSON()}");
                Debug.Log("-----");

            }
        }
    }
}
