using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using WatchingOrchestrator.Dto;
using WatchingOrchestrator.Models;
using WatchingOrchestrator.Services;

namespace WatchingOrchestrator.Controllers{

    [ApiController]
    [Route("v1/Watching")]
    public class WatchingOrchestratorController : ControllerBase{
        
        public readonly IWatchingOrchestratorServices _services;
        public readonly IMapper _mapper;
        public WatchingOrchestratorController(IMapper _mapper, IWatchingOrchestratorServices services)
        {
            this._mapper = _mapper;
            this._services = services;
        }
        [HttpGet("ActiveContents")]
        public ResposeContents GetContents([FromHeader] int? id){
            try{
                
                if(!id.HasValue){
                    List<ContentsDto> contentsDtoList = _services.GetActiveContents();

                    ResposeContents resposeContents = new ResposeContents(contentsDtoList,
                            200,
                            "",
                            "");

                    return new ResposeContents(
                            contentsDtoList,
                            200,
                            "",
                            ""
                    );
                }
                else{
                    List<ContentsDto> contentsDto = _services.GetActiveContentsById((int)id.Value);

                    return new ResposeContents(
                            contentsDto,
                            200,
                            "",
                            ""
                    );
                }


            }
            catch(Exception ex){
                return new ResposeContents(new List<ContentsDto>()
                                            , 500
                                            , "500",
                                            $"{ex.Message}");
            }
        }

        [HttpGet("ActiveStates")]
        public ResponseSates GetStates([FromHeader] int? id){
            try{
                
                if(id == null){
                    List<States> statessList = _services.GetActiveStates();

                    List<StatesDto> listdto = _mapper.Map<List<StatesDto>>(statessList);

                    return new ResponseSates(
                            _mapper.Map<List<StatesDto>>(statessList),
                            200,
                            "",
                            ""
                    );
                }
                else{
                    List<States> statessList = _services.GetActiveStateById((int)id.Value);

                    List<StatesDto> listdto = _mapper.Map<List<StatesDto>>(statessList);

                    return new ResponseSates(
                            _mapper.Map<List<StatesDto>>(statessList),
                            200,
                            "",
                            ""
                    );
                }


            }
            catch(Exception ex){
                return new ResponseSates(new List<StatesDto>()
                                            , 500
                                            , "500",
                                            $"{ex.Message}");
            }
        }
        [HttpPost("InsertElement")]
        public BaseResponse InsertElement([FromBody] RequestCreateElement request){
            try{

                Func<RequestCreateElement, bool> IsValidRequest = (requestCreateElements) => {
                    if(requestCreateElements == null){
                        return false;
                    }
                    if(String.IsNullOrEmpty(requestCreateElements.Title)){
                        return false;
                    }

                    if (requestCreateElements.StatesId == 1)
                    {
                        requestCreateElements.FlagPiaciuto = " ";
                    }
                    else {
                        if (String.IsNullOrEmpty(requestCreateElements.FlagPiaciuto)){
                            return false;
                        }
                    }

                    return true;
                };

                if(!IsValidRequest(request)){
                    throw new Exception("Request not valid");
                }

                if(_services.CreateElements(request)){
                    return new BaseResponse(200,"",""); 
                }
                
                return new BaseResponse(200,"500","Errore nel save change del db context per un elemento");
            }
            catch(Exception ex){
                return new BaseResponse(500,"500",$"{ex.Message}");
            }
        }


        [HttpPost("UpdateElement")]
        public ResponseElements UpdateElement([FromBody] RequestUpdateElements request, [FromHeader]int idElement){
            try{

                if(request == null){
                    throw new Exception("RequestUpdateElements is null");
                }

                List<ElementsDto> elementsUpdated = _services.UpdateElement(request, idElement);

                if(elementsUpdated == null){
                    throw new Exception("Elements updated null");
                }
                
                return new ResponseElements(
                        elementsUpdated,
                        200,
                        "",
                        ""
                );
            }
            catch(Exception ex){
                return new ResponseElements(new List<ElementsDto>(),500,"500",$"{ex.Message}");
            }
        }
    }
}