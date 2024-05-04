using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WatchingOrchestrator.Data;
using WatchingOrchestrator.Dto;
using WatchingOrchestrator.Models;

namespace WatchingOrchestrator.Services{
    public class WatchingOrchestratorServices : IWatchingOrchestratorServices
    {
        public readonly WatchingDbContext _context;
        private readonly IMapper _mapper;
        public WatchingOrchestratorServices(IMapper mapper,WatchingDbContext context)
        {
            this._mapper = mapper;
            this._context = context;
        }

        public List<Contents> GetActiveContents()
        {
            try{
                List<Contents> contentsList = _context.Contents
                                                    .Include(contents => contents.ElementsList)
                                                    .Where(elemenst => elemenst.EndDate > DateTime.Now).ToList();

                return contentsList;
            }
            catch(Exception ex){
                throw new Exception($"Errore in GetActiveContents. Error: {ex.Message}");
            }
        }

        public List<Contents> GetActiveContentsById(int id)
        {
            try{
                List<Contents> contentsList = _context.Contents
                                                    .Include(contents => contents.ElementsList)
                                                    .Where(contents => contents.ContentsId == id)
                                                    .Where(elemenst => elemenst.EndDate > DateTime.Now && elemenst.ContentsId == id).ToList();

                return contentsList;
            }
            catch(Exception ex){
                throw new Exception($"Errore in GetActiveContentsById. Error: {ex.Message}");
            }
        }

        public List<ContentsDto> GetActiveContentWithDate(DateTime certainDate)
        {
            throw new NotImplementedException();
        }

        public StatesDto GetActiveStateById(int id)
        {
            throw new NotImplementedException();
        }

        public List<StatesDto> GetActiveStates()
        {
            throw new NotImplementedException();
        }

        public List<StatesDto> GetActiveStatesWithDate(DateTime certainDate)
        {
            throw new NotImplementedException();
        }

        public List<Elements> GetAllElements()
        {

            List<Elements> elements = _context.Elements.ToList();
            /*foreach(Elements element in elements){
                element.Stato = _context.States.Where(s => s.StatesId == element.StatesId).ToList().FirstOrDefault();
            }
            */

            return elements;
            
        }

        public List<States> GetAllStates()
        {
            List<States> statesOutput = _context.States.Where(s => s.StatesId == 1).ToList();
            /*foreach(States states in statesOutput){
                states.ElementsList = new List<Elements>();
                states.ElementsList.AddRange(
                        _context.Elements.Where(element => element.StatesId == 1).ToList());
            }
            */
            
            return statesOutput; 
        }

        public Elements GetElementsById(int elmentsId)
        {
            Elements element = _context.Elements
                        .Include(element => element.Stato)
                        .Include(element => element.Categoria)
                        .Where(element => element.ElementsId == elmentsId).FirstOrDefault();

            return element;
        }

        List<ElementsDto> IWatchingOrchestratorServices.GetAllElements()
        {
            throw new NotImplementedException();
        }

        List<StatesDto> IWatchingOrchestratorServices.GetAllStates()
        {
            throw new NotImplementedException();
        }

        ElementsDto IWatchingOrchestratorServices.GetElementsById(int elmentsId)
        {
            throw new NotImplementedException();
        }
    }
}