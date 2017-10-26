using BAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.ModelsDTO;
using DAL.Interfaces;
using AutoMapper;
using Models.Entities;
using Models.Entities.Enums;
using Models.ModelsVM;
using System.Data.Objects.SqlClient;

namespace BAL.Managers
{
    public class VacationManager : BaseManager, IVacationManager
    {
        public VacationManager(IUnitOfWork uow) : base(uow)
        {

        }
        public bool CreateVacation(VacationRequestDTO vacation)
        {
            var vacationToEntity = Mapper.Map<VacationRequest>(vacation);
            vacationToEntity.Status = Status.InQueue;
            var infoAboutVacation = uow.UserRepo.Get(includeProperties: "InfoAboutVacation").Select(s => s.InfoAboutVacation).FirstOrDefault(w => w.UserId == vacation.UserId);
            var days = (vacation.EndDate - vacation.StartDate).Days ==0 ? 1 : (vacation.EndDate - vacation.StartDate).Days;
            //also can use reflection instead of that
            if (vacation.VacationType == VacationType.PaidDayOffs)
            {
                if(infoAboutVacation.PaidDayOffs - days<0)
                {
                    return false;
                }
            }
            if (vacation.VacationType == VacationType.PaidSickness)
            {
                if (infoAboutVacation.PaidSickness - days < 0)
                {
                    return false;
                }
            }
            if (vacation.VacationType == VacationType.UnPaidDayOffs)
            {
                if (infoAboutVacation.UnPaidDayOffs - days < 0)
                {
                    return false;
                }
                if (vacation.VacationType == VacationType.UnPaidSickness)
                {
                    if (infoAboutVacation.UnPaidSickness - days < 0)
                    {
                        return false;
                    }
                }
            }
            var checkVacationInThisPeriod = uow.VacationRequestRepo.All.Where(s => vacation.StartDate >= s.StartDate && vacation.EndDate <= s.EndDate && s.UserId == vacation.UserId);
            if (checkVacationInThisPeriod.Count() > 0)
            {
                return false;
            }
            uow.VacationRequestRepo.Insert(vacationToEntity);
            uow.Save();
            return true;
        }
        public List<VacationRequestDTO> GetAllVacations()
        {
            List<VacationRequest> allVacationsFromDb = uow.VacationRequestRepo.All.Where(s=>s.Status == Status.InQueue).ToList();
            return Mapper.Map<List<VacationRequestDTO>>(allVacationsFromDb);
        }
        public bool ApproveDeclineVacation(ManagerRequestVM model)
        {
            if (model == null || model.UserId == 0)
            {
                return false;
            }
            var vacationInDb = uow.VacationRequestRepo.GetByID(model.Id);
            if (model.Status.Contains(Status.Approved.ToString()))
            {
                var getUserInfoAboutVacation = uow.UserRepo.Get(includeProperties: "InfoAboutVacation").Select(s => s.InfoAboutVacation).FirstOrDefault(w => w.UserId == model.UserId);
                if (vacationInDb != null)
                {
                    var days = 1;
                    if (model.EndDate != model.StartDate)
                    {
                        days = (model.EndDate - model.StartDate).Days;
                    }
                    if (model.Type == VacationType.PaidDayOffs)
                    {
                        if (getUserInfoAboutVacation.PaidDayOffs - days > 0)
                        {
                            getUserInfoAboutVacation.PaidDayOffs = getUserInfoAboutVacation.PaidDayOffs - days;
                        }
                        else { return false; }
                    }
                    if (model.Type == VacationType.UnPaidDayOffs)
                    {
                        if (getUserInfoAboutVacation.UnPaidDayOffs - days > 0)
                        {
                            getUserInfoAboutVacation.UnPaidDayOffs = getUserInfoAboutVacation.UnPaidDayOffs - days;
                        }
                        else { return false; }
                    }
                    if (model.Type == VacationType.PaidSickness)
                    {
                        if (getUserInfoAboutVacation.PaidSickness - days > 0)
                        {
                            getUserInfoAboutVacation.PaidSickness = getUserInfoAboutVacation.PaidSickness - days;
                        }
                        else { return false; }
                    }
                    if (model.Type == VacationType.UnPaidSickness)
                    {
                        if (getUserInfoAboutVacation.UnPaidSickness - days > 0)
                        {
                            getUserInfoAboutVacation.UnPaidSickness = getUserInfoAboutVacation.UnPaidSickness - days;
                        }
                        else { return false; }
                    }
                    Enum.TryParse(model.Status, out Status status);
                    vacationInDb.Status = status;
                }
            }
            
            uow.VacationRequestRepo.Update(vacationInDb);
            uow.Save();
            return true;
        }
        //public void DeclineRequest(managerRequestVM model)
        //{

        //}
    }
}
