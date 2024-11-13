using UnityEngine;

namespace Code.UI
{
    public class UI_Manager : MonoBehaviour
    {
        [SerializeField] private Transform MainMenu;

        public void ShowMainMenu()
        {
            MainMenu.gameObject.SetActive(true);
        }

        public void HideMainMenu()
        {
            MainMenu.gameObject.SetActive(false);
        }
        
        
    }
}
