using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Test_CSV
{
    public class ViewController : MonoBehaviour
    {
        public int viewIndex;
        [ShowInInspector, ReadOnly] UserData userData;
        [SerializeField] GameManager gameManager;

        [Inject]
        void Init(GameManager gameManager, UserData userData) {
			this.gameManager = gameManager;
			this.userData = userData;
		}


        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        [Button]
        void CheckUserData()
        {
            if (userData == null)
            {
                Debug.Log("Null userdata");
            }
        }
    }
}
