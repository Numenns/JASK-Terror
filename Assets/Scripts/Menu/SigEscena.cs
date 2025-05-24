using UnityEngine;
using UnityEngine.SceneManagement;

public class SigEscena : MonoBehaviour
{
   public string nombreEscena;

   public void LoadScene()
   {
      SceneManager.LoadScene(nombreEscena);
   }
    
}
