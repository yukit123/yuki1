using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiTest.Models;

namespace WebApiTest.Controllers
{
    public class PlayersController : ApiController
    {
        //http://localhost:50638/Help  所有API地址
        public class ORDER
        {
            public string ID { get; set; }

            public string NO { get; set; }

            public string NAME { get; set; }

            public string DESC { get; set; }
        }

        //Player[] players = new Player[] {
        //    new Player { Id = 1, No = 3, Name = "Chris Paul", Position = "Point Guard", Team = "Los Angeles Clippers" },
        //    new Player { Id = 2, No = 3, Name = "Dwyane Wade", Position = "Shooting Guard", Team = "Miami Heat" },
        //    new Player { Id = 3, No = 23, Name = "LeBron James", Position = "Forward", Team = "Cleveland Cavaliers" },
        //    new Player { Id = 4, No = 21, Name = "Tim Duncan", Position = "Power forward", Team = "San Antonio Spurs" },
        //    new Player { Id = 5, No = 33, Name = "Marc Gasol", Position = "Center", Team = "Memphis Grizzlies" }
        //};

        //public IEnumerable<Player> GetAllPlayers()
        //{
        //    return players;
        //}

        //public IHttpActionResult GetPlayer(int id)//IHttpActionResult可返回JSON ,OK https://www.cnblogs.com/landeanfen/p/5501487.html
        //{
        //    var player = players.FirstOrDefault<Player>(p => p.Id == id);
        //    if (player == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(player);//如果返回Ok()，就表示不向客户端返回任何信息，只告诉客户端请求成功。
        //}

        [HttpGet]
        public IHttpActionResult GetNotFoundResult(string id)
        {
            var lstRes = new List<ORDER>();

            //实际项目中，通过后台取到集合赋值给lstRes变量。这里只是测试。
            lstRes.Add(new ORDER() { ID = "aaaa", NO = "111", NAME = "111", DESC = "1111" });
            lstRes.Add(new ORDER() { ID = "bbbb", NO = "222", NAME = "222", DESC = "2222" });
            var oFind = lstRes.FirstOrDefault(x => x.ID == id);
            if (oFind == null)
            {
                return NotFound();//F12 network 404 not found
            }
            else
            {
                return Json<ORDER>(oFind);
            }
        }

        //[ActionName("TestActionName")] url:localhost:xxx/api/Players/TestActionName
        //[AcceptVerbs("GET", "POST")] WebApi还提供了一个action同时支持多个http方法的请求，使用AcceptVerbs特性去标记
        #region [Route("Order/SaveData")] 'http://localhost:XXX/Order/SaveData'
        //  $.ajax({
        //    type: 'post',
        //    url: 'http://localhost:21528/Order/SaveData',
        //    data: { ID: 2, NO: "aaa"},
        //    success: function(data, status) {
        //        alert(data);
        //    }
        //  });


        //[Route("api/order/{id:int=3}/ordertype")] 默认3 int类型
        #endregion
        [HttpGet]
        public IHttpActionResult RedirectResult()
        {
            return Redirect("http://localhost:21528/api/Order/GetContentResult");//将请求重定向到其他地方。
        }

        //自定义IHttpActionResult接口的实现  ExecuteAsync()  https://www.cnblogs.com/landeanfen/p/5501487.html

        //导出 Excel HttpResponseMessage
        //webapi route 路由 自定义路由 https://www.cnblogs.com/landeanfen/p/5501490.html

        #region RoutePrefix Route 同一个控制器的所有的action的所有特性路由标识一个相同的前缀
        //[RoutePrefix("api/order")]
        //public class OrderController : ApiController
        //{
        //    [Route("")]
        //    [HttpGet]
        //    public IHttpActionResult GetAll()
        //    {
        //        return Ok<string>("Success");
        //    }

        //    [Route("{id:int}")]
        //    [HttpGet]
        //    public IHttpActionResult GetById(int id)
        //    {
        //        return Ok<string>("Success" + id);
        //    }

        //    [Route("postdata")]
        //    [HttpPost]
        //    public HttpResponseMessage PostData(int id)
        //    {
        //        return Request.CreateResponse();
        //    }
        //}
        #endregion
    }
}
