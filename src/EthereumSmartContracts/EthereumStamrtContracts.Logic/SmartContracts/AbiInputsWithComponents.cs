﻿using Newtonsoft.Json;

namespace EthereumStamrtContracts.Logic.SmartContracts
{
    public class AbiInputsWithComponents
    {
        [JsonProperty("components")]
        public List<AbiInputs> Components { get; set; }
    }
}