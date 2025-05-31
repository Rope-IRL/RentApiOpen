using Microsoft.Extensions.Hosting;
using RestFulAPI.Core.Interfaces;
using RestFulAPI.Core.Models;
using RestFulAPI.DataAccess;
using System.Net;
using System.Reflection.PortableExecutable;

namespace RestFulAPI.Middleware
{
    public class AddDataMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IServiceProvider _serviceProvider;

        public AddDataMiddleware(RequestDelegate next, IServiceProvider serviceProvider)
        {
            _next = next;
            _serviceProvider = serviceProvider;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<RentDbContext>();
                await InitializeDatabaseAsync(db);
            }

            await _next(context);
        }

        private async Task InitializeDatabaseAsync(RentDbContext db)
        {
            db.Database.EnsureCreated();

            Random rand = new Random();
            int numberOfLessees = 10;
            int numberOfLandLords = 10;
            int numberOfFlats = 100;
            int numberOfFlatsContracts = 30;

            if (!db.Lessees.Any())
            {
                string name = $"LesseeName_2";
                string surname = $"LesseeSurname_1";

                string telephone = "+376179791741";


                DateOnly birthDate = new DateOnly(1986, 12, 14);

                string pasportId = "Passport_43955971";

                int integerPart = rand.Next(0, 9);

                int fractionalPart = rand.Next(0, 99);

                decimal result = integerPart + fractionalPart / 100.0m;

                decimal lAvgMark = Math.Round(result);

                LesseeAdditionalInfo lesseesAdditionalInfo = new LesseeAdditionalInfo
                {
                    Id = 1,
                    AverageMark = lAvgMark,
                    BirthDate = birthDate,
                    Name = name,
                    Surname = surname,
                    Telephone = telephone,
                    PassportId = pasportId,
                };
                    
                string email = $"user_1 @example.com";
                string login = $"user_1";
                string password = $"password_1";

                db.Lessees.Add(new Lessee
                {
                    Login = login,
                    HashedPassword = password,
                    Email = email,
                    AdditionalInfo = lesseesAdditionalInfo
                });
                await db.SaveChangesAsync();

                for (int i = 2; i < numberOfLessees + 1; i++)
                {
                     name = $"name {i}";
                     surname = $"Surname {i}";

                    long startNumber = 376000000000;
                    long endNumber = 376999999999;
                    telephone = Convert.ToString((rand.NextInt64(startNumber, endNumber)));

                    DateOnly startDate = new DateOnly(1980, 12, 11);
                    DateOnly endDate = new DateOnly(2020, 12, 11);
                    int range = (endDate.ToDateTime(TimeOnly.MinValue) - startDate.ToDateTime(TimeOnly.MinValue)).Days;
                    int randomDays = rand.Next(range + 1);

                    birthDate = (startDate.AddDays(randomDays));

                    long startPassportNumber = 000000000000;
                    long endPassportNumber = 999999999999;
                    pasportId = Convert.ToString((rand.NextInt64(startPassportNumber, endPassportNumber)));

                    integerPart = rand.Next(0, 9);

                    fractionalPart = rand.Next(0, 99);

                    result = integerPart + fractionalPart / 100.0m;

                    lAvgMark = Math.Round(result);

                    LesseeAdditionalInfo lesseesAdditionalInfo1 = new LesseeAdditionalInfo
                    {
                        Id = i,
                        AverageMark = lAvgMark,
                        BirthDate = birthDate,
                        Name = name,
                        Surname = surname,
                        Telephone = telephone,
                        PassportId = pasportId,
                    };
                    email = $"email {i}";
                    login = $"login {i}";
                    password = $"password {i}";

                    db.Lessees.Add(new Lessee
                    {
                        Login = login,
                        HashedPassword = password,
                        Email = email,
                        AdditionalInfo = lesseesAdditionalInfo1
                    });
                    await db.SaveChangesAsync();

                }
            }


            if (!db.Landlords.Any())
            {
                string name = $"LandLordName_1";
                string surname = $"LandLordSurname_1";

                string telephone = "+3822092318446";

                DateOnly birthDate = new DateOnly(2000, 12, 12);


                string pasportId = "Passport_66172702";


                int integerPart = rand.Next(0, 9);

                int fractionalPart = rand.Next(0, 99);

                decimal result = integerPart + fractionalPart / 100.0m;

                decimal lAvgMark = Math.Round(result);

                LandlordAdditionalInfo lesseesAdditionalInfo = new LandlordAdditionalInfo
                {
                    Id = 1,
                    AverageMark = lAvgMark,
                    BirthDate = birthDate,
                    Name = name,
                    Surname = surname,
                    Telephone = telephone,
                    PassportId = pasportId,
                };
                string email = $"landlord_1@example.com";
                string login = $"landlord_1";
                string password = $"password_1";

                db.Landlords.Add(new Landlord
                {
                    Login = login,
                    HashedPassword = password,
                    Email = email,
                    AdditionalInfo = lesseesAdditionalInfo
                });
                await db.SaveChangesAsync();

                for (int i = 2; i < numberOfLandLords + 1; i++)
                {
                    name = $"name {i}";
                    surname = $"surName {i}";

                    long startNumber = 376000000000;
                    long endNumber = 376999999999;
                    telephone = Convert.ToString((rand.NextInt64(startNumber, endNumber)));

                    DateOnly startDate = new DateOnly(1980, 12, 11);
                    DateOnly endDate = new DateOnly(2020, 12, 11);
                    int range = (endDate.ToDateTime(TimeOnly.MinValue) - startDate.ToDateTime(TimeOnly.MinValue)).Days;
                    int randomDays = rand.Next(range + 1);
                    birthDate = (startDate.AddDays(randomDays));

                    long startPassportNumber = 000000000000;
                    long endPassportNumber = 999999999999;
                    pasportId = Convert.ToString((rand.NextInt64(startPassportNumber, endPassportNumber)));


                    integerPart = rand.Next(0, 9);

                    fractionalPart = rand.Next(0, 99);

                    result = integerPart + fractionalPart / 100.0m;

                    lAvgMark = Math.Round(result);

                    LandlordAdditionalInfo lesseesAdditionalInfo1 = new LandlordAdditionalInfo
                    {
                        Id = i,
                        AverageMark = lAvgMark,
                        BirthDate = birthDate,
                        Name = name,
                        Surname = surname,
                        Telephone = telephone,
                        PassportId = pasportId,
                    };
                    email = $"email {i}";
                    login = $"login {i}";
                    password = $"password {i}";

                    db.Landlords.Add(new Landlord
                    {
                        Login = login,
                        HashedPassword = password,
                        Email = email,
                        AdditionalInfo = lesseesAdditionalInfo1
                    });
                    await db.SaveChangesAsync();


                }
            }

            if (!db.Flats.Any())
            {
                string header = $"Garden Tower flat";
                string description = $"Garden Tower flat offers accommodations in London, " +
                    $"a 18-minute walk from Sky Garden and 1.2 miles from Liverpool Street Tube Station. " +
                    $"This apartment offers accommodations with a balcony. " +
                    $"Outdoor seating is also available at the apartment. With free Wifi, " +
                    $"this 1-bedroom apartment provides a flat-screen TV, a washing machine, " +
                    $"and a fully equipped kitchen with a dishwasher and microwave. " +
                    $"The accommodation is non-smoking. Popular points of interest near Garden Tower flat " +
                    $"include Tower of London, Tower Bridge, and Brick Lane. " +
                    $"The nearest airport is London City Airport, 6.2 miles from the accommodation.";
                decimal avgMark = (decimal)9.9;
                string city = $"London";
                string address = $"e1 8hr, Tower Hamlets, London, E1 8HR, " +
                    $"United Kingdom";
                short numberOfRooms = (short)3;
                short numberOfFloors = (short)1;
                bool bathRoomAvailability = true;
                bool wifiAvailability = true;

                int integerPart = rand.Next(0, 9);

                int fractionalPart = rand.Next(0, 99);

                decimal result = integerPart + fractionalPart / 100.0m;

                decimal cost = (decimal)359.4464;
                int LLid = 1;

                db.Flats.Add(new Flat
                {
                    Header = header,
                    Description = description,
                    Address = address,
                    City = city,
                    AverageMark = avgMark,
                    IsWiFiAvailable = wifiAvailability,
                    IsBathroomAvailable = bathRoomAvailability,
                    NumberOfFloors = numberOfFloors,
                    NumberOfRooms = numberOfRooms,
                    CostPerDay = cost,
                    LlId = LLid,
                });

                string header1 = $"Modern Central London Studio for 4, Just 2 Mins from Paddington Station";
                string description1 = $"Modern Central London Studio for 4, Just 2 Mins from Paddington Station is located in London, " +
                    $"just 1.5 miles from The Serpentine and 1.2 miles from Lord's Cricket Ground. " +
                    $"The air-conditioned accommodation is a 19-minute walk from Portobello Road Market. " +
                    $"Free Wifi is available throughout the property and Paddington Station is a 9-minute walk away. " +
                    $"The apartment is composed of 1 bedroom, a fully equipped kitchen, and 1 bathroom. A flat-screen TV is featured. " +
                    $"The accommodation is non-smoking. Madame Tussaud's is 1.7 miles from the apartment, " +
                    $"while Royal Albert Hall is 2.1 miles away. London City Airport is 12 miles from the property.";
                decimal avgMark1 = (decimal)8.5;
                string city1 = $"London";
                string address1 = $"Orsett Terrace, Westminster Borough, London, W2 6JU, " +
                    $"United Kingdom";
                short numberOfRooms1 = (short)5;
                short numberOfFloors1 = (short)1;
                bool bathRoomAvailability1 = true;
                bool wifiAvailability1 = true;

                decimal cost1 = (decimal)359.4464;
                int LLid1 = 2;

                db.Flats.Add(new Flat
                {
                    Header = header1,
                    Description = description1,
                    Address = address1,
                    City = city1,
                    AverageMark = avgMark1,
                    IsWiFiAvailable = wifiAvailability1,
                    IsBathroomAvailable = bathRoomAvailability1,
                    NumberOfFloors = numberOfFloors1,
                    NumberOfRooms = numberOfRooms1,
                    CostPerDay = cost1,
                    LlId = LLid1,
                });
                await db.SaveChangesAsync();
            

                for (int i = 3; i < numberOfFlats + 1; i++)
                {
                    header = $"flat {i}";
                    description = $"description of the flat{i}";
                    avgMark = (decimal)9.9;
                    city = $"city {i}";
                    address = $"address{i}";
                    numberOfRooms = (short)rand.Next(1, 3);
                    numberOfFloors = (short)rand.Next(1, 3);
                    bathRoomAvailability = Convert.ToBoolean(rand.Next(0, 1));
                    wifiAvailability = Convert.ToBoolean(rand.Next(0, 1));

                    integerPart = rand.Next(0, 9);

                    fractionalPart = rand.Next(0, 99);

                    result = integerPart + fractionalPart / 100.0m;

                    cost = Math.Round(result, 2);
                    LLid = rand.Next(1, numberOfLandLords);

                    db.Flats.Add(new Flat
                    {
                        Header = header,
                        Description = description,
                        Address = address,
                        City = city,
                        AverageMark = avgMark,
                        IsWiFiAvailable = wifiAvailability,
                        IsBathroomAvailable = bathRoomAvailability,
                        NumberOfFloors = numberOfFloors,
                        NumberOfRooms = numberOfRooms,
                        CostPerDay = cost,
                        LlId = LLid,
                    });
                    await db.SaveChangesAsync();
                }
            }

            if (!db.FlatImages.Any())
            {
                db.FlatImages.Add(new FlatImage
                {
                    FlatId = 1,
                    MainImageName = "Flat1Big.jpg",
                    BigImageName = "Flat1Big.jpg",
                    FirstSmallImageName = "Flat1FirstSmall.jpg",
                    SecondSmallImageName = "Flat1SecondSmall.jpg"
                });

                db.FlatImages.Add(new FlatImage
                {
                    FlatId = 2,
                    MainImageName = "Flat2Big.jpg",
                    BigImageName = "Flat2Big.jpg",
                    FirstSmallImageName = "Flat2FirstSmall.jpg",
                    SecondSmallImageName = "Flat2SecondSmall.jpg"
                });

                await db.SaveChangesAsync();
            }

            if (!db.FlatContracts.Any())
            {
                for (int i = 1; i < numberOfFlatsContracts + 1; i++)
                {
                    DateOnly startDate = new DateOnly(2020, 1, 11);
                    DateOnly endDate = new DateOnly(2020, 12, 11);
                    int range = (endDate.ToDateTime(TimeOnly.MinValue) - startDate.ToDateTime(TimeOnly.MinValue)).Days;
                    int randomDays = rand.Next(range + 1);
                    DateOnly rentStartDate = startDate.AddDays(randomDays);
                    int rentRange = rand.Next(randomDays, range);
                    DateOnly rentEndDate = startDate.AddDays(rentRange);

                    int Fid = rand.Next(1, numberOfFlats);
                    int Lid = rand.Next(1, numberOfLessees);
                    int LLid = rand.Next(1, numberOfLandLords);

                    int integerPart = rand.Next(0, 9);

                    int fractionalPart = rand.Next(0, 99);

                    decimal result = integerPart + fractionalPart / 100.0m;

                    decimal cost = Math.Round(result, 2);
                    db.FlatContracts.Add(new FlatContract
                    {
                        StartDate = rentStartDate,
                        EndDate = rentEndDate,
                        FlatId = Fid,
                        LesseeId = Lid,
                        LandlordId = LLid,
                        Cost = cost,
                    });
                    await db.SaveChangesAsync();

                }
            }

            if(!db.Houses.Any())
            {
                string header1 = $"E1 Luxury Penthouse";
                string description1 = $"E1 Luxury Penthouse offers accommodations in London, 1.4 miles from Tower of London and 1.6 miles from Tower Bridge. The property is around a 16-minute walk from Brick Lane, 1.4 miles from Sky Garden, and 1.4 miles from Liverpool Street Tube Station. Victoria Park is 2 miles from the guest house, and London Bridge is 2.1 miles away. St Paul's Cathedral is 2.1 miles from the guest house, while London Bridge Tube Station is 2.3 miles away. London City Airport is 5.6 miles from the property.";
                decimal avgMark1 = (decimal)9.9;
                string city1 = $"London";
                string address1 = $"49 Raven Row 601, London, E1 2EG, " +
                    $"United Kingdom";
                short numberOfRooms1 = 5;
                short numberOfFloors1 = 1;
                bool bathRoomAvailability1 = true;
                bool wifiAvailability1 = true;

                decimal cost1 = (decimal)1350.0354;
                int LLid1 = 1;

                db.Houses.Add(new House
                {
                    Header = header1,
                    Description = description1,
                    Address = address1,
                    City = city1,
                    AverageMark = avgMark1,
                    IsWiFiAvailable = wifiAvailability1,
                    IsBathroomAvailable = bathRoomAvailability1,
                    NumberOfFloors = numberOfFloors1,
                    NumberOfRooms = numberOfRooms1,
                    CostPerDay = cost1,
                    LlId = LLid1,
                });
                await db.SaveChangesAsync();

                for (int i = 2; i < numberOfFlats + 1; i++)
                {
                    string header = $"house {i}";
                    string description = $"description of the house{i}";
                    decimal avgMark = (decimal)9.9;
                    string city = $"city {i}";
                    string address = $"address{i}";
                    short numberOfRooms = (short)rand.Next(1, 3);
                    short numberOfFloors = (short)rand.Next(1, 3);
                    bool bathRoomAvailability = Convert.ToBoolean(rand.Next(0, 1));
                    bool wifiAvailability = Convert.ToBoolean(rand.Next(0, 1));

                    int integerPart = rand.Next(0, 9);

                    int fractionalPart = rand.Next(0, 99);

                    decimal result = integerPart + fractionalPart / 100.0m;

                    decimal cost = Math.Round(result, 2);
                    int LLid = rand.Next(1, numberOfLandLords);

                    db.Houses.Add(new House
                    {
                        Header = header,
                        Description = description,
                        Address = address,
                        City = city,
                        AverageMark = avgMark,
                        IsWiFiAvailable = wifiAvailability,
                        IsBathroomAvailable = bathRoomAvailability,
                        NumberOfFloors = numberOfFloors,
                        NumberOfRooms = numberOfRooms,
                        CostPerDay = cost,
                        LlId = LLid,
                    });
                    await db.SaveChangesAsync();
                }
            }

            if (!db.HouseImages.Any())
            {
                db.HouseImages.Add(new HouseImage
                {
                    HouseId = 1,
                    MainImageName = "House1Big.jpg",
                    BigImageName = "House1Big.jpg",
                    FirstSmallImageName = "House1FirstSmall.jpg",
                    SecondSmallImageName = "House1SecondSmall.jpg"
                });

                await db.SaveChangesAsync();
            }

            if (!db.HouseContracts.Any())
            {
                for (int i = 1; i < numberOfFlatsContracts + 1; i++)
                {
                    DateOnly startDate = new DateOnly(2020, 1, 11);
                    DateOnly endDate = new DateOnly(2020, 12, 11);
                    int range = (endDate.ToDateTime(TimeOnly.MinValue) - startDate.ToDateTime(TimeOnly.MinValue)).Days;
                    int randomDays = rand.Next(range + 1);
                    DateOnly rentStartDate = startDate.AddDays(randomDays);
                    int rentRange = rand.Next(randomDays, range);
                    DateOnly rentEndDate = startDate.AddDays(rentRange);

                    int Fid = rand.Next(1, numberOfFlats);
                    int Lid = rand.Next(1, numberOfLessees);
                    int LLid = rand.Next(1, numberOfLandLords);

                    int integerPart = rand.Next(0, 9);

                    int fractionalPart = rand.Next(0, 99);

                    decimal result = integerPart + fractionalPart / 100.0m;

                    decimal cost = Math.Round(result, 2);
                    db.HouseContracts.Add(new HouseContract
                    {
                        StartDate = rentStartDate,
                        EndDate = rentEndDate,
                        HouseId = Fid,
                        LesseeId = Lid,
                        LandlordId = LLid,
                        Cost = cost,
                    });
                    await db.SaveChangesAsync();

                }
            }

            if (!db.Hotels.Any())
            {

                for (int i = 1; i < numberOfFlats + 1; i++)
                {
                    string header = $"hotel {i}";
                    string description = $"description of the hotel{i}";
                    decimal avgMark = (decimal)9.9;
                    string city = $"city {i}";
                    string address = $"address{i}";
                    short numberOfRooms = (short)rand.Next(1, 3);
                    short numberOfFloors = (short)rand.Next(1, 3);
                    bool bathRoomAvailability = Convert.ToBoolean(rand.Next(0, 1));
                    bool wifiAvailability = Convert.ToBoolean(rand.Next(0, 1));

                    int integerPart = rand.Next(0, 9);

                    int fractionalPart = rand.Next(0, 99);

                    decimal result = integerPart + fractionalPart / 100.0m;

                    decimal cost = Math.Round(result, 2);
                    int LLid = rand.Next(1, numberOfLandLords);

                    db.Hotels.Add(new Hotel
                    {
                        Header = header,
                        Description = description,
                        Address = address,
                        City = city,
                        AverageMark = avgMark,
                        LlId = LLid,
                    });
                    await db.SaveChangesAsync();
                }
            }

            if (!db.Rooms.Any())
            {

                for (int i = 1; i < numberOfFlats + 1; i++)
                {
                    string header = $"room {i}";
                    string description = $"description of the room{i}";
                    decimal avgMark = (decimal)9.9;
                    short numberOfRooms = (short)rand.Next(1, 3);
                    short numberOfFloors = (short)rand.Next(1, 3);
                    bool bathRoomAvailability = Convert.ToBoolean(rand.Next(0, 1));
                    bool wifiAvailability = Convert.ToBoolean(rand.Next(0, 1));

                    int integerPart = rand.Next(0, 9);

                    int fractionalPart = rand.Next(0, 99);

                    decimal result = integerPart + fractionalPart / 100.0m;

                    decimal cost = Math.Round(result, 2);
                    int LLid = rand.Next(1, numberOfLandLords);
                    int Hid = rand.Next(1, numberOfFlats);

                    db.Rooms.Add(new Room
                    {
                        Header = header,
                        Description = description,
                        AverageMark = avgMark,
                        IsWiFiAvailable = wifiAvailability,
                        IsBathroomAvailable = bathRoomAvailability,
                        NumberOfFloors = numberOfFloors,
                        NumberOfRooms = numberOfRooms,
                        CostPerDay = cost,
                        HotelId = Hid
                    });
                    await db.SaveChangesAsync();
                }
            }

            if (!db.RoomContracts.Any())
            {
                for (int i = 1; i < numberOfFlatsContracts + 1; i++)
                {
                    DateOnly startDate = new DateOnly(2020, 1, 11);
                    DateOnly endDate = new DateOnly(2020, 12, 11);
                    int range = (endDate.ToDateTime(TimeOnly.MinValue) - startDate.ToDateTime(TimeOnly.MinValue)).Days;
                    int randomDays = rand.Next(range + 1);
                    DateOnly rentStartDate = startDate.AddDays(randomDays);
                    int rentRange = rand.Next(randomDays, range);
                    DateOnly rentEndDate = startDate.AddDays(rentRange);

                    int Fid = rand.Next(1, numberOfFlats);
                    int Lid = rand.Next(1, numberOfLessees);
                    int LLid = rand.Next(1, numberOfLandLords);

                    int integerPart = rand.Next(0, 9);

                    int fractionalPart = rand.Next(0, 99);

                    decimal result = integerPart + fractionalPart / 100.0m;

                    decimal cost = Math.Round(result, 2);

                    db.RoomContracts.Add(new RoomContract
                    {
                        StartDate = rentStartDate,
                        EndDate = rentEndDate,
                        RoomId = Fid,
                        LesseeId = Lid,
                        LandlordId = LLid,
                        Cost = cost,
                    });
                    await db.SaveChangesAsync();

                }
            }

        }
    }
}
