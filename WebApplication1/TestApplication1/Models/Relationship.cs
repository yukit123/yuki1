using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestApplication1.Models
{
    public class Relationship
    {
        public int Id { get; set; }
        public string RelationshipName { get; set; }
        public RelationshipType relationshipType { get; set; }
    }

    public enum RelationshipType : int
    {
        Spouse = 1,
        Child = 2,
        Parent = 3,
        Sibling = 4,
        Guardian = 5,
        Other = 6,
        Self = 7
    }
}