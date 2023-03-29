using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class UIManager : MonoBehaviour
{
    GameObject _loadingPanel;

    bool _isVisible=false;
    private void Awake()
    {
        _loadingPanel = Resources.Load<GameObject>("Prefabs/pnlLoading");

    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                gameObject.GetComponent<Canvas>().enabled = _isVisible;
                _isVisible = !_isVisible;
            }
        }
    }
    public void StartGame( Button button)
    { 
        SceneLoader(1);
    }

    public void EndGame()
    {
        SceneLoader(0);
    }
    
    void SceneLoader(int SceneIndex)
    {
        StartCoroutine(LoadScene(SceneIndex));
    }

    IEnumerator LoadScene(int SceneIndex)
    {
        GameObject loadpnl = Instantiate(_loadingPanel, transform);
        Image loadbar = loadpnl.GetComponent<LoadingPanelController>().GetLoadBar();

        AsyncOperation op = SceneManager.LoadSceneAsync(SceneIndex);
        while (!op.isDone)
        {
            loadbar.rectTransform.localScale = new Vector3(op.progress, 1f,1);
            yield return null;
        }
    }

}
