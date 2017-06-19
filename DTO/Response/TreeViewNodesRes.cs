using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TreeViewNodesRes
    {
        public string text { get; set; }
        public string nodeId { get; set; }
        //[JsonIgnore]
        public List<TreeViewNodesRes> nodes { get; set; }
    }
}
