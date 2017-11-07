using BAL.AutoMapper;
using BAL.Interfaces;
using BAL.Managers;
using DAL.Interfaces;
using Models.Entities;
using Models.Entities.Enums;
using Models.ModelsDTO;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace VacationTrackingSystemTest
{
   
    public class TestProgram
    {
        [Fact]
        public void BasicTest()
        {
            //Arrange
            AutoMapperConfig.Configure();
            var vacationRepo = new Mock<IGenericRepository<VacationRequest>>();
            var uow = new Mock<IUnitOfWork>();
            var vacManager = new VacationManager(uow.Object);
            uow.Setup(x => x.VacationRequestRepo).Returns(vacationRepo.Object);
            var listVacations = new List<VacationRequest>();
            var vacationRequest = new VacationRequest
            {
                Id = 0,
                Name = "Maksym",    
                VacationType = VacationType.PaidDayOffs,
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow,
                Status = Status.InQueue,
            };
            var vacationRequest2 = new VacationRequest
            {
                Id = 1,
                Name = "Andrew",
                VacationType = VacationType.PaidDayOffs,
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow,
                Status = Status.InQueue,
            };
            listVacations.Add(vacationRequest);
            listVacations.Add(vacationRequest2);

            //Act
            vacationRepo.Setup(x => x.All).Returns(listVacations.AsQueryable());
            var result =  vacManager.GetAllVacations();

            //Assert
            Assert.Equal(result.FirstOrDefault().Status, Status.InQueue.ToString());

        }
    }
}
