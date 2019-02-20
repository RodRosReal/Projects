using Application.Interfaces;
using Application.Messages;
using Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            IApiCommand apiCommand = new ApiCommand();
            var academy = apiCommand.GetAcademy(new GetAcademyRequest() { AcademyId = 1 });
        }
    }
}
