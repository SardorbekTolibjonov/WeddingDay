using WeddingDay.Domain.Commons;
using WeddingDay.Domain.Entities;
using WeddingDay.Service.DTOs.BookingDtos;
using WeddingDay.Service.DTOs.ClientDtos;
using WeddingDay.Service.DTOs.PaymentDtos;
using WeddingDay.Service.DTOs.SingerDtos;
using WeddingDay.Service.Services;
using ZstdSharp.Unsafe;

namespace WeddingDay.Presentation.UI
{
    public class WeddingDayUI
    {
        public string Phone, Password;
        public async Task RunCodeAsync()
        {
            await Console.Out.WriteLineAsync("██╗    ██╗███████╗██████╗ ██████╗ ██╗███╗   ██╗ ██████╗     ██████╗  █████╗ ██╗   ██╗\r\n██║    ██║██╔════╝██╔══██╗██╔══██╗██║████╗  ██║██╔════╝     ██╔══██╗██╔══██╗╚██╗ ██╔╝\r\n██║ █╗ ██║█████╗  ██║  ██║██║  ██║██║██╔██╗ ██║██║  ███╗    ██║  ██║███████║ ╚████╔╝ \r\n██║███╗██║██╔══╝  ██║  ██║██║  ██║██║██║╚██╗██║██║   ██║    ██║  ██║██╔══██║  ╚██╔╝  \r\n╚███╔███╔╝███████╗██████╔╝██████╔╝██║██║ ╚████║╚██████╔╝    ██████╔╝██║  ██║   ██║   \r\n ╚══╝╚══╝ ╚══════╝╚═════╝ ╚═════╝ ╚═╝╚═╝  ╚═══╝ ╚═════╝     ╚═════╝ ╚═╝  ╚═╝   ╚═╝   \r\n ");
            while (true)
            {
                start:
                await Console.Out.WriteLineAsync("1 => SignUp");
                await Console.Out.WriteLineAsync("2 => LogIn");
                int num;
                Console.Write("Eter : ");
                num = int.Parse(Console.ReadLine());

                bool m = false;
                switch (num)
                {
                    case 1:
                        ClientService clientService = new ClientService();
                        var client = new ClientForCreationDto();
                        await Console.Out.WriteAsync("Enter the First Name : ");
                        client.FirstName = Console.ReadLine();
                        await Console.Out.WriteAsync("Enter the Last Name : ");
                        client.LastName = Console.ReadLine();
                        await Console.Out.WriteAsync("Enter the Phone Number :+998");
                        client.Phone = Console.ReadLine();
                        await Console.Out.WriteAsync("Enter the Password : ");
                        client.Password = Console.ReadLine();
                        
                        await clientService.CreateAsync(client);
                        m = true;
                        break;
                    case 2:
                        ClientService service = new ClientService();
                        Auth auth = new Auth();
                        await Console.Out.WriteAsync("Enter the Phone Numer : +998");
                        string phone = Console.ReadLine();
                        Phone = phone;
                        await Console.Out.WriteAsync("Enter the Password : ");
                        string password = Console.ReadLine();
                        Password = password;
                        var chack = await service.Inspection(password, phone);
                        if (chack == false)
                        {
                            await Console.Out.WriteLineAsync("You are not listed. Please Register");
                            goto start;
                        }
                        m = true;
                        break;
                }
                if(m)
                {
                    Console.Clear();
                    await Console.Out.WriteLineAsync("Successfully");

                    await Console.Out.WriteLineAsync("1 => ScheduleWeddingDate ");
                    await Console.Out.WriteLineAsync("2 => WeddingDateUpdate ");
                    await Console.Out.WriteLineAsync("3 => RemoveTheWeddingDate ");
                    await Console.Out.WriteLineAsync("4 => AllBookedWeddingDates ");
                    await Console.Out.WriteLineAsync("5 => GetById ");
                    await Console.Out.WriteLineAsync("6 => Exit ");
                    int num1;
                    await Console.Out.WriteAsync("Enter :");
                    num1 = int.Parse(Console.ReadLine());

                    switch (num1)
                    {
                        case 1:
                        begin:
                            var order = new BookingForCreationDto();
                            SingerService singerService = new SingerService();
                            BookingService bookingService = new BookingService();
                            await Console.Out.WriteAsync("Enter your wedding date(dd.mm.yyyy) : ");
                            string date = Console.ReadLine();
                            order.WeddingDate = date;
                            await Console.Out.WriteAsync("Enter the Address: ");
                            string address = Console.ReadLine();
                            order.WeddingAddress = address;
                            var key = await bookingService.Inspection(date, address);
                            if (key == false)
                            {
                                await Console.Out.WriteLineAsync("This order exists\nPlease change the wedding date and address");
                                goto begin;
                            }
                            await Console.Out.WriteAsync("Do you need a singer? (y/n): ");
                            char mark = char.Parse(Console.ReadLine());
                            int num4 = 0;
                            if (mark == 'y')
                            {
                                var singers = await singerService.GetAllAsync();
                                foreach ( var singer in singers) 
                                    await Console.Out.WriteLineAsync("Id : " + singer.Id + "  " +  "Name : " + singer.Name + "  " + "Fee : " + singer.Fee);
                                Console.Write("Choose Id : ");
                                num4 = int.Parse(Console.ReadLine());
                            }
                            PaymentService ps = new PaymentService();
                            await Console.Out.WriteAsync("Enter the Payment : ");
                            var payment = new PaymentForCreationDto();
                            payment.Amount = decimal.Parse(Console.ReadLine());
                            await Console.Out.WriteAsync("Enter the Phone : +998");
                            payment.Phone = Console.ReadLine();
                            ClientService cs = new ClientService();
                            await ps.CreateAsync(payment);
                            var PaymentPhone = (await ps.GetAllAsync()).FirstOrDefault(p => p.Phone == Phone);
                            var ClientPhone = (await cs.GetAllAsync()).FirstOrDefault(e => e.Phone == Phone);
                            BookingForCreationDto book = new BookingForCreationDto()
                            {
                                ClientId = ClientPhone.Id,
                                SingerId = num4,
                                PaymentId = PaymentPhone.Id,
                                WeddingAddress = order.WeddingAddress,
                                WeddingDate = order.WeddingDate
                            };
                            BookingService bs = new BookingService();
                            await bs.CreateAsync(book);
                            break;
                        case 2:

                            break;

                    }
                }
            }
        }
    }
}
