using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace lab1
{

    public class Startup
    {


        public void ConfigureServices(IServiceCollection services)
        {
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {


            int card = 1000;
            int card2 = 5000;
            int card3 = 20000;
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {

                    await context.Response.WriteAsync("\n\n\n\n\n Welcome to us bank " +
                        "\n\n\n\n\n To enter:   /log?pass=************* " +
                        "\n Password: 001");
                });
            });

            app.Map("/log", Login);
            app.Map("/options", Options);


            void Options(IApplicationBuilder app)
            {
                app.Run(async context =>
                {
                    if (context.Request.Query.ContainsKey("option"))
                    {
                        if (context.Request.Query["option"] == "1")
                        {
                            await context.Response.WriteAsync($" Your card: {card}");
                        }
                        else if (context.Request.Query["option"] == "2")
                        {
                            await context.Response.WriteAsync($" Your card: {card2}");
                        }
                        else if (context.Request.Query["option"] == "3")
                        {
                            await context.Response.WriteAsync($" Your card: {card3}");
                        }
                    }
                });
            }

        }


        private void Login(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                if (context.Request.Query.ContainsKey("pass") && context.Request.Query["pass"] == "001")
                {
                    await context.Response.WriteAsync(" There is money left in the account! \n" +
                        "\n\n\n First master-card:  /options?option=1" +

                        "\n\n\n second master-card: /options?option=2" +

                        "\n\n\n Thind master-card:  /options?option=3");
                }
                else
                {
                    await context.Response.WriteAsync("Wrong! Try again");
                }
            });
        }


    

        }
    }


