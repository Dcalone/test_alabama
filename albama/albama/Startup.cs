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
            // MVC�� ������ 
            services.AddControllersWithViews();
            // ����ǿ�� ����Ҫ
            //services.AddMvc();
            // ���ӿ�ʹ��
            //services.AddControllers();
            //�������� ���񴴽�������
            services.AddSingleton<IClock, ChinaClock>();
            //ÿ���½����񶼻ᴴ��һ���µ�ʵ��
            //services.AddScoped
            //ÿ�����󶼻��½�һ��
            //services.AddTransient
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //�Զ��� �������� ���������� ���Ե��� ���޸�
            if(env.IsEnvironment("ok"))
            {

            }
            // �Ƿ���ʽ����
            if (env.IsProduction())
            {

            }
            //�Ƿ񿪷�ģʽ
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            // ���þ�̬�ļ�
            app.UseStaticFiles();
            // ��http����ת��Ϊhttps����
            app.UseHttpsRedirection();
            //��֤
            app.UseAuthentication();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                // ·�ɱ����ʽ
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
                // ��·�ɱ����ʽ ��Ҫ��controller����[]��ʽд��ַ
                //endpoints.MapControllers();
            });
        }
    }
}
