using MQTest.Producer;
using MQTest.Producer.Impl;

namespace MQTest.Extentions
{
    public static class ServiceCollection
    {
        public static void TryToServe(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddScoped<IMessageProducer, RabbitMQProducer>();

        }

        public static void RunApp(this WebApplication app)
        {

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();



            app.Run();
        }


    }

    
}
