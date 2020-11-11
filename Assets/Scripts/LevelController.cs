using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{


    private static int _nextLevelIndex = 1; //int is for whole number. Static - for every level controller that we have they're all gonna reference this same variable.
    private Enemy[] _enemies; //sa baba ito galing. Array - more than one. Underscore(_) is naming convention, not part class/parameter, part of field in my class.
    private void OnEnable() //turn on - LevelController -> run. Off - on  again ->run 
    {
        _enemies = FindObjectsOfType<Enemy>(); // Save all enemies in the scene. Find - enemies available, once dead - time to go to the next level
    }                                           // Save enemies into special variable/ an array of enemies.
                                                // Objects' suffix "s", plural version - to find al of "them". Singular ver. - return back to the first enemy, not a collection of enemies.
                                                // Update is called once per frame


    void Update()
    {
        foreach (Enemy enemy in _enemies)  // _enemy -> loop over/ go through each enemy(variable) and run the code, want to do something - each enemies. if文で
        {
            // 1st enemy through, 2nd enemy through, 3rd enemy through.
            if (enemy != null)

                return;         // if alive we don't want to finish.
        }

        Debug.Log("You killed all enemies yuuhuu!");

        //Invoke("ReturnToTitle", 2.0f);
        //SceneManager.LoadScene("Title");



        _nextLevelIndex++;
        string nextLevelName = "Level" + _nextLevelIndex;
        //Debug.Log(nextLevelName);
        //punta sa next level
        SceneManager.LoadScene(nextLevelName);  //SceneManager.LoadSceneを使うためには、1.SceneManagement名前空間の追加2.遷移を行うSceneをBuild Settingsに追加が必要です。
    }                  //    SceneManager.LoadSceneが取る引数としては、1.Sceneの名前 - refers to text example: Blue 2.BuildIndex - refers to numbers like 1
}
