using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BestPracticesSampleProject.Web.Models
{
    public class Department
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [IgnoreDataMember]
        public virtual ICollection<Project> Projects { get; set; }
    }
}