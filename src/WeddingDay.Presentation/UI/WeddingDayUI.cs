using WeddingDay.Domain.Commons;
using WeddingDay.Domain.Entities;
using WeddingDay.Service.DTOs.ClientDtos;
using WeddingDay.Service.Services;

namespace WeddingDay.Presentation.UI
{
    public class WeddingDayUI
    {
        public async Task RunCodeAsync()
        {
            await Console.Out.WriteLineAsync("██╗    ██╗███████╗██████╗ ██████╗ ██╗███╗   ██╗ ██████╗     ██████╗  █████╗ ██╗   ██╗\r\n██║    ██║██╔════╝██╔══██╗██╔══██╗██║████╗  ██║██╔════╝     ██╔══██╗██╔══██╗╚██╗ ██╔╝\r\n██║ █╗ ██║█████╗  ██║  ██║██║  ██║██║██╔██╗ ██║██║  ███╗    ██║  ██║███████║ ╚████╔╝ \r\n██║███╗██║██╔══╝  ██║  ██║██║  ██║██║██║╚██╗██║██║   ██║    ██║  ██║██╔══██║  ╚██╔╝  \r\n╚███╔███╔╝███████╗██████╔╝██████╔╝██║██║ ╚████║╚██████╔╝    ██████╔╝██║  ██║   ██║   \r\n ╚══╝╚══╝ ╚══════╝╚═════╝ ╚═════╝ ╚═╝╚═╝  ╚═══╝ ╚═════╝     ╚═════╝ ╚═╝  ╚═╝   ╚═╝   \r\n                                                                                     \r\n                                                                                     \r\n                                                                                     \r\n                                                                                     \r\n                                                                                     \r\n                                                                                     \r\n                                                                                     \r\n                                                                                     ");
            while (true)
            {
                await Console.Out.WriteLineAsync("1 => ScheduleWeddingDate ");
                await Console.Out.WriteLineAsync("2 => WeddingDateUpdate ");
                await Console.Out.WriteLineAsync("3 => RemoveTheWeddingDate ");
                await Console.Out.WriteLineAsync("4 => GetAll ");
                await Console.Out.WriteLineAsync("5 => GetById ");
                await Console.Out.WriteLineAsync("6 => Exit ");
                int num;
                await Console.Out.WriteAsync("Select one of the above :");
                num = int.Parse(Console.ReadLine());
                switch(num)
                {
                    case 1:
                        var client = new ClientForResultDto();
                        await Console.Out.WriteAsync("Enter the FirstName: ");
                        client.FirstName = Console.ReadLine();
                        await Console.Out.WriteAsync("Enter the LastName: ");
                        client.LastName = Console.ReadLine();
                        await Console.Out.WriteAsync("Enter the PhoneNumber: ");
                        client.Phone = Console.ReadLine();
                        ClientService clientService = new ClientService();
                        await clientService.CreateAsync(client);
                        break;
                }
            }
        }
    }
}
