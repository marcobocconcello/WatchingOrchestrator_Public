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
                
                if(id == null){
                    List<Contents> contentsList = _services.GetActiveContents();

                    return new ResposeContents(
                            _mapper.Map<List<ContentsDto>>(contentsList),
                            200,
                            "",
                            ""
                    );
                }
                else{
                    List<Contents> content = _services.GetActiveContentsById((int)id.Value);

                    return new ResposeContents(
                            _mapper.Map<List<ContentsDto>>(content),
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
    }
}