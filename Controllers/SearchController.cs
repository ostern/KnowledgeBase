using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using KnowledgeBase.DAL;
using KnowledgeBase.Models;
using KnowledgeBase.ViewModel;


namespace KnowledgeBase.Controllers
{
    public class SearchController : Controller
    {
        private BaseContext _context;

        public SearchController()
        {
            _context = new BaseContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Search()
        {
            
            var products = _context.Products.ToList();
            var issueModel = new IssueDetails
            {
                Products = products
            };

            return View(issueModel);
        }
       

        public ActionResult NewIssue()
        {
            var products = _context.Products.ToList();
            
            var issueModel = new IssueDetails
            {
                Products = products
            };
            return View(issueModel);
        }

        [HttpPost]
        public ActionResult Create(Issue issue)
        {
            
            issue.Username = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            issue.DateIssueCreation = DateTime.Now;
            _context.Issues.Add(issue);
            _context.SaveChanges();
            return RedirectToAction("Search", "Search");
        }
        public ActionResult Edit(Issue issue)
        {
            var issuedetailed = _context.Issues.SingleOrDefault(x => x.IssueID == issue.IssueID);
     //       issue.Username = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            issue.DateIssueCreation = DateTime.Now;
            //  _context.Issues.Add(issue);
            issuedetailed = issue;
            _context.SaveChanges();
            return RedirectToAction("Search", "Search");
        }
        public ActionResult AddSolution(int id)
        {
            var issuedetailed = _context.Issues.Where(x => x.IssueID == id).Include(c => c.Product).FirstOrDefault();
            var solutions = _context.Solutions.Where(x => x.IssueID == id).ToList();
            var solution = new Solution() {IssueID = id};     
            //if (solution.Count > 0)
 //           {
                var solutionModel = new IssueSolution
                {
                    Issue = issuedetailed,
                    Solutions = solutions,
                    Solution = solution
                };
                return View(solutionModel);
            }


//            return View(issuedetailed);
            
  //      }

        public ActionResult SaveSolution(Solution solution)
        {

            solution.Username = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            solution.DateSolutionCreation = DateTime.Now;
            _context.Solutions.Add(solution);
            _context.SaveChanges();
            return RedirectToAction("Search", "Search");
        }

        public List<Issue> SIssue(Issue issue)
        {
            //     var listofissues = _context.Issues
            //         .Where(x => x.ProductId == prodid);
            var listofissues = _context.Issues.Include(x => x.Product)
                    .Where(x => x.ProductId == issue.ProductId);
            //       if (issue.ProductId != 0)
            //       {
            //           listofissues = listofissues
            //               .Where(x => x.ProductId == issue.ProductId);
            //       }



            if (issue.ErrorCode != null)
            {
                //       errorcode = issue.ErrorCode;
                listofissues = listofissues.Where(x => x.ErrorCode.Contains(issue.ErrorCode.ToLower()));
            }
            if (issue.IssueHeader != null)
            {
                //        headertext = issue.IssueHeader;
                listofissues = listofissues.Where(x => x.IssueHeader.Contains(issue.IssueHeader.ToLower()));
            }
            if (issue.IssueText != null)
            {
                //   text = issue.IssueText;
                listofissues = listofissues.Where(x => x.IssueText.Contains(issue.IssueText.ToLower()));
                //  listofissues.Where(p => SqlFunctions.PatIndex("%" + issue.IssueText.ToLower() + "%", p.IssueText) > 0);
            }
            // var listofissues = _context.Issues.SqlQuery("select * from Isues where")
            //      .Where(x => x.ProductId == prodid)
            //      .Where(k => k.ErrorCode.Contains(errorcode.ToLower()))
            //      .Where(x => x.IssueHeader.Contains(headertext.ToLower()))
            //      .Where(p => SqlFunctions.PatIndex("%" + text.ToLower() + "%", p.IssueText) > 0).ToList();
            //var listofissues = _context.Issues.Where(x => x.ProductId == prodid);
            // listofissues = listofissues.Where(x => x.ErrorCode == errorcode);
            // listofissues.ToList();
            return listofissues.ToList();
        }

        
        public ActionResult SearchIssue(Issue issue)
        {
  //          var issue = new Issue ();
  //          issue.ProductId = seach.ProductId;
   //         issue.ErrorCode = seach.Errorcode;
     //       issue.IssueHeader = seach.Errorheader;
       //     issue.IssueText = seach.Errortext;
            var issues = SIssue(issue);
           

            return View(issues);
        }
        [HttpGet]
        public ActionResult ListofIssues(int? id)
        {
            var listofissues = _context.Issues.Where(x => x.ProductId == id ).Include(c => c.Product).OrderBy(model => model.ProductId);
            
            return View(listofissues);
        }
        
        public ActionResult IssueDetail(int id)
        {
            var issuedetailed = _context.Issues.Where(x => x.IssueID == id).Include(c => c.Product).FirstOrDefault();
            var solution = _context.Solutions.Where(x => x.IssueID == id).ToList();
         //   if (solution.Count > 0)
         //   {
                var solutionModel = new IssueSolution
                {
                    Issue = issuedetailed,
                    Solutions = solution
                };
           //     return View("IssueSolution", solutionModel);
           // }
            

            return View("IssueSolution", solutionModel);
        }

        public ActionResult EditIssue(int id)
        {
            var issuetoedit = _context.Issues.Where(x => x.IssueID == id).Include(c => c.Product).FirstOrDefault();
            var products = _context.Products.ToList();

            var issueModel = new IssueDetails
            {
                Products = products,
                Issue = issuetoedit
            };


            return View(issueModel);
        }



        [HttpPost]
        public string Savefile()
        {
            string link = ""; 
            Random rand = new Random((int)DateTime.Now.Ticks);
            var randomNumber = rand.Next(100000, 999999);

                for (int i = 0; i < Request.Files.Count; i++)
                 {
                    var file = Request.Files[i];


                     if (file != null)
                     {
                         var fileName = Path.GetFileName(file.FileName);
                         var names = fileName.Split('.');
                    
                         fileName = names[0] + "-" + randomNumber + "." + names[1];
                         var path = Path.Combine(Server.MapPath("~/Content/Images/"), fileName);
                         file.SaveAs(path);
                         link += "/Content/Images/" + fileName;
                     }
                 }
            return new JavaScriptSerializer().Serialize(link); ; 
        }


    }
}