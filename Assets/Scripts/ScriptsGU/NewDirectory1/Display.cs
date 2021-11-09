using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace Geekbrains.NewDirectory1
{
    internal sealed class Display
    {
        private readonly IUser _user;
        private readonly Text _text;

        public Display(IUser user)
        {
            _user = user;
            _user.OnHpChange += UserOnHpChange;
            _text = Object.FindObjectOfType<Text>();
        }

        private void UserOnHpChange(float obj)
        {
            _text.text = obj.ToString();
        }

        ~Display()
        {
            _user.OnHpChange -= UserOnHpChange;
        }
    }
}
