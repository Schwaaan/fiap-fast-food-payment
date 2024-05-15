using System.Globalization;
using System.Text;

namespace FourSix.Domain.ExtensionsMethods
{
    public static class StringExtension
    {
        public static string RemoverAcentos(this string texto)
        {
            var sbReturn = new StringBuilder();
            var arrayText = texto.Normalize(NormalizationForm.FormD).ToCharArray();
            foreach (char letter in arrayText)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(letter) != UnicodeCategory.NonSpacingMark)
                    sbReturn.Append(letter);
            }
            return sbReturn.ToString();
        }
    }
}
