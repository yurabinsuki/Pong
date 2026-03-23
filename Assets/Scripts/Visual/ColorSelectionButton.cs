using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ColorSelectionButton : MonoBehaviour
{
    public GameSettings gameSettings;

    public PlayerPaddleController.PlayerID playerID;

    public SpriteRenderer menuPreview;

    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    public void OnButtonClick()
    {
        Color selectedColor = button.colors.normalColor;

        if (playerID == PlayerPaddleController.PlayerID.PlayerOne)
        {
            gameSettings.playerOneColor = selectedColor;
        }
        else
        {
            gameSettings.playerTwoColor = selectedColor;
        }

        if (menuPreview != null)
        {
            menuPreview.color = selectedColor;
        }
    }
}