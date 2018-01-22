using System;

namespace CodePasswordDLL
{
    public class CodePassword
    {
        public static string getPassword(string p_sPassw)
        {
            if (p_sPassw == null) throw new NullReferenceException("Значение не может быть пустым");
            string password = "";
            foreach (char a in p_sPassw)
            {
                char ch = a;
                ch--;
                password += ch;
            }
            return password;
        }

        public static string getCodPassword(string p_sPassword)
        {
            if (p_sPassword == null) throw new NullReferenceException("Значение не может быть пустым");
            string sCode = "";
            foreach (char a in p_sPassword)
            {
                char ch = a;
                ch++;
                sCode += ch;
            }
            return sCode;
        }
    }
}
