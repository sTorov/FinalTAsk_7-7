namespace Order
{
    static class StringExtensions
    {
        public static string Initial(this string str)
        {
            if(str == null)
                return null;
            if (str == String.Empty)
                return null;

            char simbol = str[0];
            return (simbol.ToString() + ".").ToUpper();
        }
    }
}
