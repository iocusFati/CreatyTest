using Base.UI.Factory;
using UnityEngine;

namespace Base.UI.Entities.Windows
{
    public class Window : MonoBehaviour
    {
        public virtual void Show() => 
            gameObject.SetActive(true);

        public virtual void Hide() => 
            gameObject.SetActive(false);
    }
}