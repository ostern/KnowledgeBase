using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KnowledgeBase.Models;

namespace KnowledgeBase.ViewModel
{
    public class IssueDetails
    {
        public Issue Issue { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public Solution Solutions { get; set; }
              
    }
    public class IssueSearch
    {
        public Issue Issue { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public SeachFilters SeachFilters { get; set; }
    }

    public class IssueSolution
    {
        public Issue Issue { get; set; }
     //   public IEnumerable<Product> Products { get; set; }
        public List<Solution> Solutions { get; set; }
        public Solution Solution { get; set; }
    }


}