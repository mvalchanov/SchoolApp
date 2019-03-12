using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace SchoolApp.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        protected readonly IMapper _mapper;

        public BaseController(IMapper mapper)
        {
            this._mapper = mapper;
        }
    }
}
