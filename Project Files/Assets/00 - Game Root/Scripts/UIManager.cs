using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class UIManager : MonoBehaviour
{

    [SerializeField]
    Image _loadbar;

    public void StartGame( Button button)
    { 
        SceneLoader(1);

        button.GetComponent<GameObject>().SetActive(false);

    }

    public void EndGame()
    {
        SceneLoader(0);
    }
    
    void SceneLoader(int SceneIndex)
    {
        StartCoroutine(LoadScreenControl(SceneIndex));
    }

    IEnumerator LoadScreenControl(int SceneIndex)
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(SceneIndex);
        while (!op.isDone)
        {
           ;
            _loadbar.rectTransform.localScale = new Vector3(op.progress, 0.1f,1);
            Debug.Log(op.progress);
            yield return null;
        }
    }
}
