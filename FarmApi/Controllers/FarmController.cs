using FarmApi.Data;
using FarmApi.Models;
using FarmApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FarmApi.Controllers
{
    [RoutePrefix("api/farm")]
    public class FarmController : FarmBaseController
    {
      public IEnumerable<AnimalModel> Get()
        {
            _animalRepo = new GenericRepository<AnimalModel>(new FarmDbContext());
            return _animalRepo.GetAll();
        }

        [Route("detail/{id:int}")]
        public AnimalModel GetById(int id)
        {
            _animalRepo = new GenericRepository<AnimalModel>(new FarmDbContext());
            _medicalRepo = new GenericRepository<MedicalRecord>(new FarmDbContext());

            var animal = _animalRepo.FindById(id);
            animal.MedicalRecords = new List<MedicalRecord>();
            var medical = _medicalRepo.FindBy(p => p.Fk_Animal_Id == id);

            foreach (var record in medical)
            {
                animal.MedicalRecords.Add(record);
            }

            return animal;
        }

        [HttpPost]
        [Route("NewAnimal")]
        public HttpResponseMessage Post([FromBody] AnimalModel model)
        {
            _animalRepo = new GenericRepository<AnimalModel>(new FarmDbContext());
            _medicalRepo = new GenericRepository<MedicalRecord>(new FarmDbContext());
            AnimalModel animalModel = new AnimalModel();
            if (model!= null)
            {
                animalModel = model;

                foreach (var mrecord in model.MedicalRecords)
                {
                    animalModel.MedicalRecords.Add(mrecord);
                }
                _animalRepo.Add(animalModel);
                _animalRepo.Commit();

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, model);
            }
        }
    }
}
