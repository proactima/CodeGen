using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGen
{
    public class TestY
    {
        public void Test()
        {
            var a = Request.Create("", "", "", "", "");

            var b = a.WithCompany("fds").WithMailContent("fdas");
        }
    }
}
