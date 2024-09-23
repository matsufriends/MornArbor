#if USE_MORN_SCENE
using Arbor;
using MornScene;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MornArbor.Action
{
    public class LoadSceneAction : StateBehaviour
    {
        [SerializeField] private MornSceneObject _scene;
        [SerializeField] private LoadSceneMode _loadSceneMode;

        public override void OnStateBegin()
        {
            SceneManager.LoadSceneAsync(_scene, _loadSceneMode);
        }
    }
}
#endif