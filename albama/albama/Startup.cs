using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using albama.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace albama
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {



            // MVC用 够用了 
            services.AddControllersWithViews();
            // 过于强大 不必要
            //services.AddMvc();
            // 做接口使用
            //services.AddControllers();
            //生命周期 服务创建到结束
            services.AddSingleton<IClock, ChinaClock>();
            //每次新建服务都会创建一个新的实例
            //services.AddScoped
            //每次请求都回新建一个
            //services.AddTransient
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //自定义 环境变量 环境变量在 属性调试 中修改
            if(env.IsEnvironment("ok"))
            {

            }
            // 是否正式环境
            if (env.IsProduction())
            {

            }
            //是否开发模式
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            // 适用静态文件
            app.UseStaticFiles();
            // 把http请求转化为https请求
            app.UseHttpsRedirection();
            //认证
            app.UseAuthentication();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                // 路由表的形式
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
                // 非路由表的形式 需要在controller里面[]形式写地址
                //endpoints.MapControllers();
            });
        }
    }
}
