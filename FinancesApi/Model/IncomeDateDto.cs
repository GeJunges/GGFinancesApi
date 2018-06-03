using System;
using System.Collections.Generic;

namespace FinancesApi.Model {
    public class IncomeDateDto {
        public string Id { get; set; }
        public RegisterDto RegisterDto { get; set; }
        public DateTime Date { get; set; }

        public double? Value { get; set; }

    }
}