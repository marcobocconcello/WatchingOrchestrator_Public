using System;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts;
using WatchingOrchestrator.Models;

namespace WatchingOrchestrator.Data{
    internal static class PrepDb{
        internal static void PreparePopulation(IApplicationBuilder builder){
            using var services = builder.ApplicationServices.CreateScope();
            SeedData(services.ServiceProvider.GetService<WatchingDbContext>());
        }

        private static void SeedData(WatchingDbContext context){
            Console.WriteLine("Create db in memory");

            context.Contents.AddRange(
                    new Contents(
                        "Film",
                        DateTime.Now,
                        DateTime.MaxValue,
                        DateTime.Now
                    ),
                    new Contents(
                        "SerieTv",
                        DateTime.Now,
                        DateTime.MaxValue,
                        DateTime.Now
                    ),
                    new Contents(
                        "Podcast",
                        DateTime.Now,
                        DateTime.MaxValue,
                        DateTime.Now
                    )
            );

            context.States.AddRange(
                    new States(
                        "Da vedere",
                        DateTime.Now,
                        DateTime.MaxValue,
                        DateTime.Now
                    ),
                    new States(
                        "Visti",
                        DateTime.Now,
                        DateTime.MaxValue,
                        DateTime.Now
                    )
            );

            context.Elements.AddRange(
                    new Elements(
                        DateTime.Now,
                        DateTime.MaxValue,
                        DateTime.Now,
                        DateTime.Now,
                        "Podcast A",
                        "",
                        "",
                        "Y",
                        3,
                        1
                    ),
                    new Elements(
                        DateTime.Now,
                        DateTime.MaxValue,
                        DateTime.Now,
                        DateTime.Now,
                        "Film A",
                        "",
                        "",
                        "N",
                        1,
                        2
                    ),
                    new Elements(
                        DateTime.Now,
                        DateTime.MaxValue,
                        DateTime.Now,
                        DateTime.Now,
                        "Serie A",
                        "",
                        "",
                        "Y",
                        2,
                        1
                    )
            );

            context.SaveChanges();
            Console.WriteLine("Elements created");
        } 
    }
}