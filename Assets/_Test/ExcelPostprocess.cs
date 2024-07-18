using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cathei.BakingSheet.Unity;
using Cathei.BakingSheet;
using System;
using System.IO;
using Sirenix.OdinInspector;
using System.Threading.Tasks;
using Sirenix.Serialization;
using NonSerializedAttribute = System.NonSerializedAttribute;
using Cathei.BakingSheet.Internal;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Test_CSV
{
#if UNITY_EDITOR
    public class ExcelPostprocess : SerializedMonoBehaviour
    {
        [OdinSerialize, NonSerialized]
        public SheetInfo[] sheetInfos;

        public class ExportSheetEditor
        {
            [Sirenix.OdinInspector.FilePath]
            [ShowInInspector]
            public static string exportPrefabPath = "Assets/Config/Excels/ExportSheet.prefab";

            [MenuItem("Test/Export map sheet data. #&w")]
            static async void ExportMapSheetData()
            {
                var exportSheet = AssetDatabase.LoadAssetAtPath<ExcelPostprocess>(exportPrefabPath);

                foreach (var sheetInfo in exportSheet.sheetInfos)
                {
                    foreach (var config in sheetInfo.dataConfigs)
                    {
                        await Export(config, sheetInfo.excelPath);
                    }
                }
            }

            public static async Task Export(IExcelImportable config, string upgradeExcelPath)
            {
                var sheetContainer = new SheetContainer();
                var excelPath = Path.GetDirectoryName(upgradeExcelPath);

                bool hasPath = File.Exists(upgradeExcelPath);

                // create excel converter from path
                var excelConverter = new ExcelSheetConverter(excelPath, TimeZoneInfo.Utc);

                // bake sheets from excel converter
                await sheetContainer.Bake(excelConverter);

                // (optional) verify that data is correct
                sheetContainer.Verify(
#if BAKINGSHEET_ADDRESSABLES
                    new AddressablePathVerifier(),
#endif
                    new ResourcePathVerifier()
                );

                UpdateSO(config, sheetContainer);
            }

            static async void UpdateSO(IExcelImportable excelImportConfig, SheetContainer sheetContainer)
            {
                switch (excelImportConfig)
                {
                    case MasterProductConfig _:
                        {
                            var config = excelImportConfig as MasterProductConfig;
                            foreach (var row in sheetContainer.MasterProductConfigSheet)
                                excelImportConfig.ImportDataFromExcel(row);
                            config.CheckForDeleteConfigInExcel();
                            break;
                        }
                }

                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();
            }

            [MenuItem("Test/Open persistent path.")]
            static void OpenPersistentPath()
            {
                Application.OpenURL(Application.persistentDataPath);
            }

            [MenuItem("Test/Clear persistent path.")]
            static void ClearPersistentPath()
            {
                System.IO.DirectoryInfo di = new DirectoryInfo(Application.persistentDataPath);

                foreach (FileInfo file in di.GetFiles())
                {
                    file.Delete();
                }
                foreach (DirectoryInfo dir in di.GetDirectories())
                {
                    dir.Delete(true);
                }
            }
        }

        [Serializable]
        public class SheetInfo
        {
            public string excelPath;
            [ListDrawerSettings]
            public List<IExcelImportable> dataConfigs;

            [Button]
            public async void ImportSheetData()
            {
                var exportSheet = AssetDatabase.LoadAssetAtPath<ExcelPostprocess>(ExportSheetEditor.exportPrefabPath);

                foreach (var config in dataConfigs)
                {
                    await ExportSheetEditor.Export(config, excelPath);
                }
            }
        }
#endif
    }
}
