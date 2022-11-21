using System;
public static class Encryptor{
    public static string GetRandomPassword(int length)
    {
        char[] chars = "abcdefghijklmnopqrstuvwxyz1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        string password = string.Empty;
        Random random = new Random();
        int x;
        for (int i = 0; i < length; i++){
            x = random.Next(1, chars.Length);    
            if (!password.Contains(chars.GetValue(x).ToString()))
                password += chars.GetValue(x);
            else
                i=i-1;
        }
        return password;
    }

}
