using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace calculadora.Controllers
{
    public class SubtractionController : Controller
    {
        // GET: Subtraction
        public int Index(string num1, string num2)
        {
            int num1Val = Int32.Parse(num1);
            int num2Val = Int32.Parse(num2);
            int result = num1Val - num2Val;

            return result;
        }
    }
}