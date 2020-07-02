using System;

namespace TkuOisAzFunc120096 {
    public class Employee {
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public string EmplName { get; set; }
        public string EmpEmail { get; set; }
        public DateTime Timestamp { get; set; }
    }
}