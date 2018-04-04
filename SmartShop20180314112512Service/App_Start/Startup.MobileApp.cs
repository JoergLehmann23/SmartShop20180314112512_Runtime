using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Web.Http;
using Microsoft.Azure.Mobile.Server;
using Microsoft.Azure.Mobile.Server.Authentication;
using Microsoft.Azure.Mobile.Server.Config;
using SmartShop20180314112512Service.DataObjects;
using SmartShop20180314112512Service.Models;
using Owin;

namespace SmartShop20180314112512Service
{
    public partial class Startup
    {
        public static void ConfigureMobileApp(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            //For more information on Web API tracing, see http://go.microsoft.com/fwlink/?LinkId=620686 
            config.EnableSystemDiagnosticsTracing();

            new MobileAppConfiguration()
                .UseDefaultConfiguration()
                .ApplyTo(config);

            // Use Entity Framework Code First to create database tables based on your DbContext
            Database.SetInitializer(new SmartShop20180314112512Initializer());

            // To prevent Entity Framework from modifying your database schema, use a null database initializer
            // Database.SetInitializer<SmartShop20180314112512Context>(null);

            MobileAppSettingsDictionary settings = config.GetMobileAppSettingsProvider().GetMobileAppSettings();

            if (string.IsNullOrEmpty(settings.HostName))
            {
                // This middleware is intended to be used locally for debugging. By default, HostName will
                // only have a value when running in an App Service application.
                app.UseAppServiceAuthentication(new AppServiceAuthenticationOptions
                {
                    SigningKey = ConfigurationManager.AppSettings["SigningKey"],
                    ValidAudiences = new[] { ConfigurationManager.AppSettings["ValidAudience"] },
                    ValidIssuers = new[] { ConfigurationManager.AppSettings["ValidIssuer"] },
                    TokenHandler = config.GetAppServiceTokenHandler()
                });
            }
            app.UseWebApi(config);
        }
    }

    public class SmartShop20180314112512Initializer : CreateDatabaseIfNotExists<SmartShop20180314112512Context>
    {
        protected override void Seed(SmartShop20180314112512Context context)
        {
            List<Customer> customers = new List<Customer>
            {
                new Customer { Id = Guid.NewGuid().ToString(), CustomerID = 01, FirstName ="Vorname1", LastName="Nachname1", CompanyName="Unternehmen1", OpenInvoice = 111 },
                new Customer { Id = Guid.NewGuid().ToString(), CustomerID = 02, FirstName ="Vorname2", LastName="Nachname2", CompanyName="Unternehmen2", OpenInvoice = 222 },
                new Customer { Id = Guid.NewGuid().ToString(), CustomerID = 03, FirstName ="Vorname3", LastName="Nachname3", CompanyName="Unternehmen3", OpenInvoice = 333 },
            };

            foreach (Customer customer in customers)
            {
                context.Set<Customer>().Add(customer);
            }

            base.Seed(context);
        }
    }
}

