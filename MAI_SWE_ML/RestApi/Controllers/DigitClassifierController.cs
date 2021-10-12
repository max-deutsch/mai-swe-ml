
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Controllers
{
    [ApiController]
    [Route("api/digits/classifications")]
    public class DigitClassifierController : Controller
    {

        public MAI_SWE_MLML.Model.ModelOutput PredictDigitTest()
        {
            return Predict(@"C:\FH\ws21\swe\mnist_course_small\course_small\2\113.png");
        }

        [HttpGet("{path}")]
        public MAI_SWE_MLML.Model.ModelOutput PredictDigitByPath(string path)
        {
            path = System.Web.HttpUtility.UrlDecode(path);
            return Predict(path);
        }

        private MAI_SWE_MLML.Model.ModelOutput Predict(string path)
        {
            MAI_SWE_MLML.Model.ModelInput sampleData = new MAI_SWE_MLML.Model.ModelInput()
            {
                ImageSource = path,
            };
            return MAI_SWE_MLML.Model.ConsumeModel.Predict(sampleData);
        }

    }
}
