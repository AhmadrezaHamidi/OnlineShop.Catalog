using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ShopWeb.Base.BaseControllers
{
    
    public abstract class MHBaseController : ControllerBase
    {
        protected readonly ILogger logger;

        public MHBaseController()
        {

        }

        public MHBaseController(ILogger logger)
        {
            this.logger = logger;
        }

        //logger public IUserHelper IUser => new UserHelper(this.User);

    }
}