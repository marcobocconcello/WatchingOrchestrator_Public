using System;
using System.Collections.Generic;
using System.Data.Common;
using WatchingOrchestrator.Dto;
using WatchingOrchestrator.Models;

namespace WatchingOrchestrator.Services{
    public interface IWatchingOrchestratorServices{
        public List<ElementsDto> GetAllElements();
        public List<StatesDto> GetAllStates();
        public ElementsDto GetElementsById(int elmentsId);

        public List<States> GetActiveStates();
        public List<States>  GetActiveStateById(int id);
        public List<StatesDto> GetActiveStatesWithDate(DateTime certainDate);

        public List<Contents> GetActiveContents();
        public List<Contents> GetActiveContentsById(int id);
        public List<ContentsDto> GetActiveContentWithDate(DateTime certainDate);
        public bool CreateElements(RequestCreateElement elementToCreate);

        public List<Elements> UpdateElement(RequestUpdateElements elementToUpdate, int idElem);

        public bool SaveChage();
    }
}