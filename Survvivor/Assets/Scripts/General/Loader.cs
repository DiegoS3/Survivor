
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
    public static Loader Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public enum Scene
    {
        LevelOne,
        LevelTwo,
        LevelThree,
        LevelFour,
        LoginSignUp,
        MainMenu,
        OptionsScene,
        PauseMenu,
        SelectLevel
    };

    private void Load(Scene scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }

    public void LoginSignUp()
    {
        Load(Scene.LoginSignUp);
    }

    public void MainMenu()
    {
        Load(Scene.MainMenu);
    }

    public void LevelOne()
    {
        Load(Scene.LevelOne);
    }

    public void LevelTwo()
    {
        Load(Scene.LevelTwo);
    }

    public void LevelThree()
    {
        Load(Scene.LevelThree);
    }

    public void LevelFour()
    {
        Load(Scene.LevelFour);
    }

    public void SelectionLevel()
    {
        Load(Scene.SelectLevel);
    }

    public void Options()
    {
        Load(Scene.OptionsScene);
    }

    public void Pause()
    {
        Load(Scene.PauseMenu);
    }

    public void Salir()
    {
        Load(Scene.MainMenu);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
