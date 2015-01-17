using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BestPracticesSampleProject.Web.Models
{
    public class Project
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("departmentId")]
        public int DepartmentId { get; set; }

        [IgnoreDataMember]
        public virtual Department Department { get; set; }
    }
}