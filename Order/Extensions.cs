namespace Order
{
    static class StringExtensions
    {
        public static string Initial(this string str)
        {
            if(str == null || str == String.Empty)
                return null;

            char simbol = str[0];
            return (simbol.ToString() + ".").ToUpper();
        }
    }    
}

