using System;
using hotal_DB.Models;
using hotal_DB.Repositories;
using hotal_DB.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace hotal_DB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //  DbContext
            var serviceProvider = new ServiceCollection()
                .AddDbContext<HotelContext>(options =>
                    options.UseSqlServer("Server=.;Database=HotelDB;Trusted_Connection=True;"))
                .BuildServiceProvider();

            using (var context = serviceProvider.GetRequiredService<HotelContext>())
            {
                //  (Repositories)
                var guestRepo = new GuestRepository(context);
                var roomRepo = new RoomRepostory(context);
                var bookingRepo = new BookingRepository(context);
                var reviewRepo = new ReviewRepository(context);

                bool exit = false;
                while (!exit)
                {
                    Console.Clear();
                    Console.WriteLine("==== Hotel Management System ====");
                    Console.WriteLine("1. Manage Guests");
                    Console.WriteLine("2. Manage Rooms");
                    Console.WriteLine("3. Manage Bookings");
                    Console.WriteLine("4. Manage Reviews");
                    Console.WriteLine("0. Exit");
                    Console.Write("Choose an option: ");
                    var choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            ManageGuests(guestRepo);
                            break;
                        case "2":
                            ManageRooms(roomRepo);
                            break;
                        case "3":
                            ManageBookings(bookingRepo, guestRepo, roomRepo);
                            break;
                        case "4":
                            ManageReviews(reviewRepo, guestRepo, bookingRepo);
                            break;
                        case "0":
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Press any key to try again.");
                            Console.ReadKey();
                            break;
                    }
                }
            }
        }

        static void ManageGuests(GuestRepository guestRepo)
        {
            Console.Clear();
            Console.WriteLine("=== Guests Management ===");
            Console.WriteLine("1. Add Guest");
            Console.WriteLine("2. List Guests");
            Console.WriteLine("3. Delete Guest");
            Console.WriteLine("0. Back");
            Console.Write("Choose: ");
            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.Write("Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Email: ");
                    string email = Console.ReadLine();
                    Console.Write("Phone: ");
                    string phone = Console.ReadLine();

                    var guest = new Guest { Name = name, Email = email, PhoneNumber = phone };
                    guestRepo.AddGuest(guest);
                    Console.WriteLine("Guest added successfully!");
                    break;

                case "2":
                    var guests = guestRepo.GetAllGuests();
                    foreach (var g in guests)
                    {
                        Console.WriteLine($"ID: {g.GuestId}, Name: {g.Name}, Email: {g.Email}, Phone: {g.PhoneNumber}");
                    }
                    break;

                case "3":
                    Console.Write("Enter Guest ID to delete: ");
                    if (int.TryParse(Console.ReadLine(), out int guestId))
                    {
                        guestRepo.DeleteGuest(guestId);
                        Console.WriteLine("Guest deleted if existed.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid ID.");
                    }
                    break;

                case "0":
                    return;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        static void ManageRooms(RoomRepostory roomRepo)
        {
            Console.Clear();
            Console.WriteLine("=== Rooms Management ===");
            Console.WriteLine("1. Add Room");
            Console.WriteLine("2. List Rooms");
            Console.WriteLine("3. Delete Room");
            Console.WriteLine("0. Back");
            Console.Write("Choose: ");
            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.Write("Room Number (int): ");
                    int roomNum = int.Parse(Console.ReadLine());
                    Console.Write("Room Type: ");
                    string type = Console.ReadLine();
                    Console.Write("Price: ");
                    double price = double.Parse(Console.ReadLine());
                    Console.Write("Is Available (true/false): ");
                    bool isAvailable = bool.Parse(Console.ReadLine());

                    var room = new Room
                    {
                        RoomNumber = roomNum,
                        RoomType = type,
                        Price = price,
                        IsAvailable = isAvailable
                    };
                    roomRepo.AddRoom(room);
                    Console.WriteLine("Room added!");
                    break;

                case "2":
                    var rooms = roomRepo.GetAllRooms();
                    foreach (var r in rooms)
                    {
                        Console.WriteLine($"Number: {r.RoomNumber}, Type: {r.RoomType}, Price: {r.Price}, Available: {r.IsAvailable}");
                    }
                    break;

                case "3":
                    Console.Write("Enter Room Number to delete: ");
                    if (int.TryParse(Console.ReadLine(), out int roomId))
                    {
                        roomRepo.DeleteRoom(roomId);
                        Console.WriteLine("Room deleted if existed.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid input.");
                    }
                    break;

                case "0":
                    return;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        static void ManageBookings(BookingRepository bookingRepo, GuestRepository guestRepo, RoomRepostory roomRepo)
        {
            Console.Clear();
            Console.WriteLine("=== Bookings Management ===");
            Console.WriteLine("1. Add Booking");
            Console.WriteLine("2. List Bookings");
            Console.WriteLine("3. Delete Booking");
            Console.WriteLine("0. Back");
            Console.Write("Choose: ");
            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.Write("Guest ID: ");
                    int guestId = int.Parse(Console.ReadLine());
                    Console.Write("Room Number: ");
                    int roomNumber = int.Parse(Console.ReadLine());
                    Console.Write("Start Date (yyyy-MM-dd): ");
                    DateTime startDate = DateTime.Parse(Console.ReadLine());
                    Console.Write("End Date (yyyy-MM-dd): ");
                    DateTime endDate = DateTime.Parse(Console.ReadLine());

                    var room = roomRepo.GetRoomById(roomNumber);
                    if (room == null)
                    {
                        Console.WriteLine("Room not found!");
                        break;
                    }

                    var booking = new Booking
                    {
                        GuestId = guestId,
                        RoomId = room.RoomNumber,
                        roomNumber = room.RoomNumber,
                        StartDate = startDate,
                        EndDate = endDate
                    };
                    bookingRepo.Add(booking);
                    Console.WriteLine("Booking added!");
                    break;

                case "2":
                    var bookings = bookingRepo.GetAll();
                    foreach (var b in bookings)
                    {
                        Console.WriteLine($"Booking ID: {b.Id}, Guest: {b.Guest?.Name}, Room: {b.Room?.RoomNumber}, From: {b.StartDate.ToShortDateString()}, To: {b.EndDate.ToShortDateString()}");
                    }
                    break;

                case "3":
                    Console.Write("Enter Booking ID to delete: ");
                    if (int.TryParse(Console.ReadLine(), out int bookingId))
                    {
                        bookingRepo.Delete(bookingId);
                        Console.WriteLine("Booking deleted if existed.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid input.");
                    }
                    break;

                case "0":
                    return;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        static void ManageReviews(ReviewRepository reviewRepo, GuestRepository guestRepo, BookingRepository bookingRepo)
        {
            Console.Clear();
            Console.WriteLine("=== Reviews Management ===");
            Console.WriteLine("1. Add Review");
            Console.WriteLine("2. List Reviews");
            Console.WriteLine("3. Delete Review");
            Console.WriteLine("0. Back");
            Console.Write("Choose: ");
            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.Write("Guest ID: ");
                    int guestId = int.Parse(Console.ReadLine());
                    Console.Write("Booking ID: ");
                    int bookingId = int.Parse(Console.ReadLine());
                    Console.Write("Room ID: ");
                    int roomId = int.Parse(Console.ReadLine());
                    Console.Write("Rating (1 to 5): ");
                    int rating = int.Parse(Console.ReadLine());
                    Console.Write("Comment: ");
                    string comment = Console.ReadLine();

                    var review = new Review
                    {
                        GuestId = guestId,
                        BookingId = bookingId,
                        RoomId = roomId,
                        Rating = rating,
                        Comment = comment
                    };
                    reviewRepo.AddReview(review);
                    Console.WriteLine("Review added!");
                    break;

                case "2":
                    var reviews = reviewRepo.GetAllReviews();
                    foreach (var r in reviews)
                    {
                        Console.WriteLine($"Review ID: {r.Id}, Guest ID: {r.GuestId}, Booking ID: {r.BookingId}, Room ID: {r.RoomId}, Rating: {r.Rating}, Comment: {r.Comment}");
                    }
                    break;

                case "3":
                    Console.Write("Enter Review ID to delete: ");
                    if (int.TryParse(Console.ReadLine(), out int reviewId))
                    {
                        reviewRepo.DeleteReview(reviewId);
                        Console.WriteLine("Review deleted if existed.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid input.");
                    }
                    break;

                case "0":
                    return;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
