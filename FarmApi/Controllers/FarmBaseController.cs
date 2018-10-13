using FarmApi.Models;
using FarmApi.Repositories;
using System.Web.Http;

namespace FarmApi.Controllers
{
    public class FarmBaseController : ApiController
    {
        public static GenericRepository<AnimalModel> _animalRepo;
        public static GenericRepository<MedicalRecord> _medicalRepo;
    }
}
