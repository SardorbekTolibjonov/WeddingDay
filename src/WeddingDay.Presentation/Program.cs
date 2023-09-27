using MySqlX.XDevAPI;
using WeddingDay.Data.Repositories;
using WeddingDay.Domain.Entities;
using WeddingDay.Presentation.UI;
using WeddingDay.Service.DTOs.BookingDtos;
using WeddingDay.Service.DTOs.ClientDtos;
using WeddingDay.Service.Services;

namespace WeddingDay.Presentation
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            WeddingDayUI ui = new WeddingDayUI();
            await ui.RunCodeAsync();
            //Repository<Booking> repository = new Repository<Booking>();
            /*            ClientService clientService = new ClientService();
                        ClientForCreationDto dto = new ClientForCreationDto()
                        {
                            FirstName = "asdas",
                            LastName = "dasdsa",
                            Password = "password",
                            Phone = "13212",
                        };
                        await clientService.CreateAsync(dto);*/
        }
    }
}