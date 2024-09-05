using System.Text;

namespace Entities.Models
{
    public class User
    {
        public string Id { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; } = DateTime.Now;
        public string WorkPlace { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public List<CreditCard> Cards { get; set; } = new List<CreditCard>();
        public string Fio => $"{LastName} {FirstName} {MiddleName}";

        private static Dictionary<string, string> _replacements = new Dictionary<string, string>()
        {
            { "аЯ ", "aYa " },
            { "аЯ", "aYa" },
            { "оЯ ", "oYa " },
            { "оЯ", "oYa" },
            { "еЯ ", "eYa " },
            { "еЯ", "eYa" },
            { "иЯ ", "iYa " },
            { "иЯ", "iYa" },
            { "уЯ ", "uYa " },
            { "уЯ", "uYa" },
            { "аЮ ", "aYu " },
            { "аЮ", "aYu" },
            { "оЮ ", "oYu " },
            { "оЮ", "oYu" },
            { "еЮ ", "eYu " },
            { "еЮ", "eYu" },
            { "иЮ ", "iYu " },
            { "иЮ", "iYu" },
            { "уЮ ", "uYu " },
            { "уЮ", "uYu" },
            { "аЁ ", "aYo " },
            { "аЁ", "aYo" },
            { "оЁ ", "oYo " },
            { "оЁ", "oYo" },
            { "еЁ ", "eYo " },
            { "еЁ", "eYo" },
            { "иЁ ", "iYo " },
            { "иЁ", "iYo" },
            { "уЁ ", "uYo " },
            { "уЁ", "uYo" },
            { "аЕ ", "aYe " },
            { "аЕ", "aYe" },
            { "оЕ ", "oYe " },
            { "оЕ", "oYe" },
            { "еЕ ", "eYe " },
            { "еЕ", "eYe" },
            { "иЕ ", "iYe " },
            { "иЕ", "iYe" },
            { "уЕ ", "uYe " },
            { "уЕ", "uYe" },
            { "А", "A" },
            { "Б", "B" },
            { "В", "V" },
            { "Г", "G" },
            { "Д", "D" },
            { " Е", " yE" },
            { "ьЕ", "yE" },
            { "ъЕ", "yE" },
            { "Е", "e" },
            { " Ё", " yo" },
            { "ьЁ", "yo" },
            { "ъЁ", "yo" },
            { "Ё", "'o" },
            { "Ж", "jh" },
            { "З", "z" },
            { "И", "i" },
            { "Й", "y" },
            { "К", "k" },
            { "Л", "l" },
            { "М", "m" },
            { "Н", "n" },
            { "О", "o" },
            { "П", "p" },
            { "Р", "r" },
            { "С", "s" },
            { "Т", "t" },
            { "У", "u" },
            { "Ф", "f" },
            { "Х", "kh" },
            { "Ц", "ts" },
            { "Ч", "ch" },
            { "Ш", "sh" },
            { "Щ", "sch" },
            { "Ы", "i" },
            { "Э", "e" },
            { " Ю", " Yu" },
            { "ьЮ", "Yu" },
            { "ъЮ", "Yu" },
            { "Ю", "u" },
            { " Я", " Ya" },
            { "ьЯ", "Ya" },
            { "ъЯ", "Ya" },
            { "Я", "a" },
            { "Ъ", "" },
            { "Ь", "" },
        };

        public static string ToLat(string text)
        {
            StringBuilder stringBuilder = new StringBuilder();
            string result = text;

            foreach (var replacement in _replacements)
            {
                if(result.Contains(replacement.Key, StringComparison.OrdinalIgnoreCase))
                {
                    result = result.Replace(replacement.Key, replacement.Value, StringComparison.OrdinalIgnoreCase);
                }
            }

            for (int i = 0; i < result.Length; i++)
            {
                if(i == 0 || result[i - 1] == ' ')
                {
                    stringBuilder.Append(result[i].ToString().ToUpper());
                }
                else
                {
                    stringBuilder.Append(result[i].ToString().ToLower());
                }
            }

            return stringBuilder.ToString();
        }

    }
}
