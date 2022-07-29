using Common.Consts;
using Common.DTOs;
using MQTest.Producer;

namespace MQTest.Extentions
{
    public static class EndpointsExtention
    {
        
        public static void EndpointsMap(this WebApplication app)
        {

            IMessageProducer? _getMessagePublisher;

            using (var scope = app.Services.CreateScope())
            {
                _getMessagePublisher = scope.ServiceProvider.GetService<IMessageProducer>();
            }

            app.MapPost("orders/CreateOrder", (OrderDTO dto) =>
            {
                _getMessagePublisher?.SendMessage(dto, MQConfigs.OrderConfig);

                return Results.Ok(new { id = dto.Id });
            });

            app.MapPost("customers/CreateCustomer", (CustomerDTO dto) =>
            {
                _getMessagePublisher?.SendMessage(dto, MQConfigs.CustomerConfig);

                return Results.Ok(new { id = dto.Id });
            });

            app.MapPost("projects/CreateProject", (ProjectDTO dto) =>
            {
                _getMessagePublisher?.SendMessage(dto, MQConfigs.ProjectConfig);

                return Results.Ok(new { id = dto.Id });
            });





        }

        

    }
}
