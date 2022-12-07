using UnityEngine;
using UnityEngine.UI;

namespace Hole.Runtime.Features.UI
{
    public class TextSetter : MonoBehaviour
    {
        public Text Text;

        public void SetTextValue(string value) => 
            Text.text = value;
    }
}
