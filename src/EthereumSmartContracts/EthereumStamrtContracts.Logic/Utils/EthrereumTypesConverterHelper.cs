using System.Numerics;

namespace EthereumStamrtContracts.Logic.Utils
{
    public static class EthrereumTypesConverterHelper
    {
        public static object Convert(string typeName, string value)
        {
            if (typeName.StartsWith("uint") || typeName.StartsWith("int"))
            {
                return BigInteger.Parse(value);
            }
            if (typeName.StartsWith("bytes"))
            {
                return value.ToByteArray();
            }

            switch (typeName)
            {
                case "bool":
                    return bool.Parse(value);

                case "address":
                    return value;

                case "string":
                    return value;

                default:
                    return value;
            }
        }
    }
}