using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KnowledgeBase.Models
{
    public class Issue
    {
        public int IssueID { get;set; }
        public string ProductVersion { get; set; }
        public string ErrorCode {get; set;}

        public string IssueHeader { get; set; }
        [AllowHtml]
        public string IssueText { get; set; }
        public string Username { get; set; } 
        public DateTime? DateIssueCreation { get; set; }
        [Required(ErrorMessage = "Please choose product name")]
        [Display(Name = "ProductName")]        
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }

    public class Product
    {
        [Display(Name = "ProductName")]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        
       public virtual  List<Issue> Issues { get; set; }

    }

    public class Solution
    {
        public int SolutionId { get; set; }
        [AllowHtml]
        public string SolutionText { get; set; }
        public string Username { get; set; }

        public DateTime DateSolutionCreation { get; set; }

        public int IssueID { get; set; }
        public virtual Issue Issue { get; set; }




    }


    public class AllModels
    {
        public Product Product { get; set; }
        public Issue Issue { get; set; }
        
    }

    public class SeachFilters
    {
        public int ProductId;
        public string Errorcode;
        public string Errorheader;
        public string Errortext;
    }
        

}