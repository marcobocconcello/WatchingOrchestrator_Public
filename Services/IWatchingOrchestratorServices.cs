using System;
using System.Collections.Generic;
using System.Data.Common;
using WatchingOrchestrator.Dto;
using WatchingOrchestrator.Models;

namespace WatchingOrchestrator.Services{
    public interface IWatchingOrchestratorServices{
        //introduzione generics
        public List<T> GetActiveFromDb<T>();
        public List<ElementsDto> GetAllElements();
        public List<StatesDto> GetAllStates();
        public ElementsDto GetElementsById(int elmentsId);

        public List<States> GetActiveStates();
        public List<States>  GetActiveStateById(int id);
        public List<StatesDto> GetActiveStatesWithDate(DateTime certainDate);

        public List<ContentsDto> GetActiveContents();
        public List<ContentsDto> GetActiveContentsById(int id);
        public List<ContentsDto> GetActiveContentWithDate(DateTime certainDate);
        public bool CreateElements(RequestCreateElement elementToCreate);

        public List<ElementsDto> UpdateElement(RequestUpdateElements elementToUpdate, int idElem);

        public bool SaveChage();
    }
}