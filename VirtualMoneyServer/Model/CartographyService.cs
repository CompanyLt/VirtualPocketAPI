namespace VirtualPocket.Model
{
    public class CartographyService:ICartographyService
    {


        public string GetCartography(string mail)
        {


            return GetGuid(mail).ToString();
        }




        public Guid GetGuid(string input)
        {
            using (var md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] hash = md5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(input));
                return new Guid(hash);
            }
        }

    }
}
