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
        public delegate void SwitchOverInputDelegate(RequestUpdateElements elemetToUpdate, 
                                                    Elements elementFromDB);

        public WatchingOrchestratorServices(WatchingDbContext context)
        {
            this._context = context;
        }

        public bool CreateElements(RequestCreateElement elementInReq)
        {
            try{
                Elements elementToInsert = new Elements(
                    DateTime.Now,
                    DateTime.MaxValue,
                    DateTime.Now,
                    elementInReq.ReleaseDate,
                    elementInReq.Title,
                    elementInReq.Description,
                    elementInReq.Immage,
                    elementInReq.FlagPiaciuto,
                    elementInReq.ContentsId,
                    elementInReq.StatesId                
                );
                _context.Add(elementToInsert);

                if(_context.SaveChanges() > 0){
                    return true;
                }
                return false;
            }
            catch(Exception ex){
                throw new Exception($"Error in creating Elementa. Message: {ex.Message}");
            }
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

        public List<States> GetActiveStateById(int id)
        {
            try{
                List<States> statesList = _context.States
                                                    .Include(states => states.ElementsList)
                                                    .Where(states => states.StatesId == id)
                                                    .Where(elemenst => elemenst.EndDate > DateTime.Now 
                                                    && elemenst.StatesId == id).ToList();

                return statesList;
            }
            catch(Exception ex){
                throw new Exception($"Errore in GetActiveContentsById. Error: {ex.Message}");
            }
        }

        public List<States> GetActiveStates()
        {
            try{
                List<States> statesList = _context.States
                                                    .Include(states => states.ElementsList)
                                                    .Where(elemenst => elemenst.EndDate > DateTime.Now).ToList();

                return statesList;
            }
            catch(Exception ex){
                throw new Exception($"Errore in GetActiveStates. Error: {ex.Message}");
            }
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

        public bool SaveChage()
        {
            if(_context.SaveChanges() > 0){
                return true;
            }
            return false;
        }

        public List<Elements> UpdateElement(RequestUpdateElements elementToUpdate,
                                                int idElem)
        {
            try{
                Elements element =  _context.Elements
                                .Where(element => element.ElementsId == idElem)
                                .FirstOrDefault();

                SwitchOverInputDelegate switchOverInputDelegate = SwitchOverInput;
                switchOverInputDelegate.Invoke(elementToUpdate, element);

                if(_context.SaveChanges() > 0){
                    List<Elements> elementsListUpdate = _context.Elements
                                                        .Where(elementupdated => elementupdated.ElementsId == element.ElementsId)
                                                        .ToList();
                    return elementsListUpdate;
                }

                return new List<Elements>();
            }
            catch(Exception ex){
                throw new Exception($"Errore nell'update di un elemento. Message: {ex.Message}");
            }
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

        SwitchOverInputDelegate SwitchOverInput = (RequestUpdateElements elementInRequest, 
                                                    Elements elementFromDb) => {
            if(elementInRequest.NewReleaseDate.HasValue){
                elementFromDb.ReleaseDate = elementInRequest.NewReleaseDate.Value;
            }

            if(!String.IsNullOrEmpty(elementInRequest.NewTitle)){
                elementFromDb.Title = elementInRequest.NewTitle;
            }
            
            if(!String.IsNullOrEmpty(elementInRequest.NewDescription)){
                elementFromDb.Description = elementInRequest.NewDescription;
            }

            if(!String.IsNullOrEmpty(elementInRequest.NewImmage)){
                elementFromDb.Immage = elementInRequest.NewImmage;
            }

            if(!String.IsNullOrEmpty(elementInRequest.NewFlagPiaciuto)){
                elementFromDb.FlagPiaciuto = elementInRequest.NewFlagPiaciuto;
            }
            
            if(elementInRequest.NewContentsId.HasValue){
                
                if(elementInRequest.NewContentsId.Value < 0){
                    throw new Exception("NewContentsId ha un valore negativo");
                }

                elementFromDb.ContentsId = elementInRequest.NewContentsId.Value;
            }

            if(elementInRequest.NewStatesId.HasValue){
                
                if(elementInRequest.NewStatesId.Value < 0){
                    throw new Exception("NewStatesId ha un valore negativo");
                }

                elementFromDb.StatesId = elementInRequest.NewStatesId.Value;
            }
        };
    }
}