using Sirenix.OdinInspector;
using UnityEngine;
using System;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Test_CSV
{
    [InlineEditor]
    [CreateAssetMenu(fileName = "ProductConfig", menuName = "Config/ProductConfig")]
    public class ProductConfig : ScriptableObject
    {
        [SerializeField] ProductType _type;
        [SerializeField] int _salePrice;
        [SerializeField] float _height;
        [PreviewField(Alignment = ObjectFieldAlignment.Left)]
        [SerializeField] Sprite _sprite;

        public ProductType ProductType { get => _type; private set => _type = value; }
        public int SalePrice { get => _salePrice; set => _salePrice = value; }

        public float Height { get => _height; private set => _height = value; }
        public Sprite Sprite { get => _sprite; private set => _sprite = value; }

#if UNITY_EDITOR
        public void RenameAsset()
        {
            name = _type.ToString();
            EditorUtility.SetDirty(this);
        }

        public void SetupConfig(ProductConfigData data)
        {
            _type = data.type;
            _salePrice = data.salePrice;
            _sprite = data.sprite;
            _height = data.height;
        }

        //[Button]
        public void Delete()
        {
            DestroyImmediate(this, true);
        }
#endif

    }
}

[Serializable]
public class ProductConfigData
{
    public ProductType type;
    public int salePrice;
    public Sprite sprite;
    public float height = 0.2f;
}

public enum ProductType
{
    Apple,
    Wheat,
    Milk,
    Egg,
    AppleJam,
    Flour,
    Bread,
}

public enum StaffType
{
    Staff_1,
    Staff_2,
    Player,
}
