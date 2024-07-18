using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer;

namespace Test_CSV
{
    public class GameManager : MonoBehaviour
    {
        [ShowInInspector, ReadOnly] UserData userData;

        [Inject]
        void Init(UserData userData)
        {
            this.userData = userData;
        } 

        // Start is called before the first frame update
        void Start()
        {
            userData.levelScene = SceneManager.GetActiveScene().buildIndex;
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

        [Button]
        void SwitchScene(int index)
        {
            SceneManager.LoadSceneAsync(index);
            userData.levelScene = index;
        }
    }
}
