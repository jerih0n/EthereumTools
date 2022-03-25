using System.Text;

namespace EthereumStamrtContracts.Logic.Utils
{
    public static class BytesArrayExtensions
    {
        public static string ToHex(this byte[] input)
        {
            StringBuilder builder = new StringBuilder();
            foreach (var oneByteOfKey in input)
            {
                builder.Append(BitConverter.ToString(new byte[] { oneByteOfKey }));
            }

            var privateKeyAsHex = builder.ToString();
            return privateKeyAsHex;
        }

        public static byte[] ToByteArray(this string input)
        {
            var keyLenght = input.Length;
            if (keyLenght % 2 != 0)
            {
                //invalid format
                throw new Exception("Invalid key passed");
            }
            List<byte> result = new List<byte>(keyLenght / 2);
            for (int i = 1; i < keyLenght; i += 2)
            {
                var resultByte = Convert.ToByte($"{input[i - 1]}{input[i]}", 16);
                result.Add(resultByte);
            }

            return result.ToArray();
        }
    }
}