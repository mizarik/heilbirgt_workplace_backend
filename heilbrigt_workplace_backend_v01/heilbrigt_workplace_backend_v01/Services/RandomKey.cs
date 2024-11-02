using System.Text;

namespace heilbrigt_workplace_backend_v01.Services
{
    public class RandomKey
    {
        public string RandomString { get; set; } = string.Empty;

        public static RandomKey RandomStringGen(int size)
        {
            const string pool = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ123456790";
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = pool[random.Next(0, pool.Length)]; ;
                builder.Append(ch);
            }

            return new RandomKey
            {
                RandomString = builder.ToString(),
            };

        } //RandomString
    }
}
