using Coldairarrow.IBusiness;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Text;

namespace Coldairarrow.Api
{
    /// <summary>
    /// EBOOK基控制器
    /// </summary>
    [AllowAnonymous]
    [CheckSign]
    public class BaseEBookController : Api.BaseApiController
    {
    }
}