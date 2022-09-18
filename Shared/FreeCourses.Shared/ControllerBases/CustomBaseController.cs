using System;
using System.Collections.Generic;
using System.Text;
using FreeCourses.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace FreeCourses.Shared.ControllerBases
{
    public class CustomBaseController: ControllerBase
    {
        public IActionResult CreateActionResultInstance<T>(Response<T> response)
        {
            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode
            };
        }
    }
}
