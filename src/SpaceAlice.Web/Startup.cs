using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SpaceAlice.DataAccess.Repositories;
using SpaceAlice.DataAccess.Repositories.Mongo;

namespace SpaceAlice.Web {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services) {
            // TODO: Move to config
            services.AddSingleton(new MongoConnectionOptions {
                ConnectionString = "mongodb://localhost:27017",
                DatabaseName = "space_alice"
            });
            services.AddSingleton<IDataRepository, MongoDataRepository>();
            services.AddSingleton<IAliceMessageProcessor, SynchronousAliceMessageProcessor>();
            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }
            else {
                app.UseHsts();
                app.UseHttpsRedirection();
            }

            app.UseMvc();
        }
    }
}