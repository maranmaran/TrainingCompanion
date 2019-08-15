using System.Text;

namespace Backend.Common
{
    /// <summary>
    /// Fluent constructor of generic google like avatar image.
    /// More documentation on https://ui-avatars.com/
    /// </summary>
    public class GenericAvatarConstructor
    {


        private readonly string _baseUrl = "https://ui-avatars.com/api/?";
        private readonly StringBuilder _constructedUrl;

        public GenericAvatarConstructor()
        {
            _constructedUrl = new StringBuilder(_baseUrl);
        }

        public GenericAvatarConstructor AddName(string fullName)
        {
            var splittedName = fullName.Split(' ');
            var nameVariable = splittedName.Length > 1 ? string.Join("+", splittedName) : splittedName[0];

            _constructedUrl.Append($"name={nameVariable}&");

            return this;
        }

        public GenericAvatarConstructor Round()
        {
            _constructedUrl.Append($"rounded={true}&");

            return this;
        }

        public GenericAvatarConstructor Background(params string[] hexColors)
        {
            string hexColor;
            if (hexColors.Length == 1)
            {
                hexColor = hexColors[0];
                hexColor = hexColor[0] == '#' ? hexColor.Substring(1) : hexColor;
            }
            else
            {
                hexColor = Utils.GetRandomHexColor(false, hexColors); // don't use hash
            }

            _constructedUrl.Append($"background={hexColor}&");

            return this;
        }

        public GenericAvatarConstructor Foreground(string hexColor = null)
        {
            if (hexColor != null)
            {
                hexColor = hexColor[0] == '#' ? hexColor.Substring(1) : hexColor;
            }
            else
            {
                hexColor = Utils.GetRandomHexColor(false); // don't use hash
            }

            _constructedUrl.Append($"color={hexColor}&");

            return this;
        }

        public GenericAvatarConstructor BoldFont()
        {
            _constructedUrl.Append($"bold={true}&");

            return this;
        }

        public string Value()
        {
            return _constructedUrl.ToString();
        }
    }
}
