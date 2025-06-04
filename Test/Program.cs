using System.Threading.Tasks;
using Office.Repositories;
using Office.Repositories.Implementations.FavoriteSpace;
using Office.Repositories.Implementations.Reservation;
using Office.Repositories.Implementations.User;
using Office.Repositories.Implementations.WorkSpace;
using Office.Repositories.Interfaces.FavoriteSpace;
using Office.Repositories.Interfaces.Reservation;
using Office.Repositories.Interfaces.User;
using Office.Repositories.Interfaces.WorkSpace;

namespace Test
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            ConnectionFactory.Initialize("Server=DESKTOP-IG0MKVO;Database=OfficeSpaces;Trusted_Connection=True;TrustServerCertificate=True;");

            UserRepository userRepository = new UserRepository();
            await foreach (var a in userRepository.RetrieveCollectionAsync(new UserFilter())){
                Console.WriteLine(a);
            }

            FavoriteSpaceRepository favoriteSpaceRepository = new FavoriteSpaceRepository();
            await foreach (var a in favoriteSpaceRepository.RetrieveCollectionAsync(new FavoriteSpaceFilter()))
            {
                Console.WriteLine(a);
            }

            ReservationRepository reservationRepository = new ReservationRepository();
            await foreach (var a in reservationRepository.RetrieveCollectionAsync(new ReservationFilter()))
            {
                Console.WriteLine(a);
            }

            WorkSpaceRepository workSpaceRepository = new WorkSpaceRepository();
            await foreach (var a in workSpaceRepository.RetrieveCollectionAsync(new WorkSpaceFilter()))
            {
                Console.WriteLine(a);
            }
        }
    }
}
