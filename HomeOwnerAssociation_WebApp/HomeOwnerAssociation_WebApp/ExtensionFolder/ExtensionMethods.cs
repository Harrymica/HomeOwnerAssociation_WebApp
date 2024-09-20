namespace HomeOwnerAssociation_WebApp.ExtensionFolder
{
    public static class ExtensionMethods
    {


        
            private static Random random = new Random();

            public static string GenerateId()
            {
                const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                var id = new char[6];

                for (int i = 0; i < 6; i++)
                {
                    id[i] = chars[random.Next(chars.Length)];
                }

                return new string(id);
            }

        public static int GenerateIdByInt()
        {
            var random = new Random();
            return random.Next(100000, 999999);
        }

        
    }

    
}
