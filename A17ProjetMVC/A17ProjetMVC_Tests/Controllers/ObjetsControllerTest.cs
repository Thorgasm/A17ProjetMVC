using EntityFramework.MoqHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using A17ProjetMVC.Models;
//using A17ProjetMVC_Tests.MockData;

namespace A17ProjetMVC_Tests.Controllers
{
    [TestClass]
    class ObjetsControllerTest
    {
        Mock<ApplicationDbContext> mockContext;
        
        public void SetUp()
        {
            mockContext = EntityFrameworkMoqHelper.CreateMockForDbContext<ApplicationDbContext>();

        }
    }
}
