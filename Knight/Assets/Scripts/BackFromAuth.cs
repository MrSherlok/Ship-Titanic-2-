using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BackFromAuth : MonoBehaviour {

    public void Return()
    {
        SceneManager.LoadScene("tryMe");
    }
}
