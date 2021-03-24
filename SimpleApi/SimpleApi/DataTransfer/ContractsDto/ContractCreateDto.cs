using System;
using System.Collections.Generic;

namespace SimpleApi.DataTransfer.ContractsDto
{
    public class ContractCreateDto
    {
        public int CustomerId { get; set; }

        public int DeliveryId { get; set; }

        public DateTime Date { get; set; }

        public IEnumerable<int> ItemId { get; set; }
    }
}