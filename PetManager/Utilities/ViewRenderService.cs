using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Routing;

namespace PetManager.Utilities
{
    public interface IViewRenderService
    {
        string RenderToStringAsync(string viewName, object model);
    }

    public class ViewRenderService : IViewRenderService
    {
        private readonly IRazorViewEngine _razorViewEngine;
        private readonly ITempDataProvider _tempDataProvider;
        private readonly IServiceProvider _serviceProvider;

        public ViewRenderService(IRazorViewEngine razorViewEngine,
            ITempDataProvider tempDataProvider,
            IServiceProvider serviceProvider)
        {
            _razorViewEngine = razorViewEngine;
            _tempDataProvider = tempDataProvider;
            _serviceProvider = serviceProvider;
        }

        public string RenderToStringAsync(string viewName, object model)
        {


            //var httpContext = new DefaultHttpContext { RequestServices = _serviceProvider };
            //var actionContext = new ActionContext(httpContext, new RouteData(), new ActionDescriptor());

            //using (var sw = new StringWriter())
            //{
            //    //var dir = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            //    //string executingFilePath = $"{dir.Replace('\\', '/')}/Views/";
            //    //string viewPath = $"{executingFilePath}InvoiceTemplate.cshtml";
            //    //var viewResult = _razorViewEngine.GetView("E:/Work/PetManager/backend/PetManager/PetManager/bin/Debug/net6.0/Views/", "InvoiceTemplate.cshtml", isMainPage: true) ;

            //    //var dir = "E:\\Work\\PetManager\\backend\\PetManager\\PetManager\\Views\\";
            //    //string executingFilePath = $"{dir.Replace('\\', '/')}";

            //    //var viewResult = _razorViewEngine.GetView(executingFilePath,"InvoiceTemplate.cshtml", false);

            //    // var viewResult = _razorViewEngine.GetView(executingFilePath: dir, test1, isMainPage: false);
            //    var viewResult = _razorViewEngine.FindView(actionContext, "Index", false);
            //    //var viewResult = _razorViewEngine.FindView(actionContext, viewName, false);
            //    if (viewResult.View == null)
            //    {
            //        throw new ArgumentNullException($"{viewName} does not match any available view");
            //    }
            //    var viewDictionary = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary())
            //    {
            //        Model = model
            //    };
            //    var viewContext = new ViewContext(
            //        actionContext,
            //        viewResult.View,
            //        viewDictionary,
            //        new TempDataDictionary(actionContext.HttpContext, _tempDataProvider),
            //        sw,
            //        new HtmlHelperOptions()
            //    );
            //    viewResult.View.RenderAsync(viewContext);
            //    return sw.ToString();

            var httpContext = new DefaultHttpContext { RequestServices = _serviceProvider };
            var actionContext = new ActionContext(httpContext, new RouteData(), new ActionDescriptor());

            using (var sw = new StringWriter())
            {
                //var viewResult = _razorViewEngine.FindView(actionContext, "Index", false);
                var viewResult = _razorViewEngine.FindView(actionContext, viewName, false);

                if (viewResult.View == null)
                {
                    throw new ArgumentNullException($"{viewName} does not match any available view");
                }

                var viewDictionary = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary())
                {
                    Model = model
                };

                var viewContext = new ViewContext(
                    actionContext,
                    viewResult.View,
                    viewDictionary,
                    new TempDataDictionary(actionContext.HttpContext, _tempDataProvider),
                    sw,
                    new HtmlHelperOptions()
                );

                 viewResult.View.RenderAsync(viewContext);
                return sw.ToString();

            }
        }
    }
}
