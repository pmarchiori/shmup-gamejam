// using UnityEngine;
// using UnityEngine.UI;

// namespace Shmup
// {
//     public class WeaponSelectionMenu : MonoBehaviour
//     {
//         [SerializeField] private PlayerWeapon playerWeapon; // Referência ao PlayerWeapon
//         [SerializeField] private WeaponStrategy singleShotStrategy;
//         [SerializeField] private WeaponStrategy tripleShotStrategy;
//         [SerializeField] private Button singleShotButton;  // Botão para selecionar SingleShot
//         [SerializeField] private Button tripleShotButton;  // Botão para selecionar TripleShot

//         void Start()
//         {
//             // Atribui os métodos aos botões
//             singleShotButton.onClick.AddListener(SelectSingleShot);
//             tripleShotButton.onClick.AddListener(SelectTripleShot);
//         }

//         public void SelectSingleShot()
//         {
//             playerWeapon.SetWeaponStrategy(singleShotStrategy);
//         }

//         public void SelectTripleShot()
//         {
//             playerWeapon.SetWeaponStrategy(tripleShotStrategy);
//         }
//     }
// }
