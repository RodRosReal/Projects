using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.ValueObjects
{
    public class GetClientItemsResponse
    {
        public GetClientItemsResponse()
        {
            this.ClientItems = new ClientItems();
        }
        
        [JsonProperty(PropertyName = "Value")]
        public ClientItems ClientItems { get; set; }
    }

    public class ClientItems
    {
        [JsonProperty(PropertyName = "TotalRowCount")]
        public int TotalRowCount { get; set; }

        [JsonProperty(PropertyName = "Rows")]
        public List<ClientItem> Rows { get; set; }
    }

    public class ClientItem
    {
        [JsonProperty(PropertyName = "ID")]
        public int ID { get; set; }
        [JsonProperty(PropertyName = "Codigo")]
        public string Codigo { get; set; }
        [JsonProperty(PropertyName = "Descricao")]
        public string Descricao { get; set; }
        [JsonProperty(PropertyName = "Fornecedor")]
        public string Fornecedor { get; set; }
        [JsonProperty(PropertyName = "MascaraID")]
        public int MascaraID { get; set; }
        [JsonProperty(PropertyName = "Mascara")]
        public string Mascara { get; set; }
        [JsonProperty(PropertyName = "Configurado")]
        public string Configurado { get; set; }
    }



    public class GetClientItemsRequest
    {
        [JsonProperty(PropertyName = "codigoCliente")]
        public int CodigoCliente { get; set; }
        [JsonProperty(PropertyName = "cnpjCpf")]
        public long CnpjCpf { get; set; }
        [JsonProperty(PropertyName = "skip")]
        public int Skip { get; set; }
        [JsonProperty(PropertyName = "take")]
        public int Take { get; set; }
    }
}
