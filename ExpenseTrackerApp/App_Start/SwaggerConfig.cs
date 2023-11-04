using Swashbuckle.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ExpenseTrackerApp.App_Start
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            // Enable Swagger
            GlobalConfiguration.Configuration.EnableSwagger(c =>
            {
                c.SingleApiVersion("v1", "Your API Name")
                    .Description("A description of your API")
                    .Contact(contact => contact
                        .Name("Your Name")
                        .Email("your@email.com"))
                    .TermsOfService("https://yourapp.com/terms")
                ;
            })
            .EnableSwaggerUi();
        }
    }
}