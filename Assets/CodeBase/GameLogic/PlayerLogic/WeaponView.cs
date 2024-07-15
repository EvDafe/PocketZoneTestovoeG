using UnityEngine;

namespace Assets.CodeBase.GameLogic.PlayerLogic
{
    public class WeaponView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _sprite;

        public void SetView(Sprite sprite) => 
            _sprite.sprite = sprite;
    }
}
