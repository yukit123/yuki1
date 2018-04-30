using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Tree
    {
        public int Id { get; set; }

        public int NodeId { get; set; }
        public string Name { get; set; }
        public List<Tree> Treeinfo { get; set; }
    }
}