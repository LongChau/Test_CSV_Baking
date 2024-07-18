using Cathei.BakingSheet;
using Cathei.BakingSheet.Unity;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using Ultility;

namespace Test_CSV
{
    [CreateAssetMenu(fileName = "MasterProductConfig", menuName = "Config/MasterProductConfig")]
    public class MasterProductConfig : SerializedScriptableObject, IExcelImportable
    {
        [Title("Data section:")]
        [OdinSerialize] Dictionary<ProductType, ProductConfig> _productConfigs = new Dictionary<ProductType, ProductConfig>();

        public ProductConfig GetProductConfigByType(ProductType type)
        {
            ProductConfig config = null;
            _productConfigs.TryGetValue(type, out config);
            return config;
        }

#if UNITY_EDITOR
        [Title("Button section:")]
        [Button("Add", Name = "Add")]
        public void CreateConfig(ProductConfigData configData)
        {
            if (_productConfigs.ContainsKey(configData.type))
            {
                Log.InfoRed($"Lỗi nè: Đã có product với loại {configData.type} này rồi.");
                return;
            }

            ProductConfig product = ScriptableObject.CreateInstance<ProductConfig>();
            product.SetupConfig(configData);
            product.name = product.ProductType.ToString();

            _productConfigs.Add(product.ProductType, product);
            AssetDatabase.AddObjectToAsset(product, this);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();

            Log.InfoYellow($"Tạo thành công product: {configData.type}", product);
        }

        [InfoBox("Delete product config.")]
        [Button("Delete", Name = "Delete")]
        public void DeleteConfig(ProductConfig config)
        {
            if (!_productConfigs.ContainsKey(config.ProductType))
            {
                Log.InfoRed($"Lỗi nè: Chưa có loại {config.ProductType}.");
                return;
            }

            Log.InfoYellow($"Xóa thành công product: {config.ProductType}");
            _productConfigs.Remove(config.ProductType);
            config.Delete();
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }

        [Button(Expanded = true)]
        public void ImportProductConfig(ProductConfig config)
        {
            var configPath = AssetDatabase.GetAssetPath(config);
            var currentPath = AssetDatabase.GetAssetPath(this);

            Log.EditorInfoYellow($"configPath: {configPath}");
            Log.EditorInfoYellow($"currentPath: {currentPath}");
        }

        Dictionary<ProductType, bool> _updatedProducts = new Dictionary<ProductType, bool>();
        public void ImportDataFromExcel(SheetRow sheetRow)
        {
            Log.EditorInfoYellow($"MasterProductConfig:ImportDataFromExcel()");
            var row = sheetRow as MasterProductConfigSheet.Row;
            var productType = (ProductType)Enum.Parse(typeof(ProductType), row.Id.Trim());
            if (_productConfigs.ContainsKey(productType))
            {
                Log.EditorInfoYellow($"Has this product {productType}. Updating...", _productConfigs[productType]);
                _productConfigs[productType].SalePrice = row.SalePrice;
                Log.EditorInfoYellow($"Update completed. Please double check this product {productType} for sprite, height in Unity", _productConfigs[productType]);
                _updatedProducts.Add(productType, true);
            }
            else
            {
                // Log.Error($"Missing this product {productType}");
                // Log.EditorInfoRed($"Auto create product {productType}. Please check sprite, height in Unity later.");
                ProductConfigData data = new ProductConfigData();
                data.type = productType;
                data.salePrice = row.SalePrice;
                CreateConfig(data);
                _updatedProducts.Add(productType, true);
            }
            EditorUtility.SetDirty(this);
        }

        public void CheckForDeleteConfigInExcel()
        {
            // Check if there is config that does not in this MasterProductConfig, removed by Excel.
            foreach (var config in _productConfigs)
            {
                if (!_updatedProducts.ContainsKey(config.Key))
                {
                    // This mean the product is removed by Excel.
                    Log.EditorInfoRed($"Delete this product {config.Key}");
                    //DeleteConfig(_productConfigs[config.Key]);
                }
            }
            ResetProductUpdated();
        }

        public void ResetProductUpdated()
        {
            _updatedProducts.Clear();
        }

        internal void ResetConfig()
        {
            if (_productConfigs == null)
                _productConfigs = new Dictionary<ProductType, ProductConfig>();
            _productConfigs.Clear();
            EditorUtility.SetDirty(this);
        }

        //[Button()]
        //void ImportConfigs()
        //{
        //    foreach (var product in _productConfigs.Values)
        //    {
        //        var config = UnityEngine.Object.Instantiate(product);
        //        config.name = config.name.Replace("(Clone)", "");
        //        AssetDatabase.AddObjectToAsset(config, this);
        //    }
        //    EditorUtility.SetDirty(this);
        //    AssetDatabase.SaveAssets();
        //    AssetDatabase.Refresh();
        //}
#endif
    }
}
